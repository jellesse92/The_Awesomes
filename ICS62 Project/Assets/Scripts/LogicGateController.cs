using UnityEngine;
using System.Collections;

public class LogicGateController : MonoBehaviour {

	//For applying logic
	GameController gc;							//Accesses control script to get variable information

	//Iris colors
	MeshRenderer IrisMesh;						//Gets mesh renderer of iris to change
	public Material FalseMat;					//Changes iris color if answer was False
	public Material TrueMat;					//Changes iris color if answer was True
	Material DefaultMat;						//Sets iris to default color


	// Use this for initialization
	void Awake () {
		gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		IrisMesh = transform.GetComponent<MeshRenderer>();
		DefaultMat = IrisMesh.material;
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
