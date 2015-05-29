using UnityEngine;
using System.Collections;

public class StartLineController : MonoBehaviour {

	GameController gc;						//Get access to game logic script

	// Use this for initialization
	void Awake () {
		gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	void OnTriggerExit(){
		gc.IncLap();
	}
}
