﻿using UnityEngine;
using System.Collections;

public class Blue_Particle : MonoBehaviour {
	public bool visible;
	public float distance;
	public float rotation_amt = 20;
	public float speed = 10;

	// Use this for initialization
	void Start () {
		gameObject.renderer.material.color = Color.blue;
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
}