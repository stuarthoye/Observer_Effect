﻿using UnityEngine;
using System.Collections;

public class P5_Orange_Particle : P0_Compound_Particle {
	private Vector3 start;
	private Vector3 end;
	private float scalar = 0;
	private int counter = 0;
	private bool outgoing = true;
	//---------------------------------------

	// Use this for initialization
	void Start () {
		decay_timer = 3;
		swell_amt = 5;
		period = 5;
		end = transform.position - (transform.forward * distance);
		start = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		visible = renderer.isVisible;

		if (visible) {
			decay_timer -= Time.deltaTime;
			if (decay_timer > 0){
				Oscillate();
			} else {
				Decay ();
			}
		}
	}

	void Oscillate (){
		scalar += Time.deltaTime;
		float scale_amt = swell_amt * Time.deltaTime;
		
		if (outgoing){
			transform.position = Vector3.Lerp (start, end, scalar);
			transform.localScale += new Vector3(scale_amt, scale_amt, scale_amt);
		} else {
			transform.position = Vector3.Lerp (end, start, scalar);
			transform.localScale -= new Vector3(scale_amt, scale_amt, scale_amt);
		}
		if (transform.position == end || transform.position == start){
			outgoing = !outgoing;
			scalar = 0;
			if (transform.position == start){
				Update_Targets();
			}
		}
	}
	
	// This function rotates the particle once it reaches its endpoint.
	void Update_Targets(){
		counter++;
		if (counter == 3){
			counter = 0;
			transform.Rotate(270, 180, 0);
		} else {
			transform.Rotate (90, 90, 0);
		}
		end = transform.position - (transform.forward * distance);
		start = transform.position;
	}

	void OnTriggerEnter(Collider other){
		switch (other.tag) {
		case "Red":
		case "Blue":
		case "Yellow":
		case "Purple":
			break;
		default:
			messenger.Set(transform, other.gameObject.transform);
			gameObject.SendMessageUpwards ("Collide", messenger);
			break;
		}
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
