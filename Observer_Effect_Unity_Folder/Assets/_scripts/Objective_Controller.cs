using UnityEngine;
using System.Collections;

public class Objective_Controller : MonoBehaviour {
	public bool game_over;
    public GameObject objective_particle;

    private Collider collider;
    
    void Start () {
		game_over = false;
        //does not work since colors are determined on Start()
        //transform.parent.renderer.material.color = objective_particle.renderer.material.color;
	}
    
	void Update() {
		if (game_over){
			//print ("You are a winner!!!");
            Application.LoadLevel(Application.loadedLevel + 1);
		}
	}

    void OnTriggerEnter (Collider other) {
		if (objective_particle.tag == other.tag) {
            audio.Play();
            game_over = true;	
		}
    }
}
