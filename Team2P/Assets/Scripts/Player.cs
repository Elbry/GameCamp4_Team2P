using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    public float speed;
    public Camera cam;
    public GameObject bullet;
    Vector3 move;
    public Vector3 go;
    Rigidbody2D rb;
    float dash = 0;
    float dy;
    float dx;
    public Sprite[] ch;
    bool isDash;
    // 넉백 중에는 플레이어 조작을 제한시키기 위해 도입된 bool 변수
    bool isKnockingBack;
    // 음향 효과를 내기 위해 받아 놓는 오브젝트
    SoundSystem soundSystem;
    // 걷는 소리 주기 조절 변수
    int walkCount = 20;
    int initialCooltime = 10;
    int cooltime;
    int characterIndex = 0;
    public AudioClip[] shotClip;
    AudioSource shotSound;
    public int damageMultiplier = 1;

    

	// 플레이어의 입력을 받아 주인공 캐릭터를 조작하게 하는 스크립트
	// Use this for initialization
	void Start ()
    {
        shotSound = gameObject.GetComponent<AudioSource>();
        shotSound.clip = shotClip[0];
        soundSystem = GameObject.FindObjectOfType<SoundSystem>();
        rb = GetComponent<Rigidbody2D>();
        isKnockingBack = false;
        cooltime = initialCooltime;
        characterIndex = 0;
        damageMultiplier = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Look();
        if (Input.GetMouseButtonDown(1) && isDash == false)
        {
            dash = speed * 10;
            isDash = true;
        }
        if (Input.GetMouseButtonDown(0) && cooltime == 0)
        {
            GameObject newBullet = Instantiate(bullet, transform.position + go * 0.2f, Quaternion.identity);
            if(characterIndex == 1) {
                newBullet.transform.localScale *= 2;
                newBullet.GetComponent<SpriteRenderer>().color = Color.cyan;
                newBullet.GetComponent<bullet>().speed *= 2;
            }
            shotSound.PlayOneShot(shotSound.clip);
            cooltime = initialCooltime;
        }
        cooltime = Mathf.Clamp(cooltime - 1, 0, initialCooltime);
        
        // 넉백 중이지 않을 때에만 움직이거나 대시 할 수 있도록 함
        if(isKnockingBack == false)
        {
            if(isDash == true) {
                Dash();
                if(dash <= speed) isDash = false;
            }
            else Move();
        }

        Look();
        Cam();
        Change();
    }

    void Move()
    {
        float h;
        float v;
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // 걷는 동안 소리가 날 수 있도록 조건문 생성
        if(h != 0 || v != 0) {
            if((transform.position.x < -19f && h < 0) || (transform.position.x > 19 && h > 0)) h = 0;
            if((transform.position.y < -19f && v < 0) || (transform.position.y > 19 && v > 0)) v = 0;
            move = new Vector3(h, v, 0);
            move = move.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + move);
            walkCount++;
            
            // 걷기 행동을 20번째 할 때마다 걷는 소리 출력
            // 수치가 20이어야 하는 이유는 없음: 그냥 그게 제일 주기가 알맞아 보여서 설정했을 뿐
            // 이런 식으로 20번마다 소리를 내도록 하지 않으면 프레임마다 소리가 나서 귀가 아프다
            if(walkCount > 20) {
                soundSystem.WalkSound();
                walkCount = 0;
            }
        }
    }

    void Dash()
    {
        rb.MovePosition(transform.position + go * dash * 0.2f * Time.deltaTime);
        dash -= 5f;
    }

    void Look()
    {
        if (isDash == false)
        {
            //먼저 계산을 위해 마우스와 게임 오브젝트의 현재의 좌표를 임시로 저장합니다.
            Vector3 mPosition = Input.mousePosition; //마우스 좌표 저장
            Vector3 oPosition = transform.position; //게임 오브젝트 좌표 저장
                                                    //카메라가 앞면에서 뒤로 보고 있기 때문에, 마우스 position의 z축 정보에 
                                                    //게임 오브젝트와 카메라와의 z축의 차이를 입력시켜줘야 합니다.
            mPosition.z = oPosition.z - Camera.main.transform.position.z;
            //화면의 픽셀별로 변화되는 마우스의 좌표를 유니티의 좌표로 변화해 줘야 합니다.
            //그래야, 위치를 찾아갈 수 있겠습니다.
            Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);
            //다음은 아크탄젠트(arctan, 역탄젠트)로 게임 오브젝트의 좌표와 마우스 포인트의 좌표를
            //이용하여 각도를 구한 후, 오일러(Euler)회전 함수를 사용하여 게임 오브젝트를 회전시키기
            //위해, 각 축의 거리차를 구한 후 오일러 회전함수에 적용시킵니다.
            //우선 각 축의 거리를 계산하여, dy, dx에 저장해 둡니다.
            float dy = target.y - oPosition.y;
            float dx = target.x - oPosition.x;
            //오릴러 회전 함수를 0에서 180 또는 0에서 -180의 각도를 입력 받는데 반하여
            //(물론 270과 같은 값의 입력도 전혀 문제없습니다.) 아크탄젠트 Atan2()함수의 결과 값은 
            //라디안 값(180도가 파이(3.141592654...)로)으로 출력되므로
            //라디안 값을 각도로 변화하기 위해 Rad2Deg를 곱해주어야 각도가 됩니다.
            go = new Vector3(dx, dy, 0).normalized;
            
        }
    }

    void Cam()
    {
        cam.transform.position =
            new Vector3(Mathf.Clamp(transform.position.x, -10.5f, 10.5f), Mathf.Clamp(transform.position.y, -13f, 13f), -10);
    }

    void Change()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && characterIndex != 0)
        {
            characterIndex = 0;
            GetComponent<SpriteRenderer>().sprite = ch[characterIndex];
            initialCooltime = 10;
            bullet.GetComponent<bullet>().damage = 1;
            shotSound.clip = shotClip[characterIndex];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && characterIndex != 1)
        {
            characterIndex = 1;
            GetComponent<SpriteRenderer>().sprite = ch[characterIndex];
            initialCooltime = 30;
            bullet.GetComponent<bullet>().damage = 3;
            shotSound.clip = shotClip[characterIndex];
        }
    }

    // Monster 스크립트가 푸시가 안 되어 있어서 우선 Player 쪽에 넉백 구현
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject target = collision.gameObject;
        if (target.tag == "monster")
        {
            gameObject.GetComponent<HP>().currentHP -=1;
            // 충돌이 일어난 지점과 몬스터 오브젝트의 중심 지점을 가지고 넉백되어야 할 방향 산출
            Vector2 relativePos = collision.contacts[0].otherRigidbody.worldCenterOfMass - collision.contacts[0].point;
            // 넉백 행동 자체는 외부의 코루틴 함수로
            StartCoroutine(KnockBack(gameObject, relativePos.normalized));
        }
    }

    // 코루틴 함수
    // 비슷한 형식으로 몬스터도 넉백시킬 수 있도록 구현할 수 있다
    // 하지만 내부에 isKnockingBack, rb처럼 Player 스크립트에만 있는 변수를 사용하고 있기 때문에 그대로 옮겨 가면 안 된다
    IEnumerator KnockBack(GameObject target, Vector2 direction) {
        isKnockingBack = true;
        for(int i = 0; i < 20; i++) {
            rb.MovePosition((Vector2)transform.position + direction * Time.deltaTime * (20 - i));
            yield return new WaitForFixedUpdate();
        }
        isKnockingBack = false;
        yield break;
    }
}
