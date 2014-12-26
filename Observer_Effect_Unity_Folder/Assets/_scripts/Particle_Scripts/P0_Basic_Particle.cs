using UnityEngine;
using System.Collections;

public class P0_Basic_Particle : MonoBehaviour {
	public float period = 5;
	public float speed = 5;
	public float distance = 5;
	public float swell_amt = 1;
	public float rotation_amt = 20;

	public bool visible;

	protected Messenger messenger;

	
	void OnTriggerExit(){
		collider.enabled = true;
	}
	
	// Audio & Particle System triggering.
	void OnBecameVisible()
	{
		audio.Play();
		transform.particleSystem.Play();
	}
	
	// We clear the ParticleSystem to remove the particles still in the player's view
	void OnBecameInvisible()
	{
		audio.Pause();
		transform.particleSystem.Clear();
		transform.particleSystem.Stop();
	}
}
