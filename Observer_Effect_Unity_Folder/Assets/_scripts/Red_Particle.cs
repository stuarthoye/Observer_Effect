using UnityEngine;
using System.Collections;

public class Red_Particle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.renderer.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		Oscillate ();
	}

	void Oscillate (){
		Transform focal_point = transform.Find ("Focal_Point");
		//focal_point.transform = new Vector3.zero;
		
	}
}
