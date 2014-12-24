using UnityEngine;
using System.Collections;

public class P1_Red_Particle : MonoBehaviour {
	public float distance = 5;
	public bool visible;

	private Vector3 start;
	private Vector3 end;
	private float scalar = 0;
	private bool outgoing = true;
	private int counter = 0;

	// This sets the start & end coordinates the particle oscillates between.
	void Start () {
		end = transform.position - (transform.forward * distance);
		start = transform.position;
	}

	// Here, we test whether the particle is being observed.  If it is observed, we call the object's movement function.
    void FixedUpdate()
    {
        visible = renderer.isVisible;
        if (visible) {
			Oscillate();
        }
    }

	// This function handles the linear interpolation of the particle between two points.
	// .Lerp() takes three arguments, the first two being the start & end points.
	// The third argument tracks the portion of the interpolation completed.
	// When the particle returns to its start position, it rotates & updates its endpoint with Update_Targets();
	void Oscillate (){
		scalar += Time.deltaTime;

		if (outgoing){
			transform.position = Vector3.Lerp (start, end, scalar);
		} else {
			transform.position = Vector3.Lerp (end, start, scalar);
		}
		if (transform.position == end || transform.position == start){
			outgoing = !outgoing;
			scalar = 0;
			if (transform.position == start){
				Update_Targets();
			}
		}
	}

	// This function rotates the particle once it reaches its endpoint.
	void Update_Targets(){
		counter++;
		if (counter == 3){
			counter = 0;
			transform.Rotate(270, 180, 0);
		} else {
			transform.Rotate (90, 90, 0);
		}
		end = transform.position - (transform.forward * distance);
		start = transform.position;
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

