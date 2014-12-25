using UnityEngine;
using System.Collections;

public class Collision_Manager : MonoBehaviour {

	public GameObject Red;
	public GameObject Blue;
	public GameObject Yellow;
	public GameObject Purple;
	public GameObject Orange;
	public GameObject Green;
	// Use this for initialization
	void Start () {
		// foreach (Transform child in transform){
		// 	print ("HELLO WORLD");
		// }
	}

	void Collide(Messenger messenger){
		string message = messenger.first.tag + " " + messenger.second.tag;

		switch (message) {
		case "Red Blue":
			messenger.first.collider.enabled = false;
			messenger.second.collider.enabled = false;
			Instantiate(Purple, messenger.first.transform.position, messenger.first.transform.rotation);
			messenger.first.SetActive(false);
			messenger.second.SetActive(false);
			break;
		case "Red Yellow":
			messenger.first.collider.enabled = false;
			messenger.second.collider.enabled = false;
			Instantiate(Orange, messenger.first.transform.position, messenger.first.transform.rotation);
			messenger.first.SetActive(false);
			messenger.second.SetActive(false);
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
			messenger.first.collider.enabled = false;
			messenger.second.collider.enabled = false;
			Instantiate(Green, messenger.first.transform.position, messenger.first.transform.rotation);
			messenger.first.SetActive(false);
			messenger.second.SetActive(false);
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
}
