using UnityEngine;
using System.Collections;

public class P6_Green_Particle : P0_Compound_Particle {
	private Vector3 focal_point;
	//---------------------------------------
	
	// Use this for initialization
	void Start () {
		focal_point = (transform.forward * distance);
	}
	
	void FixedUpdate () {
		visible = renderer.isVisible;
		if (visible) {
			decay_timer -= Time.deltaTime;
			if (decay_timer > 0) {
				Rotate();
			} else {
				Decay ();
			}
		}
	}

	void Rotate(){
		transform.RotateAround (focal_point, transform.up, rotation_amt * speed * Time.deltaTime);
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
