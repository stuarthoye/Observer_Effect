using UnityEngine;
using System.Collections;

public class P3_Yellow_Particle : P0_Basic_Particle {
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
			messenger.Set(transform, other.gameObject.transform);
			gameObject.SendMessageUpwards ("Collide", messenger);
			break;
		}
	}

	void OnTriggerExit(){
		collider.enabled = true;
	}
}