using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCountUI : MonoBehaviour {

	Text text;
	GameManager GM;

	void Start() {
		GM = GameObject.FindObjectOfType<GameManager>();
		text = gameObject.GetComponent<Text>();
	}

	void Update() {
		text.text = "Score: " + GM.nKillCount;
	}
}
