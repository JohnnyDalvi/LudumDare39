using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour {

	void Start ()
    {
		transform.position = new Vector3(SunFlower.instance.transform.position.x, SunFlower.instance.transform.position.y,transform.position.z);
	}

}
