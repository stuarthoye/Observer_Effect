using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

    public GameObject collides_with;
    public GameObject spawns;
    public Collision collision;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter (Collider other)
    {
        Debug.Log("touch");
        if (other == collides_with.collider)
        {
            Instantiate(spawns);
            Destroy (other.gameObject);
            Destroy(this);
        }
    }
}
