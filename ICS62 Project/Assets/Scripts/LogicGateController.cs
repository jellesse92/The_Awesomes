using UnityEngine;
using System.Collections;

public class LogicGateController : MonoBehaviour {
	LogicSetController lsc;

	//Iris colors
	MeshRenderer IrisMesh;						//Gets mesh renderer of iris to change
	public Material FalseMat;					//Changes iris color if answer was False
	public Material TrueMat;					//Changes iris color if answer was True
	Material DefaultMat;						//Sets iris to default color
	
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
	}

	void OnTriggerEnter(Collider obj){
		if (obj.tag == "Player" && !lsc.sameLap)
			StartCoroutine("ColorChange");
	}

	//Delays gate resetting color back to default
	IEnumerator ColorChange(){
		if (lsc.Answers[selfIndex])
			IrisMesh.material = TrueMat;
		else
			IrisMesh.material = FalseMat;
		yield return new WaitForSeconds(3.0f);
		IrisMesh.material = DefaultMat;
	}

	void OnTriggerExit(Collider obj){
		if (obj.tag == "Player" && !lsc.sameLap){
			lsc.AnswerQuestion(selfIndex);
		}
	}

}
