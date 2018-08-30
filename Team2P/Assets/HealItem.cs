using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour {

	public int healAmount;

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "Player") {
			collision.gameObject.GetComponent<HP>().currentHP += 20;
			Destroy(gameObject);
		}
	}
}
