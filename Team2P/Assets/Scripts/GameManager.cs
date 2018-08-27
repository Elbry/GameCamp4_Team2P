using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// 게임의 시작, 일시정지, 종료 등을 담당
	Timer timer;
	public int goalTime;
    public float score = 0f;
    protected int nKillCount = 0;

    float fStartGameTime = 0.0f;

    public GameObject gameEndWindow = null;



    // Use this for initialization
    void Start ()
    {
        HideGameEndWindow();
        nKillCount = 0;

        timer = FindObjectOfType<Timer>();
		GameStart();
		timer.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(timer.currentTime >= goalTime)
        {
			GameClear();
		}
        
        // Test Code
        if( Input.GetKeyUp(KeyCode.A) )
        {
            nKillCount = 10;
            ShowGameEndWindow();
        }
	}

	void GameStart()
    {
        // 게임 시작 시간을 저장한다.
        fStartGameTime = Time.time;
	}

	void GamePause()
    {

	}

	void GameOver()
    {
        ShowGameEndWindow();
    }

	void GameClear()
    {

	}

    void HideGameEndWindow()
    {
        gameEndWindow.SetActive(false);   // 게임 종료 화면을 비활성화 한다.
    }

    void ShowGameEndWindow()
    {
        float fPlayTime = Time.time - fStartGameTime;
        gameEndWindow.GetComponent<GameEndWindow>().SetGameEndInfo(nKillCount, fPlayTime);
        gameEndWindow.SetActive(true);        // 게임 종료 화면을 활성화 한다.
    }

    // 죽인 적의 수를 1증가 시킨다.
    public void IncreaseKillCount()
    {
        nKillCount++;
    }
}
