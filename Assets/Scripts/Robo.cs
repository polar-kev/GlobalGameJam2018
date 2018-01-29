using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour {

	public GameObject robotArm;
	public Transform rightArmSpawn;
	public Transform rightHandTarget;

	public float cooldown = 3f;
   	public static float thrust = 100f;
	public float armThrust = 100f;
	public string shootRightArm;
	public Transform sweetSpot;
	public float yvel = 0f;
	public float jumpTime = 0;
	public float jumpTimeMax = 7f;
	private float upForce = 10f;

	private float elapsedTime;
	private bool shotArm;
	private GameObject cameraRig;
	private float startY;
	private bool inAir = false;
	private bool canJump = true;


	// Use this for initialization
	void Start () {
		armThrust = thrust;
		shotArm = false;
		cameraRig = GameObject.FindWithTag ("CameraRig");
		startY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if(!shotArm && (Input.GetButton(shootRightArm) || Input.GetButton ("Fire1"))){
			ShootArm ();
			shotArm = true;
			elapsedTime = 0;
		}
		if(shotArm && elapsedTime >= cooldown){
			print ("Cooldown Complete");
			shotArm = false;
		}

		if(Input.GetButton("Menu")){
			print ("Menu Button Working");
		}

		if(Input.GetButton("Fire2")){
			//MoveRobo ();
		}

		transform.Translate (new Vector3 (0,yvel*Time.deltaTime,0));
		if(yvel!= 0){
			jumpTime += Time.deltaTime;
			if(jumpTime >= jumpTimeMax/2 && !inAir){
				yvel *= -1;
				inAir = true;
			}
			if(jumpTime >= jumpTimeMax){yvel = 0;}
		}
			

	}

	void ShootArm(){
		GameObject newArm = Instantiate(robotArm, rightArmSpawn.position, Quaternion.identity);
        newArm.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * thrust);
	}

	void ResetPosition(){
		cameraRig.transform.position = sweetSpot.position;
	}

    public void MoveRobo()
	{
		if(canJump){
			yvel = 5f;
			jumpTime = 0;
			inAir = false;
		}

    }

}
