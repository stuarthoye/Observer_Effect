using UnityEngine;
using System.Collections;

public class Red_Particle : MonoBehaviour {
	public Transform start;
	public Transform end;

	private float time;

	// Use this for initialization
	void Start () {
		gameObject.renderer.material.color = Color.red;
		time = Time.time;
		start = gameObject.transform;
		end = transform.Find ("Focal_Point").transform;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
	}

	void FixedUpdate(){
		Oscillate ();
	}

	void Oscillate (){
		/*
		Transform focal_point = transform.Find ("Focal_Point");
		//float sin = Mathf.Sin(time);
		//sin = Mathf.Abs(sin);
		transform.position = Vector3.Lerp (start.transform.position, end.transform.forward, 0.0f * Time.deltaTime);
		*/

		Vector3 objective = transform.forward;
	}
		
}

