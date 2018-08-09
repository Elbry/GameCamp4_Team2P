using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	// 게임 시간의 경과나 속도를 담당
	public float currentTime;
	bool timeStopped;

	// Use this for initialization
	void Start () {
		currentTime = 0;
		timeStopped = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!timeStopped) {
			currentTime += Time.deltaTime;
		}
	}

	public void TimeStop() {
		timeStopped = true;
		Time.timeScale = 0;
	}

	public void TimeResume() {
		timeStopped = false;
		Time.timeScale = 1;
	}

}
