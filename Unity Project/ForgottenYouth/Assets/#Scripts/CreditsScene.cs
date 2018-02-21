using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditsScene : MonoBehaviour {

    public Text credits;
    private Transform creditsTransform;

    private float timer = 80;

	// Use this for initialization
	void Start () {

        creditsTransform = credits.GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {

        creditsTransform.position += new Vector3(0, 0.35f, 0);

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Application.LoadLevel(4);
        }
	
	}
}
