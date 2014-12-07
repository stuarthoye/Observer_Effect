using UnityEngine;
using System.Collections;

public class Objective_Controller : MonoBehaviour {
	public bool game_over;
    private Collider collider;
    
    void Start () {
		game_over = false;
		transform.parent.renderer.material.color = Color.red;
	}
    
	void Update() {
		if (game_over){
			print ("You are a winner!!!");
		}
	}

    void OnTriggerEnter (Collider other) {
		if (transform.parent.renderer.material.color == other.renderer.material.color) {
			game_over = true;	
		}
    }
}
