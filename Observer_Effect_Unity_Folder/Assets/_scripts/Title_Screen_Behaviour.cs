using UnityEngine;
using System.Collections;

public class Title_Screen_Behaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void AdvanceToFirstLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
