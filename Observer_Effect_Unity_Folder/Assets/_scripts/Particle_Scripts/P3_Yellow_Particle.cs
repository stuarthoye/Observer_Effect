using UnityEngine;
using System.Collections;

public class P3_Yellow_Particle : MonoBehaviour {
	public float swell_amt = 5;
	public float period = 5;
	public bool visible;
	//---------------------------------------
	private float swell_process = 0;
	private bool swelling = true;
	//---------------------------------------

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		visible = renderer.isVisible;
		if (visible)
		{
			Swell();
		}
	}

	void Swell(){
		float scale_amt = (Time.deltaTime * swell_amt);
		swell_process += Time.deltaTime;

		if (swelling) {
			transform.localScale += new Vector3(scale_amt, scale_amt, scale_amt);
		} else {
			transform.localScale -= new Vector3(scale_amt, scale_amt, scale_amt);
		}
		if (swell_process > period){
			swelling = !swelling;
			swell_process = 0;
		}
	}

	void OnTriggerEnter(Collider other){
		switch (other.tag) {
		case "Red":
		case "Blue":
			break;
		default:
			gameObject.collider.enabled = false;
			other.collider.enabled = false;

			string full_msg = this.tag + " " + other.tag;
			gameObject.SendMessageUpwards ("Spawn", full_msg);

			Destroy (other.gameObject);
			Destroy (gameObject);
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