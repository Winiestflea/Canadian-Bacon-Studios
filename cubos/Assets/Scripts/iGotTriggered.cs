using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iGotTriggered : MonoBehaviour {

    public bool triggered;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionStay( Collision collision )
    {
        triggered = true;
    }
    private void OnCollisionExit( Collision collision )
    {
        triggered = false;
    }
}
