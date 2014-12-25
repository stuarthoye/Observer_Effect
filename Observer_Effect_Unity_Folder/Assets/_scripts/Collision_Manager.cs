using UnityEngine;
using System.Collections;

public struct Messenger{
	public GameObject first;
	public GameObject second;
	
	public void Set(Transform self, Transform other){
		first = self.gameObject;
		second = other.gameObject;
	}
}

public class Collision_Manager : MonoBehaviour {

	public GameObject Red;
	public GameObject Blue;
	public GameObject Yellow;
	public GameObject Purple;
	public GameObject Orange;
	public GameObject Green;
	//---------------------------------------
	private ArrayList particles = new ArrayList ();
	//---------------------------------------

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform){
			particles.Add(child);
		}
	}

	void Collide(Messenger messenger){
		string message = messenger.first.tag + " " + messenger.second.tag;

		switch (message) {
		case "Red Blue":
			Create(messenger.first, messenger.second, Purple);
			break;
		case "Red Yellow":
			Create(messenger.first, messenger.second, Orange);
			break;
		case "Red Purple":
			// make something pretty happen here
			break;
		case "Red Orange":
			// make something pretty happen here
			break;
		case "Red Green":
			// make something pretty happen here
			break;
		case "Blue Yellow":
			Create(messenger.first, messenger.second, Green);
			break;
		case "Blue Purple":
			// make something pretty happen here
			break;
		case "Blue Orange":
			// make something pretty happen here
			break;
		case "Blue Green":
			// make something pretty happen here
			break;
		case "Yellow Purple":
			// make something pretty happen here
			break;
		case "Yellow Orange":
			// make something pretty happen here
			break;
		case "Yellow Green":
			// make something pretty happen here
			break;
		case "Purple Orange":
			// make something pretty happen here
			break;
		case "Purple Green":
			// make something pretty happen here
			break;
		case "Orange Green":
			// make something pretty happen here
			break;
		case "Red Red":
			// make something pretty happen here
			break;
		case "Blue Blue":
			// make something pretty happen here
			break;
		case "Yellow Yellow":
			// make something pretty happen here
			break;
		case "Purple Purple":
			// make something pretty happen here
			break;
		case "Orange Orange":
			// make something pretty happen here
			break;
		case "Green Green":
			// make something pretty happen here
			break;
		}
	}

	void Create(GameObject parent_1, GameObject parent_2, GameObject particle_type){
		GameObject new_particle;

		parent_1.collider.enabled = false;
		parent_2.collider.enabled = false;

		new_particle = Instantiate(particle_type, parent_1.transform.position, parent_2.transform.rotation) as GameObject;
		new_particle.transform.SetParent(parent_1.transform.parent);
		// need to set the parent of the newly instantiated particle (the two colliding particles)
		particles.Add(new_particle);

		parent_1.SetActive(false);
		parent_2.SetActive(false);
	}
}
