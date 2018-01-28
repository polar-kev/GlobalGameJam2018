using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileArm : MonoBehaviour {

    float elapsedTime;
    float delay = 5f;
	// Use this for initialization
	void Start () {
        elapsedTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime = Time.deltaTime;
		
        if(elapsedTime >= delay){
            Destroy(gameObject);
        }
	}
}
