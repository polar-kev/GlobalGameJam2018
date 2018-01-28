using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour {

	public GameObject robotArm;
	public Transform rightArmSpawn;
	public Transform rightHandTarget;

	public float thrust = 100f;
	public float delay = 2f;
	public string shootRightArm;

	private float elapsedTime;
	private bool shotArm;
	private Transform startPos;

	// Use this for initialization
	void Start () {
		shotArm = false;
		startPos = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if((Input.GetButton(shootRightArm) || Input.GetButton ("Fire1")) && !shotArm){
			ShootArm ();
		}
		if(shotArm && elapsedTime >= delay){
			robotArm.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			robotArm.GetComponent<Rigidbody> ().MovePosition (rightArmSpawn.position);
			print ("Reset");
			shotArm = false;
		}
	}

	void ShootArm(){
		elapsedTime = 0;
		robotArm.GetComponent<Rigidbody> ().AddForce (Vector3.right * thrust);
		shotArm = true;
	}
}
