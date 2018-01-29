using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileArm : MonoBehaviour {

    float elapsedTime;
    float delay = 2f;
	// Use this for initialization
	void Start () {
        elapsedTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;

		gameObject.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.right * Robo.thrust);

        if(elapsedTime >= delay){
            Destroy(gameObject);
        }
	}
}
