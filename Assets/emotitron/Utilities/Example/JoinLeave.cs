using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JoinLeave : MonoBehaviour {

	public KeyCode join = KeyCode.P;
	public KeyCode leave = KeyCode.O;
	

	void Update () {

		if (Input.GetKeyDown(join))
			ClientScene.AddPlayer(0);

		if (Input.GetKeyDown(leave))
			ClientScene.RemovePlayer(0);

	}
}
