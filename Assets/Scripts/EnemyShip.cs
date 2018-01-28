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

	public AudioSource audioSource;

	private float elapsedTime;
	private  GameController gameController;
	private Vector3 randomPos;
	private float target_x = -30f;


	void Start() {
		speed = Random.Range (speedMin,speedMax);
		//Move enemies in a straight line
		//gameObject.GetComponent<Rigidbody> ().velocity = -transform.right*speed;
		gameController = GameObject.FindObjectOfType<GameController> ();

		//generate random target
		randomPos = new Vector3 (target_x, 
			Random.Range(GameController.EnemySpawn_yMin,GameController.EnemySpawn_yMax), 
			Random.Range(-GameController.EnemySpawn_zMax,GameController.EnemySpawn_zMax));
	}

	void Update(){
		elapsedTime += Time.deltaTime;

		if (Time.deltaTime >= delay) {
			Destroy (gameObject);
		}

		//move enemy to target
		gameObject.transform.position = Vector3.MoveTowards(transform.position, randomPos, speed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			Instantiate (explosion, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
			Destroy (gameObject);

			audioSource.Play ();

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
