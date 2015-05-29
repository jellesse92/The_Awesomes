using UnityEngine;
using System.Collections;

public class VehicleMovement : MonoBehaviour {

	public float speed;
	public float strafe; 
	public float turnSpeed;
	public float hoverForce;
	public float hoverDist;
	private Rigidbody rb;
	private float groundDist;
	private bool track;
	void Start(){
		rb = GetComponent<Rigidbody>();
		track = false;
	}

	void FixedUpdate(){
		RaycastHit rcHit;
		if (Physics.Raycast(transform.position, Vector3.down, out rcHit)){
			float proportionalHeight = (hoverDist - rcHit.distance)/hoverDist;
			Vector3 appliedForce = Vector2.up * proportionalHeight * hoverForce;
			rb.AddForce(appliedForce);

			
		}

	}


	void Update(){
		if (track){
			if (Input.GetKey(KeyCode.W)){
				transform.Translate(0.0f,0.0f, speed * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.A)){
				transform.Translate(-strafe * Time.deltaTime, 0.0f, 0.0f);
			}
			if (Input.GetKey(KeyCode.D)){
				transform.Translate(strafe * Time.deltaTime, 0.0f, 0.0f);
			}
		}
		else{
			if (Input.GetKey(KeyCode.W)){
				transform.Translate(0.0f,0.0f, speed * Time.deltaTime);
				transform.Rotate(0.0f, -(turnSpeed) * Time.deltaTime, 0.0f);
			}
			if (Input.GetKey(KeyCode.A)){
				transform.Translate(-strafe * Time.deltaTime, 0.0f, 0.0f);
			}
			if (Input.GetKey(KeyCode.D)){
				transform.Translate(strafe * Time.deltaTime, 0.0f, 0.0f);
			}
			if (Input.GetKey(KeyCode.S))
				rb.AddForce (-(transform.forward) * (speed/4)*Time.deltaTime);
			}
	}





}
