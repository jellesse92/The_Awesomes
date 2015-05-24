using UnityEngine;
using System.Collections;

public class VehicleMovement : MonoBehaviour {

	public float speed;
	public float turnSpeed; 
	//public float groundDist;
	private Rigidbody rb;
	private float groundDist;
	
	void Start(){
		rb = GetComponent<Rigidbody>();
	}
	


	void Update(){
		RaycastHit rcHit;
		float newPosition = transform.position.y; 
		if (Physics.Raycast(transform.position, Vector3.down, out rcHit)){
			groundDist = rcHit.distance;
			//transform.rotation = Quaternion.FromToRotation(Vector3.up, rcHit.normal);

			newPosition = (newPosition - groundDist) + 1;

		}
		transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);

		if (Input.GetKey(KeyCode.W)){
			transform.Translate(0.0f,0.0f, speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.A)){
			transform.Rotate (0.0f, -turnSpeed * Time.deltaTime, 0.0f);
		}
		if (Input.GetKey(KeyCode.D)){
			transform.Rotate (0.0f, turnSpeed * Time.deltaTime, 0.0f);
		}
		if (Input.GetKey(KeyCode.S))
			rb.AddForce (-(transform.forward) * (speed/4)*Time.deltaTime);
	}





}
