using UnityEngine;
using System.Collections;

public class Ingame_Menu : MonoBehaviour
{

    public Canvas pausemenu;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //this works
        /*if (Input.GetButtonDown("Menu"))
        {
            pausemenu.gameObject.SetActive(true);
            this.gameObject.GetComponent<Player_Controller>().enabled = false;
        }*/

        if (Input.GetButtonDown("Menu"))
        {
            pausemenu.gameObject.SetActive(true);
            this.gameObject.GetComponent<Player_Controller>().enabled = false;
            Screen.showCursor = true;
        }
        
        
    }

    public void Resume()
    {
        pausemenu.gameObject.SetActive(false);
        this.gameObject.GetComponent<Player_Controller>().enabled = true;
        Screen.showCursor = false;
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
