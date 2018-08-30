using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// 게임의 시작, 일시정지, 종료 등을 담당
	Timer timer;
	public int goalTime;
    public float score = 0f;
    public int nKillCount = 0;

    float fStartGameTime = 0.0f;

    public GameObject gameEndWindow = null;
    public GameObject[] item;

    void Awake() {
        Screen.SetResolution(1280, 720, FullScreenMode.FullScreenWindow);
        Time.timeScale = 1f;
    }

    // Use this for initialization
    void Start ()
    {
        HideGameEndWindow();
        nKillCount = 0;

        timer = FindObjectOfType<Timer>();
		GameStart();
		timer.gameObject.SetActive(true);
	}

    void Update() {
        if((int)Time.time % 18 == 17
            && ((Time.time - (int)Time.time > 0f)) && (Time.time - (int)Time.time < 0.02f)) {
            Instantiate(item[Random.Range(0, 2)], new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), -1), Quaternion.identity);
        }

        if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

	void GameStart()
    {
        // 게임 시작 시간을 저장한다.
        fStartGameTime = Time.time;
	}

    public void HitSound() {

    }

    void HideGameEndWindow()
    {
        gameEndWindow.SetActive(false);   // 게임 종료 화면을 비활성화 한다.
    }

    public void ShowGameEndWindow()
    {
        Time.timeScale = 0f;
        float fPlayTime = Time.time - fStartGameTime;
        gameEndWindow.SetActive(true);        // 게임 종료 화면을 활성화 한다.
        gameEndWindow.GetComponent<GameEndWindow>().SetGameEndInfo(nKillCount, fPlayTime);
    }

    // 죽인 적의 수를 1증가 시킨다.
    public void IncreaseKillCount()
    {
        nKillCount++;
    }
}
