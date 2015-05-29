using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	//Game Logic
	GameController gc;
	// Use this for initialization
	void Start () {
		gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		print ("Started");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider obj){
		print ("hi");
		if (obj.gameObject.CompareTag("Player")) {
			if (gameObject.tag == "Break") {
				gc.playerVar = gc.breakCondition;
				gameObject.transform.parent.gameObject.SetActive (false);
			} 
			else if (gameObject.tag == "PlusEQ") {
				gc.playerVar += 1;
				gameObject.transform.parent.gameObject.SetActive (false);
			}
			else if (gameObject.tag == "MinusEQ") {
				gc.playerVar -= 1;
				gameObject.transform.parent.gameObject.SetActive (false);
			}
		}
	}
}
