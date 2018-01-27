using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboArm : MonoBehaviour {

	public Transform armSpawn;
	public float thrust = 10f;

	private bool punching;
	private bool grabbing;

	private Rigidbody rgbd;



	// Use this for initialization
	void Start () {
		punching = false;
		grabbing = false;

		rgbd = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1")){
			Punch ();
		}
		print (rgbd.position);
	}

	void Punch(){
		//play punch animation

		//For testing
		//x-direction is forward
		rgbd.MovePosition (rgbd.position+Vector3.right * thrust);
	}

	IEnumerator RetractArm(){
		yield return new WaitForSeconds(2);
		rgbd.MovePosition (armSpawn);
	}
		

}
