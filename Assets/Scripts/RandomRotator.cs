using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
	public float tumble = 5.0f;
	public Vector2 nullify = new Vector2(1.0f,1.0f);//Use values of 0 or 1 to remove or allow rotation along x or y axes respectively

	// Use this for initialization
	void Start () {
		Vector3 rotation = new Vector3 (
			Random.Range(-1.0f,1.0f) * nullify.x * tumble,
			Random.Range(-1.0f,1.0f) * nullify.y * tumble,
			Random.Range(-1.0f,1.0f) * nullify.y * tumble
		);
		gameObject.GetComponent<Rigidbody> ().angularVelocity = rotation;
	}
}
