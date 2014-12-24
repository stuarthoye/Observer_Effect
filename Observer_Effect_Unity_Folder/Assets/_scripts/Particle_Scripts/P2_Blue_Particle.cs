using UnityEngine;
using System.Collections;

public class P2_Blue_Particle : MonoBehaviour {
	public float distance = 5;
	public float period = 5;
	public float rotation_amt = 20;
	public float speed = 5;
	public bool visible;
	//---------------------------------------
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

	/*
	void OnCollisionEnter(Collision collision) {
		Collider other = collision.collider;
		if (gameObject.renderer.material.color == other.renderer.material.color) {
			print (other.renderer.material.color);
		}
	}
	*/

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
