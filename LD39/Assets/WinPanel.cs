﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour {

	void Start ()
	{
	    GameController.WinPanel = this.gameObject;
        gameObject.SetActive(false);
	}
	
}
