using UnityEngine;
using System.Collections;

public class P2_Blue_Particle : P0_Basic_Particle {
	private Vector3 focal_point;
	//---------------------------------------

	// Use this for initialization
	void Start () {
		focal_point = (transform.forward * distance);
	}

	void FixedUpdate () {
		visible = renderer.isVisible;
        if (visible)
        {
            Rotate();
        }
	}

	void Rotate(){
		transform.RotateAround (focal_point, transform.up, rotation_amt * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		switch (other.tag) {
		case "Red": 
			break;
		default:
			messenger.Set(transform, other.gameObject.transform);
			gameObject.SendMessageUpwards ("Collide", messenger);
			break;
		}
	}
}
