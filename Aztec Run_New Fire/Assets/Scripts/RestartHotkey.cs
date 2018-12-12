using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartHotkey : MonoBehaviour {

    public bool activate = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R) || activate)
        {
            SceneManager.LoadScene("Movement Test");
        }
	}
}
