using System.Collections;
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


    //x-direction modifiers
    public float m_x = 935f;
    public float b_x = -185f;

    //y-direction modifiers
    public float m_y = 1400f;
    public float b_y = -1764f;

    public float time = 2f;

    public  float power = 1f;
    public float modifier = 1f;
    public float offset = 1f;

	// Use this for initialization
	void Start () {
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
            

        /*
		//Change robot arm IK target positions
		LeftHandTarget.position = Mathf.Lerp(leftHandTarget.position, new Vector3 (lhStartPos.position.x* m_x + b_x, lhStartPos.position.y*m_y+b_y, lhStartPos.position.z*zMod),time);
		RightHandTarget.position = new Vector3 (rhStartPos.position.x * m_x + b_x, rhStartPos.position.y * m_y + b_y, rhStartPos.position.z*zMod);
        */

        //Change robot arm IK target positions
        leftHandTarget.position = new Vector3(modifier*Mathf.Pow(lhStartPos.position.x, power)+offset, lhStartPos.position.y, lhStartPos.position.z * zMod);
        rightHandTarget.position = new Vector3(modifier * Mathf.Pow(rhStartPos.position.x, power)+offset, rhStartPos.position.y, rhStartPos.position.z * zMod);


        print("Left:" + leftHandTarget.position);
        print("Right:" + rightHandTarget.position);
        


    }
}
