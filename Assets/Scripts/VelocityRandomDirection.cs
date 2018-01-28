using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityRandomDirection : MonoBehaviour {
	public float speed = 5.0f;

	// Use this for initialization
	void Start () {
		Vector3 vel = new Vector3 (
			Random.Range(-1.0f,1.0f)  * speed,
			Random.Range(-1.0f,1.0f)  * speed,
			Random.Range(-1.0f,1.0f)  * speed
		);
		gameObject.GetComponent<Rigidbody> ().velocity = vel;
	}
}
