using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour {
    
    // 몬스터를 새로 만들어내는 역할
    public GameObject monster;
    private float TimeLeft = 3.0f;
    private float nextTime = 0.0f;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextTime)
        {
            nextTime = TimeLeft * Time.deltaTime;
            Vector3 newPosition = new Vector3(Random.Range(-6f, -6f), Random.Range(-5f, 5f), -1);
            Instantiate(monster, newPosition, Quaternion.identity);
        }
	}
}
