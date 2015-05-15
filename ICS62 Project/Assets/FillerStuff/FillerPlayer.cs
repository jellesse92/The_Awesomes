using UnityEngine;
using System.Collections;

public class FillerPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHoriz = Input.GetAxis("Horizontal");
		float moveV = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHoriz, 0.0f,moveV);
		GetComponent<Rigidbody>().AddForce(movement * 1000f * Time.deltaTime);
	}
}
