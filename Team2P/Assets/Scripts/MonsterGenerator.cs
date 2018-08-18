using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterGenerator : MonoBehaviour {
    
    // 몬스터를 새로 만들어내는 역할
    public GameObject[] monster;
    private float interval = 5.0f;
    private float currentTime = 0.0f;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if(currentTime >= interval)
        {
            int randtime = (int)Random.Range(0, 4);
            if (randtime == 0)
            {

                for (int i = 0; i < 10; i++)
                {   
                    Vector3 newPosition = new Vector3(Random.Range(-19.5f, 19.5f), Random.Range(19.5f, 19.5f), -1);
                    Instantiate(monster[1], newPosition, Quaternion.identity);
                }

            }
            if (randtime == 1)
            {

                for (int i = 0; i < 10; i++)
                {
                    Vector3 newPosition = new Vector3(Random.Range(20f, 20f), Random.Range(18f, -18f), -1);
                    Instantiate(monster[0], newPosition, Quaternion.identity);
                }

            }
            if (randtime == 2)
            {

                for (int i = 0; i < 10; i++)
                {
                    Vector3 newPosition = new Vector3(Random.Range(-18.9f, -18.9f), Random.Range(18.2f, -18.2f), -1);
                    Instantiate(monster[2], newPosition, Quaternion.identity);
                }

            }
            if (randtime == 3)
            {

                for (int i = 0; i < 10; i++)
                {
                    Vector3 newPosition = new Vector3(Random.Range(-18.82f, 18.82f), Random.Range(-19.51f, -19.51f), -1);
                    Instantiate(monster[3], newPosition, Quaternion.identity);
                }

            }
            currentTime = 0;
        }
        //if (Time.time > nextTime)
        //{
        //    nextTime = TimeLeft * Time.deltaTime;
        //    Vector3 newPosition = new Vector3(Random.Range(-19.5f, 19.5f), Random.Range(19.5f, 19.5f), -1);
        //    Instantiate(monster[0], newPosition, Quaternion.identity);
        //}

    }
}
