using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	//Game Logic
	GameController gc;
	// Use this for initialization
	void Start () {
		gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider obj){
		if (obj.tag == "Break") {
			gc.playerVar = gc.breakCondition;
			gameObject.SetActive (false);
		} 
		if (obj.tag == "PlusEQ") {
			gc.playerVar += 1;
			gameObject.SetActive (false);
		}
		if (obj.tag == "MinusEQ") {
			gc.playerVar -=1;
			gameObject.SetActive (false);
		}
	}

}
