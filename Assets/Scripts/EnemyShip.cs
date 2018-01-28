using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

	public float speedMin;
	public float speedMax;
	public float delay = 20f;
	public Transform target;
	public float speed;
	public float rotationSpeed = 100f;

	public GameObject explosion;
	public GameObject[] junk;

	private float elapsedTime;
	private  GameController gameController;

	void Start() {
		speed = Random.Range (speedMin,speedMax);
		gameObject.GetComponent<Rigidbody> ().velocity = -transform.right*speed;
		gameController = GameObject.FindObjectOfType<GameController> ();

	}

	void Update(){
		elapsedTime += Time.deltaTime;

		if (Time.deltaTime >= delay) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			Instantiate (explosion, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
			Destroy (gameObject);

			//create junk
			for(int i=0;i<=Random.Range(1,junk.Length);i++){
				Instantiate (junk[Random.Range(0,junk.Length-1)], new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);	
			}
		}

		if(other.CompareTag("Boundary")){
			gameController.addScoreValue (-10);
			Destroy (gameObject);
		}
	}
}
