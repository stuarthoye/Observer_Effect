using UnityEngine;
using System.Collections;

public class P4_Purple_Particle : P0_Compound_Particle {
	//---------------------------------------
	private Vector3 start;
	private Vector3 end;
	private float scalar = 0;
	private float sine = 0;
	private bool outgoing = true;
	//---------------------------------------

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

		if (visible) {
			decay_timer -= Time.deltaTime;
			if (decay_timer > 0) {
            	Oscillate();
			} else {
				Decay();
			}
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

	void OnTriggerEnter(Collider other){
		switch (other.tag) {
		case "Red":
		case "Blue":
		case "Yellow":
			break;
		default:
			messenger.Set(transform, other.gameObject.transform);
			gameObject.SendMessageUpwards ("Collide", messenger);
			break;
		}
	}	
}

