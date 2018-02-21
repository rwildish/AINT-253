using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

    private float timer = 68;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (timer <= 0)
        {
            Application.LoadLevel(2);
        }

        timer -= Time.deltaTime;

	}
}
