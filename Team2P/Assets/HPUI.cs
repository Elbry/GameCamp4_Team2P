using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour {
	HP playerHP;
	public Text text;

	// Use this for initialization
	void Start () {
		playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<HP>();	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "HP " + playerHP.currentHP.ToString("N0");
	}
}
