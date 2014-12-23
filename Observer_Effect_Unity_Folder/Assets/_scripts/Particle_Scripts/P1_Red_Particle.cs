using UnityEngine;
using System.Collections;

public class P1_Red_Particle : MonoBehaviour {
	public float distance = 5;
	public bool visible;

	private Vector3 start;
	private Vector3 end;
	private float scalar = 0;
	private bool outgoing = true;

	void Start () {
		// start = transform.position - new Vector3 (distance, 0, 0);
		// end = transform.position + new Vector3 (distance, 0 , 0);
		end = transform.position - (transform.forward * distance);
		start = transform.position;
	}

    void FixedUpdate()
    {
        visible = renderer.isVisible;
        if (visible) {
			Oscillate();
        }
    }

	void Oscillate (){
		scalar += Time.deltaTime;
		if (outgoing){
			transform.position = Vector3.Lerp (start, end, scalar);
			if (transform.position == end) {
				outgoing = false;
				scalar = 0;
			}
		} else {
			transform.position = Vector3.Lerp (end, start, scalar);
			if (transform.position == start) {
				outgoing = true;
				scalar = 0;
				Update_Targets();
			}
		}
	}

	void Update_Targets(){
		transform.Rotate (90, 0, 0);
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

