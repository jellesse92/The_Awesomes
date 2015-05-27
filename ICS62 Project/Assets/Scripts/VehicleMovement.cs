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
	
	void Start(){
		rb = GetComponent<Rigidbody>();
	}
	


	void Update(){
		RaycastHit rcHit;
		float newPosition = transform.position.y; 
		if (Physics.Raycast(transform.position, Vector3.down, out rcHit)){
			float proportionalHeight = (hoverDist - rcHit.distance)/hoverDist;
			Vector3 appliedForce = Vector2.up * proportionalHeight * hoverForce;
			rb.AddForce(appliedForce, ForceMode.Acceleration);
			//groundDist = rcHit.distance;
			//transform.rotation = Quaternion.FromToRotation(Vector3.up, rcHit.normal);
			//newPosition = (newPosition - groundDist) + 1;

		}
		transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);

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
