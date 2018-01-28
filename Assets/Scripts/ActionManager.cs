using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour {

	public bool actionCubeLeft;
    public bool actionCubeRight;
	public Material myMaterial;

	private float elapsedTime;

	// Use this for initialization
	void Start () {
        actionCubeLeft = false;
        actionCubeRight = false;
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("ActionCubeLeft")){
            actionCubeLeft = true;
            other.GetComponent<MeshRenderer>().material = myMaterial;
        }
		if(other.gameObject.CompareTag("ActionCubeRight")){
            actionCubeRight = true;
            other.GetComponent<MeshRenderer>().material = myMaterial;
        }
		
	}
}
