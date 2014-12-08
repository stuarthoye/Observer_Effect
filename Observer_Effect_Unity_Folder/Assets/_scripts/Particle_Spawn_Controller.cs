using UnityEngine;
using System.Collections;

public class Particle_Spawn_Controller : MonoBehaviour {
	public Transform new_particle;
	void Start () {
		new_particle = transform.Find("Generic_Particle");
		//Spawn_Particle ();
	}

	void Update () {
	
	}

	void Spawn_Particle(){
		new_particle.renderer.material.color = Color.red;
	}
}
