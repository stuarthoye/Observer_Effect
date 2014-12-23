using UnityEngine;
using System.Collections;

public class P3_Yellow_Particle : MonoBehaviour {
	public bool visible;
	public float period = 5.0f;

	private bool swelling = true;

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
		float scale_amt = Time.deltaTime;
		if (swelling) {
			transform.localScale += new Vector3(scale_amt, scale_amt, scale_amt);
			period -= Time.deltaTime;
		} else {
			transform.localScale -= new Vector3(scale_amt, scale_amt, scale_amt);
			period += Time.deltaTime;
		}
		if (period < 0) {
			swelling = false;
		} else if (period > 5) {
			swelling = true;
		}
	}
}