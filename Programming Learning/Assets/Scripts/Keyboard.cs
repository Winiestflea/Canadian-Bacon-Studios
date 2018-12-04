using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour {


    public bool ShowHello;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (ShowHello)
            Debug.Log(Input.GetKey(KeyCode.A));
        }
	}
}
