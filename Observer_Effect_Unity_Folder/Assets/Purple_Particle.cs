using UnityEngine;
using System.Collections;

public class Purple_Particle : MonoBehaviour {
	public float distance;
	public bool visible;
	public Color particle_color = Color.magenta;

	private Vector3 start;
	private Vector3 current;
	private Vector3 end;
	private float scalar;

	void Start () {
		distance = 3;
		gameObject.renderer.material.color = particle_color;
		start = transform.position - new Vector3(0, distance, 0);
		current = transform.position = start;
		end = transform.position + new Vector3(0, distance, 0);
		scalar = 0;
	}

	void FixedUpdate()
	{
		visible = renderer.isVisible;
		if (visible)
		{
			Oscillate();
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

