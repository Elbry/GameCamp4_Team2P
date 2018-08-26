using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float speed;
    public float time;
    public GameObject player;
    Rigidbody2D rb;

    Vector3 go;


	// Use this for initialization
	void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindObjectOfType<Player>().gameObject;
        go = player.GetComponent<Player>().go;
        // 이 수치를 계산할 때 들어가야 하는 공식은 스프라이트의 방향, 게임에서 물체들이 보이는 방식에 따라 달라짐
        // 여기서 사용된 쿼터니언 개념이나 레이 캐스팅(반직선과 3차원 공간의 관계), 아크탄젠트 등을 이해하고 그에 맞게 스크립팅하는 것이 가장 효율적
        // 하지만 찾아온 코드가 이번처럼 얼추 맞고 부분적으로 틀리다면, 에디터 안에서 적당히 식을 변화시켜가 보며 시행착오로 공식을 찾아가는 것도 방법
        // 이런 식으로 아래 rotateDegree 계산식에서 우변에 -를 붙이고(회전방향 교정), 오일러 변환할 때 여기에 90도를 더함(누워 있는 총알 이미지 세우기)
        float rotateDegree = -Mathf.Atan2(go.x, go.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree + 90f);
        time = 500;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rb.MovePosition(transform.position + go * speed * Time.deltaTime);
        time -= 1;
        if (time < 0)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject target = collision.gameObject;
        if(target.tag == "monster") {
            target.GetComponent<HP>().currentHP -= 1;
            Destroy(gameObject);
        }
    }
}
