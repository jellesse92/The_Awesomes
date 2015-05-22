using UnityEngine;
using System.Collections;

public class LogicGateController : MonoBehaviour {
	LogicSetController lsc;

	//Iris colors
	MeshRenderer IrisMesh;						//Gets mesh renderer of iris to change
	public Material FalseMat;					//Changes iris color if answer was False
	public Material TrueMat;					//Changes iris color if answer was True
	Material DefaultMat;						//Sets iris to default color

	bool booleanState = false;					//Depends if entering gate is false or true answer
	int selfIndex;								//Stores index iris is supposed to represent

	// Use this for initialization
	void Awake () {
		lsc = transform.parent.parent.GetComponent<LogicSetController>();	//Would use .root if we weren't going to child this to the track
		IrisMesh = transform.GetComponent<MeshRenderer>();
		DefaultMat = IrisMesh.material;
		selfIndex = (int)char.GetNumericValue(transform.name[transform.name.Length-1]);
	}

	void OnBecameVisible(){
		lsc.ActivateLogicSet();
		booleanState = lsc.Answers[selfIndex];
	}

	void OnTriggerEnter(Collider obj){
		if (obj.tag == "Player")
			if (booleanState)
				IrisMesh.material = TrueMat;
			else
				IrisMesh.material = FalseMat;
	}

	void OnTriggerExit(Collider obj){
		if (obj.tag == "Player"){
			IrisMesh.material = DefaultMat;
			lsc.AnswerQuestion(booleanState);
		}
	}

}
