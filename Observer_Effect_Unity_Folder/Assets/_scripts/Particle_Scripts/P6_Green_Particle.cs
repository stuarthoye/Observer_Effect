using UnityEngine;
using System.Collections;

public class P6_Green_Particle : MonoBehaviour {
	// Use this for initialization
	public float distance = 5;
	public float period = 5;
	public float rotation_amt = 20;
	public float speed = 5;
	public bool visible;
	//---------------------------------------
	private Messenger messenger;
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

	// Audio & Particle System triggering.
	void OnBecameVisible() {
		audio.Play();
		transform.particleSystem.Play();
	}
	
	void OnBecameInvisible() {
		audio.Pause();
		transform.particleSystem.Clear();
		transform.particleSystem.Stop();
	}
}
