using UnityEngine;
using System.Collections;

public class LoadingStartScene : MonoBehaviour {
	
	void Start () 
	{
		FindObjectOfType<LevelManager>().GetComponent<LevelManager>().LoadNextLevelin(3);	
	}
}
