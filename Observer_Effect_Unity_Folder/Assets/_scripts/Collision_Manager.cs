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

		// These are the fundamental type collisions
		case "Red Blue":
			Create(messenger.first, messenger.second, Purple);
			break;
		case "Red Yellow":
			Create(messenger.first, messenger.second, Orange);
			break;
		case "Blue Yellow":
			Create(messenger.first, messenger.second, Green);
			break;

		// These collisions are where the particle will have all 3 types
		case "Red Green":
			// end the world
			break;
		case "Blue Orange":
			// end the world
			break;
		case "Yellow Purple":
			// end the world
			break;

		// These are collisions where the particle collides with another containing it type already
		case "Red Purple":
			// make something pretty happen here
			break;
		case "Red Orange":
			// make something pretty happen here
			break;
		case "Blue Purple":
			// make something pretty happen here
			break;
		case "Blue Green":
			// make something pretty happen here
			break;
		case "Yellow Orange":
			// make something pretty happen here
			break;
		case "Yellow Green":
			// make something pretty happen here
			break;

		// These are compound types colliding with other compound types
		case "Purple Orange":
			// end the world?
			break;
		case "Purple Green":
			// end the world?
			break;
		case "Orange Green":
			// end the world?
			break;

		// These are collisions between same particles
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
		default:
			break;
		}
	}

	void Create(GameObject parent_1, GameObject parent_2, GameObject particle_type){
		GameObject new_particle;

		parent_1.collider.enabled = false;
		parent_2.collider.enabled = false;
		
		new_particle = Instantiate (particle_type, parent_1.transform.position, parent_2.transform.rotation) as GameObject;
		new_particle.transform.SetParent(parent_1.transform.parent);
		new_particle.GetComponent<P0_Compound_Particle> ().Set_Parents (parent_1, parent_2);
		particles.Add(new_particle);

		parent_1.SetActive(false);
		parent_2.SetActive(false);
	}
}
