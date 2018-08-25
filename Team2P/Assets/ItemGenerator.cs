using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemGenerator : MonoBehaviour
{

    // 몬스터를 새로 만들어내는 역할
    public GameObject[] Item;
    private float interval = 50.0f;
    private float currentTime = 0.0f;
    // Use this for initialization
    void Start()
    {

    }

    // 랜덤하게 몬스터 종류도 정하고 랜덤하게 위치값도 정해야 하는데 이걸 매번 반복해서 조건문을 늘리면 복잡해지므로
    // 위치값 정하는 함수를 따로 생성
    Vector3 Spawn()
    {
        // 임의의 수치. 아래의 분기가 제대로 작동하지 않는다면 몬스터는 항상 (-20f, -20f) 위치에서 생성될 것이다
        float x = Random.Range(-4f, 4f);
        float y = Random.Range(-4f, 4f);
        return new Vector3(x, y, -1);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= interval)
        {
            int randtime = (int)Random.Range(0, 2);
            if (randtime == 0)
            {

                for (int i = 0; i < Random.Range(1f,2f); i++)
                {
                    //Vector3 newPosition = new Vector3(Random.Range(-19.5f, 19.5f), Random.Range(19.5f, 19.5f), -1);
                    Instantiate(Item[1], Spawn(), Quaternion.identity);
                }

            }
            if (randtime == 1)
            {

                for (int i = 0; i < 10; i++)
                {
                    //Vector3 newPosition = new Vector3(Random.Range(20f, 20f), Random.Range(18f, -18f), -1);
                    Instantiate(Item[0], Spawn(), Quaternion.identity);
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
