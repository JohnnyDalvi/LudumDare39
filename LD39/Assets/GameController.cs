using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameObject WinPanel;
    void OnEnable()
	{
	    Master.OnWin += Win;
	}

    void Win()
    {
        if (WinPanel==null)
            WinPanel = GameObject.FindWithTag("Win");
        WinPanel.SetActive(true);
        Master.PauseGame();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
