using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

    private bool isActive = false;
    private bool pressed = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && pressed == false)
        {
            isActive = true;
            pressed = true;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && pressed == true)
        {
            isActive = false;
            pressed = false;
        }
    }
}
