using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrip : MonoBehaviour {

	public Animator handAnimator;
	public string gripAccess;

	
	// Update is called once per frame
	void Update () {
		handAnimator.SetFloat ("HandGrip", Input.GetAxis (gripAccess));
	}
}
