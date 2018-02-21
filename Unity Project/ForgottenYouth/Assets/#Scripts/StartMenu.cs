using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

    public Button play;
    public Button quit;



	// Use this for initialization
	void Start () {

        Screen.lockCursor = false;

        play = play.GetComponent<Button>();
        quit = quit.GetComponent<Button>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play()
    {
        Application.LoadLevel(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
