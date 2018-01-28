using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboHandController : MonoBehaviour {

	public Transform LeftHandTarget;
	public Transform RightHandTarget;

	public Transform lhStartPos;
	public Transform rhStartPos;

	public Transform leftController;
	public Transform rightController;

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
		//get left hand controller position
		lhStartPos.position = new Vector3 (Mathf.Clamp(leftController.position.x,0.2f,0.2f),
			Mathf.Clamp(leftController.position.y,0.2f,0.2f),
			leftController.position.y);

		//get right hand controller position
		rhStartPos.position = new Vector3 (Mathf.Clamp(rightController.position.x,0.2f,0.2f),
			Mathf.Clamp(rightController.position.y,0.2f,0.2f),
			rightController.position.y);

		//Change robot arm IK target positions
		LeftHandTarget.position = new Vector3 (lhStartPos.position.x* m_x + b_x, lhStartPos.position.y*m_y+b_y, lhStartPos.position.z);
		RightHandTarget.position = new Vector3 (rhStartPos.position.x * m_x + b_x, rhStartPos.position.y * m_y + b_y, rhStartPos.position.z);

	}
}
