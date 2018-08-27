using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndWindow : MonoBehaviour
{
    public Text textKillCount = null;
    public Text textPlayTime = null;

	// Use this for initialization
	void Start ()
    {
		
	}

    public void SetGameEndInfo(int killCount, float playTime)
    {
        textKillCount.text = killCount.ToString();
        textPlayTime.text = playTime.ToString();
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }

}   
