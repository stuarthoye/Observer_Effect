﻿using UnityEngine;
using System.Collections;

public class P4_Purple_Particle : MonoBehaviour {
	public float distance = 5;
	public bool visible;

	private Vector3 start;
	private Vector3 end;
	private float scalar = 0;
	private float sine = 0;
	private bool outgoing = true;

	// Initializes start & endpoints
	// ***
	// Need to do more work here, and calculate endpoint based on
	// parents' movements (maybe this calc occurs during collision).
	// Sine_rate should be calculated in terms of the distance - 
	// the particle should probably come to rest at the endpoint.
	// Not huge problem since lerp, but will look nicer.
	// ***
	void Start () {
		end = transform.position - (transform.forward * distance);
		start = transform.position;
	}

	// Test whether particle is observed & call movement function if so.
	void FixedUpdate()
	{
		visible = renderer.isVisible;
		if (visible)
		{
            Oscillate();
		}
	}

	// This particle needs to move in a sinusoidal way along an axis.
	// The movement along the principle direction is handled by lerping.
	// Orthogonal movement (sinusoidal up-down) is handled by adding the .Sin() to its transform.
	void Oscillate (){
		scalar += Time.deltaTime;
		sine += (10 * Time.deltaTime);

		if (outgoing){
			transform.position = Vector3.Lerp (start, end, scalar);
		} else {
			transform.position = Vector3.Lerp (end, start, scalar);
		}
		if (transform.position == end || transform.position == start){
			outgoing = !outgoing;
			scalar = 0;
		}
		transform.position += new Vector3 (0, Mathf.Sin (sine), 0);
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

