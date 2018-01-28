using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboHandController : MonoBehaviour {

	public Transform LeftHandTarget;
	public Transform RightHandTarget;

	public Transform lhStartPos;
	public Transform rhStartPos;

	public GameObject leftController;
	public GameObject rightController;


	//x-direction modifiers
	float m_x = 935f;
	float b_x = -185f;

	//y-direction modifiers
	float m_y = 1400f;
	float b_y = -1764f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		/*
		//Get distance between controller and activation zone
		float LHDistance = Mathf.Clamp(Vector3.Distance (leftController.transform.position, lhStartPos.position),0.2f,0.4f);
		float RHDistance = Mathf.Clamp(Vector3.Distance (rightController.transform.position, rhStartPos.pos),0.2f,0.4f);

		LeftHandTarget.position = new Vector3 (lhStartPos.position.x* m_x + b_x, lhStartPos.position.y*m_y+b_y, lhStartPos.position.z);
		RightHandTarget.position = new Vector3 (rhStartPos.position.x * m_x + b_x, rhStartPos.position.y * m_y + b_y, rhStartPos.position.z);
		*/
	}
}
