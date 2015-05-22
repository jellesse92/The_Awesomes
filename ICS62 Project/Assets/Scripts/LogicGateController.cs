using UnityEngine;
using System.Collections;

public class LogicGateController : MonoBehaviour {
	LogicSetController lsc;

	//Iris colors
	MeshRenderer IrisMesh;						//Gets mesh renderer of iris to change
	public Material FalseMat;					//Changes iris color if answer was False
	public Material TrueMat;					//Changes iris color if answer was True
	Material DefaultMat;						//Sets iris to default color

	// Use this for initialization
	void Awake () {
		lsc = transform.parent.parent.GetComponent<LogicSetController>();	//Would use .root if we weren't going to child this to the track
		IrisMesh = transform.GetComponent<MeshRenderer>();
		DefaultMat = IrisMesh.material;
	}

	void OnBecameVisible(){
		lsc.ActivateLogicSet();
	}

	void OnTriggerEnter(Collider obj){
		if (obj.tag == "Player")
			IrisMesh.material = FalseMat;
	}

	void OnTriggerExit(Collider obj){
		if (obj.tag == "Player")
			IrisMesh.material = DefaultMat;
	}

}
