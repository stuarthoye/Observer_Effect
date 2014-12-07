using UnityEngine;
using System.Collections;

public class Blue_Particle : MonoBehaviour {
	public bool visible;
	public float distance;
	public float rotation_amt = 20;
	public float speed = 10;
	public Color particle_color = Color.blue;

	// Use this for initialization
	void Start () {
		gameObject.renderer.material.color = particle_color;
	}

	void FixedUpdate () {
		visible = renderer.isVisible;
		if (visible) {
			Move ();
		}
	}

	void Move(){
		Transform focal_point = transform.Find ("Focal_Point");
		transform.RotateAround (focal_point.position, Vector3.up, rotation_amt * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision) {
		Collider other = collision.collider;
		if (gameObject.renderer.material.color == other.renderer.material.color) {
			print (other.renderer.material.color);
		}
	}
}
