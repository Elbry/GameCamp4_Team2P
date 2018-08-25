using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public float speed;
    public float bSpeed;
    GameObject player;
    Rigidbody2D rb;
    Vector3 go;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindObjectOfType<Player>().gameObject;
    }
	
	void FixedUpdate ()
    {
        go = (player.transform.position - transform.position).normalized;
        rb.MovePosition(transform.position + go * speed * Time.deltaTime);
	}

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<HP>().currentHP -= 1;
        }
    }
}
