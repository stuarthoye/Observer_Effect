using UnityEngine;
using System.Collections;

public class P2_Blue_Particle : P0_Basic_Particle {
	private Vector3 focal_point;
	private float circum;
	private float angle;
	//---------------------------------------

	// Use this for initialization
	void Start () {
		focal_point = transform.localPosition + (transform.forward * distance);
		speed = 360 / period;
	}

	void FixedUpdate () {
		visible = renderer.isVisible;
        if (visible)
        {
            Rotate();
        }
	}

	void Rotate(){
		angle = speed * Time.deltaTime;
		transform.RotateAround (focal_point, transform.up, angle);
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
