using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position;
	}
	
	// For follow cameras, procedural animation, and gathering last known state
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
