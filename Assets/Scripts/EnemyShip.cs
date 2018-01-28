using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

	public float speedMin;
	public float speedMax;
	public float delay = 20f;
	public GameObject explosion;

	private float elapsedTime;

	void Start() {
		float speed = Random.Range (speedMin,speedMax);
		gameObject.GetComponent<Rigidbody> ().velocity = -transform.right*speed;
	}

	void Update(){
		elapsedTime += Time.deltaTime;
		if(Time.deltaTime>=delay){
			Destroy (gameObject);
		}

		if(transform.position.x <= -30f){
			Destroy (gameObject);
		}
			
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			Instantiate (explosion, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
