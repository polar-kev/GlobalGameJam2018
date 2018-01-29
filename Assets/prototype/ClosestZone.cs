using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Zone{
	public string name;
	public float distance;
}

public class ClosestZone : MonoBehaviour {

	public float speed = 10f;
	public GameObject cube1;
	public GameObject cube2;
	public GameObject cube3;

	private Zone zone1;
	private Zone zone2;
	private Zone zone3;
	private Zone minZone;

	// Use this for initialization
	void Start () {
		zone1 = new Zone ();
		zone1.name = "cube1";
		zone2 = new Zone ();
		zone2.name = "cube2";
		zone3 = new Zone ();
		zone3.name = "cube3";

		minZone = new Zone ();
		minZone.distance = 0;
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(Vector3.forward * Input.GetAxis ("Horizontal")*speed *Time.deltaTime);
		gameObject.transform.Translate(Vector3.left * Input.GetAxis ("Vertical")*speed*Time.deltaTime);

		zone1.distance = Vector3.Distance (gameObject.transform.position,cube1.transform.position);
		zone2.distance = Vector3.Distance (gameObject.transform.position,cube2.transform.position);
		zone3.distance = Vector3.Distance (gameObject.transform.position,cube3.transform.position);

		minZone = zone1;
		if (minZone.distance > zone2.distance)
			minZone = zone2;
		if (minZone.distance > zone3.distance)
			minZone = zone3;

		print ("The Closest Zone is: " + minZone.name);



	}
		
}
