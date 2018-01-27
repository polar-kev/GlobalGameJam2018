using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour {

	public bool actionCube1;
	public bool actionCube2;
	public Material myMaterial;

	private float elapsedTime;
	private float cube1Timer;
	private float cube2Timer;

	// Use this for initialization
	void Start () {
		actionCube1 = false;
		actionCube2 = false;

		cube1Timer = 0;
		cube2Timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("ActionCube1")){
			actionCube1 = true;
		}
		if(other.CompareTag("ActionCube2")){
			actionCube2 = true;
		}
		other.GetComponent<MeshRenderer> ().material = myMaterial;
	}
}
