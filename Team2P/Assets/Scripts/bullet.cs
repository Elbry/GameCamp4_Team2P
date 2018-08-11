using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float speed;
    public float time;
    public GameObject player;
    Rigidbody rb;


	// Use this for initialization
	void Awake ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
        time -= 1;
        if (time < 0)
        {
            Destroy(gameObject);
        }
	}
}
