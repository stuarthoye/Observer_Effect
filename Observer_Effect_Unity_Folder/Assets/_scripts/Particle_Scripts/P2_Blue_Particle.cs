using UnityEngine;
using System.Collections;

public class P2_Blue_Particle : P0_Basic_Particle {
	private Vector3 focal_point;
	//---------------------------------------

	// Use this for initialization
	void Start () {
		distance = 5;
		period = 5;
		speed = 5;
		rotation_amt = 20;
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

	void OnTriggerExit(){
		collider.enabled = true;
	}

	// Audio & Particle System triggering.
	void OnBecameVisible()
	{
		audio.Play();
		transform.particleSystem.Play();
	}
	
	void OnBecameInvisible()
	{
		audio.Pause();
		transform.particleSystem.Clear();
		transform.particleSystem.Stop();
	}
}
