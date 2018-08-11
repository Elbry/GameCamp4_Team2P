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
            nextTime = Time.time + TimeLeft;
            Vector3 newPosition = new Vector3(Random.Range(-5.7f, -5.7f), Random.Range(-4.89f, 4.89f), 0);
            Instantiate(monster, newPosition, Quaternion.identity);
        }
	}
}
