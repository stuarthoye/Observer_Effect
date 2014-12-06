using UnityEngine;
using System.Collections;

public class Entity_Controller : MonoBehaviour {
	public bool visible;
	public float distance;
	public float rotation_amt = 20;
	public float scalar = 20;
	public Transform focus;

	private float timer;
	
	void Start () {
		switch (tag) {
		case "Red":	
			gameObject.renderer.material.color = Color.red;
			break;
		case "Blue":
			gameObject.renderer.material.color = Color.blue;
			break;
		case "Black":
			gameObject.renderer.material.color = Color.black;
			break;
		case "Purple":
			gameObject.renderer.material.color = Color.magenta;
			break;
		}
	}

	void Update () {
		if (visible) {
			Move ();
		}
	}

	void Move(){
		switch (tag) {
		case "Red":	
			Oscillate();
			break;
		case "Blue":
			Rotate ();
			break;
		case "Black":
			gameObject.renderer.material.color = Color.black;
			break;
		case "Purple":
			gameObject.renderer.material.color = Color.magenta;
			break;
		}
	}

	void Rotate () {
		Transform focal_point = transform.Find ("Focal_Point");
		transform.RotateAround (focal_point.position, Vector3.up, rotation_amt * Time.deltaTime);
	}

	void Oscillate (){

	}
}
