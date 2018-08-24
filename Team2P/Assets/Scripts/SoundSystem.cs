using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour {

	// 유니티 인스펙터 창에 걷는 소리 클립을 삽입했다
	public AudioClip walk;
	// 자기 자신의 AudioSource 컴포넌트를 받을 자리
	AudioSource effectSource;

	// 다른 오브젝트가 자유롭게 빌려 쓸 수 있도록 public 함수로 만들어두었다
	public void WalkSound() {
		effectSource.clip = walk;
		effectSource.PlayOneShot(effectSource.clip);
	}

	// Use this for initialization
	void Start () {
		effectSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
