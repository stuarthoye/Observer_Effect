﻿using UnityEngine;
using System.Collections;

public class Blue_Particle : MonoBehaviour {
	public bool visible;
	public float distance = 3;
	public float rotation_amt = 20;
	public float speed = 10;
	public Color particle_color = Color.blue;

	private Vector3 focal_point;
	// Use this for initialization
	void Start () {
		gameObject.renderer.material.color = particle_color;
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
