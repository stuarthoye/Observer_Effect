using UnityEngine;
using System.Collections;

public class Objective_Controller : MonoBehaviour {
	public bool game_over;
	public Color objective_color = Color.red;

    private Collider collider;
    
    void Start () {
		game_over = false;
		transform.parent.renderer.material.color = objective_color;
	}
    
	void Update() {
		if (game_over){
			//print ("You are a winner!!!");
            //Application.LoadLevel(Application.loadedLevel + 1);
		}
	}

    void OnTriggerEnter (Collider other) {
		if (transform.parent.renderer.material.color == other.renderer.material.color) {
            audio.Play();
            game_over = true;	
		}
    }
}
