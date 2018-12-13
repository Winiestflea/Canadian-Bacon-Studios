using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartHotkey : MonoBehaviour {

    public bool activate = false;
    public playerKiller killifier;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R) || activate)
        {
            killifier.enabled = true;
        }
	}
}
