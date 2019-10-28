using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzar : MonoBehaviour {

	//Posicion unicial de la pala.
	public float posicionini=0f;
	//Posicion maxima a la que puede llegar la pala.
	public float posicionfin=45f;
	//Velocidad de la pala para realizar la animacion.
	public float fuerzagolpe=1000f;
	//Velocidad al que regresa de la animacion.
	public float fdamper=150f;
	//Punto sobre el que se realizar el giro del eje para el movimiento.
	HingeJoint hinge;
	//Nombre del input que realiza la accion.
	public string inputName;
	
	void Start () {
		//Localiza el eje sobre el que realizar las acciones
		hinge = GetComponent<HingeJoint>();
		hinge.useSpring=true;
	}
	
	void Update () {
		//Realiza los movimientos con respecto al eje
		JointSpring spring=new JointSpring();
		//Asigna la velocidad de realizar la animacion y de regreso de la animacion
		spring.spring = fuerzagolpe;
		spring.damper = fdamper;
		//Comprueba que este pulsada o no la tecla en caso de estar pulsada mueve la pieza con respecto al eje
		// en caso no estar pulsado regresa a su posicion
		if (Input.GetAxis(inputName)==1){
			spring.targetPosition=posicionini;
		}
		else{
			spring.targetPosition=posicionfin;
		}
		//Vuelve a localizar el eje para comprobar la rotacion y si alcanzo o no el limite establecido
		hinge.spring = spring;
		hinge.useLimits=true;
	}
}
