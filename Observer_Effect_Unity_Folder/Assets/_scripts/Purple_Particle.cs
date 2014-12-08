using UnityEngine;
using System.Collections;

public class Purple_Particle : MonoBehaviour {
	public float distance = 3;
	public bool visible;
	public Color particle_color = Color.magenta;
    public float decay_time;
    private float countdown;
    public GameObject decays_into;

	private Vector3 start;
	private Vector3 current;
	private Vector3 end;
	private float scalar;

	void Start () {
		gameObject.renderer.material.color = particle_color;
		start = transform.position;
		end = transform.position + new Vector3(0, (distance * 2), 0);
		scalar = 0;
        countdown = decay_time;
	}

	void FixedUpdate()
	{
		visible = renderer.isVisible;
		if (visible)
		{
            countdown -= Time.deltaTime;
            Oscillate();
		}
        if (countdown<=0f)
        {
            Instantiate(decays_into, this.transform.position, Quaternion.identity);
            countdown = decay_time;
            Destroy(this.gameObject);
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

