using UnityEngine;
using System.Collections;

public class Objective_Controller : MonoBehaviour {
	public bool visible;

	void Start () {
		visible = true;
	}

	void Update () {
		// Test whether player can see this.
		// Or if visibility is set by ray-cast, then automatically disable it?
		// Toggle all activity if not visible.

		/* 	if (visible) {
		 * 		code
		 * 		code
		 * 		code
		 * 		visible = false;  (raycast from player will toggle this back)
		 * 	}
		 */
	}
}
