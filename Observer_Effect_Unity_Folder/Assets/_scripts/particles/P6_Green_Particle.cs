using UnityEngine;
using System.Collections;

public class P6_Green_Particle : P0_Compound_Particle {
	private Transform focal_point;
	private Vector3 start_point;
	private float major_axis;
	private float minor_axis;
	private float angle;
	//---------------------------------------
	
	// Use this for initialization
	void Start () {
		major_axis = distance;
		minor_axis = distance / 2;
		start_point = transform.position;
		focal_point = transform;
		focal_point.position += (transform.forward * major_axis);

		speed = 360 / period;
		angle = 0;
	}
	
	void FixedUpdate () {
		visible = renderer.isVisible;
		if (visible) {
			actual_decay -= Time.deltaTime;
			if (actual_decay > 0) {
				Rotate();
				// if (transform.position == start_point){
					// Shift();
				// }
			} else {
				Decay ();
			}
		}
	}

	void Rotate() {
		// Need to figure out how to apply period to this movement.
		// Also need to figure out how to rotate elliptically on rotation.
		angle += (Time.deltaTime); 
		float x_scaled = focal_point.forward.x + (major_axis * Mathf.Cos (angle));
		float z_scaled = focal_point.right.z + (minor_axis * Mathf.Sin (angle));

		transform.position = new Vector3 (x_scaled, transform.position.y, z_scaled);

	}

	void Shift(){
	}

	void OnTriggerEnter(Collider other){
		switch (other.tag) {
		case "Red":
		case "Blue":
		case "Yellow":
		case "Purple":
		case "Orange":
			break;
		default:
			messenger.Set(transform, other.gameObject.transform);
			gameObject.SendMessageUpwards ("Collide", messenger);
			break;
		}
	}	
}
