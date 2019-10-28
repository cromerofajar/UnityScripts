using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzar : MonoBehaviour {

	public float posicionini=0f;
	public float posicionfin=45f;
	public float fuerzagolpe=1000f;
	public float fdamper=150f;
	HingeJoint hinge;
	public string inputName;
	void Start () {
		hinge = GetComponent<HingeJoint>();
		hinge.useSpring=true;
	}
	
	void Update () {
		JointSpring spring=new JointSpring();
		spring.spring = fuerzagolpe;
		spring.damper = fdamper;
		if (Input.GetAxis(inputName)==1){
			spring.targetPosition=posicionini;
		}
		else{
			spring.targetPosition=posicionfin;
		}
		hinge.spring = spring;
		hinge.useLimits=true;
	}
}
