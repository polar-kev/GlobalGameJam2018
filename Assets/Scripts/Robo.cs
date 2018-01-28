using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour {

	public GameObject robotArm;
	public Transform rightArmSpawn;
	public Transform rightHandTarget;

	public float delay = 2f;
    public float thrust = 100f;
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
			print ("Cooldown Complete");
			shotArm = false;
		}
	}

	void ShootArm(){
        GameObject newArm = GameObject.Instantiate(robotArm);
        newArm.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * thrust);
		shotArm = true;
	}
}
