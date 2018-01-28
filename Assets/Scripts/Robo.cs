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

	private float elapsedTime;
	private bool shotArm;

	// Use this for initialization
	void Start () {
		armThrust = thrust;
		shotArm = false;
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
	}

	void ShootArm(){
		GameObject newArm = Instantiate(robotArm, rightArmSpawn.position, Quaternion.identity);
        newArm.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * thrust);
	}
}
