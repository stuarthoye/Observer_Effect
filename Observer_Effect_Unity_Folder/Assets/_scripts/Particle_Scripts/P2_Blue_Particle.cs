using UnityEngine;
using System.Collections;

public class P2_Blue_Particle : MonoBehaviour {
	public bool visible;
	public float distance = 5;
	public float rotation_amt = 20;
	public float speed = 5;

	private Vector3 focal_point;
	// Use this for initialization
	void Start () {
		focal_point = transform.position + new Vector3 (distance, 0, 0);
	}

	void FixedUpdate () {
		visible = renderer.isVisible;
        if (visible)
        {
            Rotate();
        }
	}

	void Rotate(){
		transform.RotateAround (focal_point, Vector3.up, rotation_amt * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision) {
		Collider other = collision.collider;
		if (gameObject.renderer.material.color == other.renderer.material.color) {
			print (other.renderer.material.color);
		}
	}

    //audio triggering
    void OnBecameVisible()
    {
        audio.Play();
    }

    void OnBecameInvisible()
    {
        audio.Pause();
    }
}
