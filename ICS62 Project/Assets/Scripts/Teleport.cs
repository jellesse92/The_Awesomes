using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player"){
			other.transform.position = GameObject.Find("Portal").transform.position;
		}
	}
}
