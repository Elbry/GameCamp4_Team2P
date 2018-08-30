using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public float speed;
    GameObject player;
    Rigidbody2D rb;
    Vector3 go;
    bool isKnockingBack;
    public int damage;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindObjectOfType<Player>().gameObject;
    }
	
	void FixedUpdate ()
    {
        if (isKnockingBack == false)
        {
            go = (player.transform.position - transform.position).normalized;
            rb.MovePosition(transform.position + go * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            // 충돌이 일어난 지점과 몬스터 오브젝트의 중심 지점을 가지고 넉백되어야 할 방향 산출
            Vector2 relativePos = collision.contacts[0].otherRigidbody.worldCenterOfMass - collision.contacts[0].point;
            // 넉백 행동 자체는 외부의 코루틴 함수로
            StartCoroutine(KnockBack(gameObject, relativePos.normalized));
        }
    }

    IEnumerator KnockBack(GameObject target, Vector2 direction)
    {
        isKnockingBack = true;
        for (int i = 0; i < 20; i++)
        {
            rb.MovePosition((Vector2)transform.position + direction * 0.1f * Time.deltaTime * (20 - i));
            print(i);
            yield return new WaitForFixedUpdate();
        }
        isKnockingBack = false;
        yield break;
    }
}
