using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//this is how to manage the camera thing its IMPORTANT to add it

public class samplescreenchanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //this is how to change the thingy
        SceneManager.LoadScene("Movemnt Test");
    }
}
