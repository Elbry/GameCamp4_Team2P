using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour {
	// 주인공도 적도 모두 HP가 있으니 하나의 스크립트를 재활용합시다
	public int maxHP;
	public int currentHP;

	public void SetMaxHP(int amount) {
		maxHP = amount;
	}

	public void SetCurrentHP(int amount) {
		currentHP = amount;
	}

	public void GetDamaged(int amount) {
		currentHP -= amount;
	}

	public void GetHealed(int amount) {
		currentHP += amount;
	}

}
