using UnityEngine;
using System.Collections;

public class P0_Compound_Particle : P0_Basic_Particle {
	public GameObject parent_1, parent_2;

	public float decay_timer = 10;

	public void Set_Parents(GameObject p1, GameObject p2){
		parent_1 = p1;
		parent_2 = p2;
	}

	protected void Decay (){
		// Once we are able to set the parents in collision manager, we can uncomment these lines.
		parent_1.transform.position = transform.position;
		parent_2.transform.position = transform.position + new Vector3(0, 2, 0);
		parent_1.SetActive (true);
		parent_2.SetActive (true);
		parent_1.collider.enabled = true;
		parent_2.collider.enabled = true;
		Destroy (gameObject);
	}
}
