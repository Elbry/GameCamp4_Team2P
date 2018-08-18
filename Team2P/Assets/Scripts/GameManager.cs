using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	// 게임의 시작, 일시정지, 종료 등을 담당
	Timer timer;
	public int goalTime;
    public float score = 0f;

	// Use this for initialization
	void Start () {
		timer = FindObjectOfType<Timer>();
		GameStart();
		timer.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(timer.currentTime >= goalTime) {
			GameClear();
		}
	}

	void GameStart() {

	}

	void GamePause() {

	}

	void GameOver() {

	}

	void GameClear() {

	}
}
