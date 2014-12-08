using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {
	public float speed = 6.0f;
	public float sensitivity = 15.0f; // be nice to tie this to a sensitivity setting

	//private Vector3 move_direction = Vector3.zero;
	private Vector3 rotation = Vector3.zero;


	// Use this for initialization
	void Start () {

	}

	void Update () {

        rotation.x += Input.GetAxis("Mouse X") * sensitivity;
        rotation.y += Input.GetAxis("Mouse Y") * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(rotation.x, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.position += transform.forward * speed * Input.GetAxis("Vertical");
        transform.position += transform.right * speed * Input.GetAxis("Horizontal");
        
        /*
        CharacterController controller = GetComponent<CharacterController>();
		Camera camera = GetComponent<Camera> ();
		Transform head = transform.Find ("Head");

		// Calculate rotation
		// -1 < mouse_x & mouse_y  < 1
		float mouse_x = Input.GetAxis ("Mouse X");
		float mouse_y = Input.GetAxis ("Mouse Y");
		mouse_y *= -1;									// otherwise look is inverted

		// Use Mathf.Clamp to limit rotation.
		// Issue: x-rotation should be limited to 0 - 50, 320 - 360.  Logic?
		// Rotate camera 180 dgs around y axis?

		Vector3 head_rotation = new Vector3 (mouse_y, 0, 0);
		Vector3 body_rotation = new Vector3 (0, mouse_x, 0);
		body_rotation *= sensitivity;
		head_rotation *= sensitivity;

		transform.Rotate( body_rotation, Space.Self );
		head.Rotate (head_rotation, Space.Self);

		// Calculate keyboard movement
		float move_orth = Input.GetAxis ("Horizontal");
		float move_front = Input.GetAxis ("Vertical");
		move_direction = new Vector3 (move_orth, 0, move_front);

		move_direction = transform.TransformDirection(move_direction);
		move_direction *= speed;
		move_direction.y = 0;
	
		controller.Move (move_direction);
        */
	}

	void OnTriggerEnter(Collider other) {

	}
}
