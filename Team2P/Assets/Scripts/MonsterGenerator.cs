using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterGenerator : MonoBehaviour {
    
    // 몬스터를 새로 만들어내는 역할
    public GameObject[] monster;
    private float interval = 5.0f;
    private float currentTime = 0.0f;
    int waveCount = 0;

	// Use this for initialization
	void Start () {

    }
	
    // 랜덤하게 몬스터 종류도 정하고 랜덤하게 위치값도 정해야 하는데 이걸 매번 반복해서 조건문을 늘리면 복잡해지므로
    // 위치값 정하는 함수를 따로 생성
    Vector3 Spawn() {
        // 임의의 수치. 아래의 분기가 제대로 작동하지 않는다면 몬스터는 항상 (-20f, -20f) 위치에서 생성될 것이다
        float x = -20f;
        float y = -20f;
        int index = (int)Random.Range(0, 4);
        switch(index) {
            // 위에서 스폰
            case 0: {
                x = Random.Range(-15f, 15f);
                y = 15f;
            }
            break;
            // 왼쪽에서 스폰
            case 1: {
                x = -15f;
                y = Random.Range(-15f, 15f);
            }
            break;
            // 오른쪽에서 스폰
            case 2: {
                x = 15f;
                y = Random.Range(-15f, 15f);
            }
            break;
            // 아래에서 스폰
            case 3: {
                x = Random.Range(-15f, 15f);
                y = -15f;
            }
            break;
        }

        return new Vector3(x, y, -1);
    }

	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if(currentTime >= interval)
        {
            switch(waveCount % 6) {
                // 슬라임 조금
                case 0: {
                    for(int i = 0; i < (1 + waveCount / 6); i++) {
                        Instantiate(monster[0], Spawn(), Quaternion.identity);
                    }
                }
                break;
                // 좀비나 슬라임
                case 1: {
                    int randtime = (int)Random.Range(0, 2);
                    if (randtime == 0)
                    {
                        // 슬라임
                        for (int i = 0; i < (2 + waveCount / 6); i++)
                        {   
                            Instantiate(monster[0], Spawn(), Quaternion.identity);
                        }

                    }
                    if (randtime == 1)
                    {
                        // 좀비
                        for (int i = 0; i < (3 + waveCount / 3); i++)
                        {
                            Instantiate(monster[1], Spawn(), Quaternion.identity);
                        }

                    }
                }
                break;
                // 좀비나 슬라임 더 높은 난이도
                case 2: {
                    int randtime = (int)Random.Range(0, 2);
                    if (randtime == 0)
                    {
                        // 슬라임
                        for (int i = 0; i < (3 + waveCount / 3); i++)
                        {   
                            Instantiate(monster[0], Spawn(), Quaternion.identity);
                        }
                    }
                    if (randtime == 1)
                    {
                        // 좀비
                        for (int i = 0; i < (5 + waveCount / 3); i++)
                        {
                            Instantiate(monster[1], Spawn(), Quaternion.identity);
                        }
                    }
                }
                break;
                // 골렘이나 뱀파이어
                case 3: {
                    int randtime = (int)Random.Range(0, 2);
                    if (randtime == 0)
                    {
                        // 골렘
                        for (int i = 0; i < (2 + waveCount / 6); i++)
                        {   
                            Instantiate(monster[2], Spawn(), Quaternion.identity);
                        }
                    }
                    if (randtime == 1)
                    {
                        // 뱀파이어
                        for (int i = 0; i < (1 + waveCount / 6); i++)
                        {
                            Instantiate(monster[3], Spawn(), Quaternion.identity);
                        }
                    }
                }
                break;
                // 골렘이나 뱀파이어 더 높은 난이도
                case 4: {
                    int randtime = (int)Random.Range(0, 2);
                    if (randtime == 0)
                    {
                        // 골렘
                        for (int i = 0; i < (3 + waveCount / 3); i++)
                        {   
                            Instantiate(monster[2], Spawn(), Quaternion.identity);
                        }
                    }
                    if (randtime == 1)
                    {
                        // 뱀파이어
                        for (int i = 0; i < (2 + waveCount / 3); i++)
                        {
                            Instantiate(monster[3], Spawn(), Quaternion.identity);
                        }
                    }
                }
                break;
                // 드래곤
                case 5: {
                    for(int i = 0; i < (1 + waveCount / 3); i++) {
                        Instantiate(monster[4], Spawn(), Quaternion.identity);
                    }
                }
                break;
            }

            waveCount++;
            currentTime = 0;
            
            if(waveCount % 12 == 11) interval = Mathf.Clamp(interval - 1, 1.0f, 5.0f);
        }
    }
}
