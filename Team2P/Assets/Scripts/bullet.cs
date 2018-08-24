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
        float rotateDegree = -Mathf.Atan2(go.x, go.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree + 90f);
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
        }
        Destroy(gameObject);
    }
}
