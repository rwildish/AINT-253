using UnityEngine;
using System.Collections;

public class Outro : MonoBehaviour {

    private float timer = 18;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (timer <= 0)
        {
            Application.LoadLevel(0);
        }

        timer -= Time.deltaTime;
	}
}
