using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public Canvas canvas;

    public Button continues;

    public Button quitToMain;

    public Button quitToDesk;

    public bool isMenuActive = false;

	// Use this for initialization
	void Start () {

        canvas = canvas.GetComponent<Canvas>();
        continues = continues.GetComponent<Button>();
        quitToMain = quitToMain.GetComponent<Button>();
        quitToDesk = quitToDesk.GetComponent<Button>();

        canvas.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if(isMenuActive == true)
            {
                canvas.enabled = false;
                isMenuActive = false;
                Time.timeScale = 1;
            }
            else
            {
                canvas.enabled = true;
                isMenuActive = true;
                Time.timeScale = 0;
            }

        }
	
	}

    public void Continue()
    {

        canvas.enabled = false;
        isMenuActive = false;
        Time.timeScale = 1;

    }

    public void QuitToMain()
    {
        Application.LoadLevel(0);
    }

    public void QuitToDesk()
    {
        Application.Quit();
    }
}
