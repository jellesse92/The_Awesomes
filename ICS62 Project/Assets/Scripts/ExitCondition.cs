using UnityEngine;
using System.Collections;

public class ExitCondition : MonoBehaviour {
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player"){
			other.gameObject.GetComponent<VehicleMovement>().escape = true;
			GameObject.Find("EndGate").SetActive(false);
		}
	}
}
