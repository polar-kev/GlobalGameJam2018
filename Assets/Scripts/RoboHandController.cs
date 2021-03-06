﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboHandController : MonoBehaviour {

	public Transform leftHandTarget;
	public Transform rightHandTarget;

	public Transform lhStartPos;
	public Transform rhStartPos;

	public Transform leftController;
	public Transform rightController;

    public float fwdMin;
    public float fwdMax;

    public float upMin;
    public float upMax;

    public float zMod = 1f;

    public float time = 2f;

    public  float power = 1f;
    public float modifier = 1f;
    public float offset = 1f;

    public float Ypower = 1f;
    public float Ymodifier = 1f;
    public float Yoffset = 1f;

    public float Zpower = 1f;
    public float Zmodifier = 1f;
    public float Zoffset = 1f;

	private float chargeTimer = 0;
	private float punchTimer = 0;
	public float timeToPunch = 5f;
	public float chargeReq = 4f;
	public float punchWindow = 4f;
	public float chargeOffset = 1f;
	private bool charged;
    private bool punched;

    private Robo player;

    // Use this for initialization
    void Start () {
		charged = false;
        punched = false;

        player = FindObjectOfType<Robo>();
	}
	
	// Update is called once per frame
	void Update () {
        
		//get left hand controller position
		lhStartPos.position = new Vector3 (Mathf.Clamp(leftController.position.x, fwdMin, fwdMax),
			Mathf.Clamp(leftController.position.y, upMin, upMax),
			leftController.position.z);

		//get right hand controller position
		rhStartPos.position = new Vector3(Mathf.Clamp(rightController.position.x, fwdMin, fwdMax),
			Mathf.Clamp(rightController.position.y,upMin,upMax),
			rightController.position.z);

        //Change robot arm IK target positions
        leftHandTarget.position = new Vector3(modifier*Mathf.Pow(lhStartPos.position.x, power)+offset, Ymodifier * Mathf.Pow(lhStartPos.position.y, Ypower) + Yoffset, Zmodifier * Mathf.Pow(lhStartPos.position.z, Zpower) + Zoffset);
        rightHandTarget.position = new Vector3(modifier * Mathf.Pow(rhStartPos.position.x, power)+offset, Ymodifier * Mathf.Pow(rhStartPos.position.y, Ypower) + Yoffset, Zmodifier * Mathf.Pow(rhStartPos.position.z, Zpower) + Zoffset);
    	
        //Add controller rotation
		leftHandTarget.rotation = leftController.rotation;
		rightHandTarget.rotation = rightController.rotation;

		//Player brings both hands back to charge
		if(!charged && (lhStartPos.position.x<= 0.87f && (rhStartPos.position.x <= 0.87f))){
			chargeTimer += Time.deltaTime;
			if(chargeTimer >= chargeReq){
				charged = true;
				print ("charged");
			}
		}
		else{
			chargeTimer = 0;
		}

		//Player is charged up and must punch before losing charge
		if(charged){
			if ((lhStartPos.position.x >= 1.2f) && (rhStartPos.position.x >= 1.2f)) {
				print ("punching");
                punched = true;
                //Move player
                //player.MoveRobo();
			}
		}

        print("RH_x: " + lhStartPos.position.x);
        print("LH_x: " + rhStartPos.position.x);
    }
}
