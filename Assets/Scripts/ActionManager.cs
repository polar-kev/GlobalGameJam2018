using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour {

	public bool actionCubeLeft;
    public bool actionCubeRight;
	public Material myMaterial;

	private float elapsedTime;
	private float cube1Timer;
	private float cube2Timer;

	// Use this for initialization
	void Start () {
        actionCubeLeft = false;
        actionCubeRight = false;

		cube1Timer = 0;
		cube2Timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("ActionCubeLeft")){
            actionCubeLeft = true;
		}
		if(other.gameObject.CompareTag("ActionCubeRight")){
            actionCubeRight = true;
		}
		other.GetComponent<MeshRenderer> ().material = myMaterial;
        print("Collision");
	}
}
