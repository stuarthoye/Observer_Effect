using UnityEngine;
using System.Collections;

public class Red_Particle : MonoBehaviour {
	public float distance;
	public bool visible;
	public Color particle_color = Color.red;

	private Vector3 start;
	private Vector3 current;
	private Vector3 end;
	private float scalar;

	void Start () {
		gameObject.renderer.material.color = particle_color;
		start = GameObject.Find ("Right_End").transform.position;
		current = transform.position = start;
		end = GameObject.Find("Left_End").transform.position;
		scalar = 0;
	}

	void FixedUpdate(){
		visible = renderer.isVisible;
		if (visible) {
			Oscillate ();
		}
	}

	void Oscillate (){
		scalar += Time.deltaTime;
		transform.position = Vector3.Lerp (start, end, scalar);
		if (transform.position == end) {
			Vector3 temp = start;
			start = end;
			end = temp;
			scalar = 0;
		}
	}
}

