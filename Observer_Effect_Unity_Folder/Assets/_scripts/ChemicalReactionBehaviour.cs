using UnityEngine;
using System.Collections;

public class ChemicalReactionBehaviour : MonoBehaviour {

    public GameObject thing_to_spawn;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    void SpawnParticle()
    {
        Instantiate(thing_to_spawn);
    }
}
