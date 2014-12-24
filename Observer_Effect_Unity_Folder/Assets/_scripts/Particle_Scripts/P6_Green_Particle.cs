using UnityEngine;
using System.Collections;

public class P6_Green_Particle : MonoBehaviour {
	public float period = 5;
	//---------------------------------------

	//---------------------------------------

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
