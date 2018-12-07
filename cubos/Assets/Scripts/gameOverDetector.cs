using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverDetector : MonoBehaviour {

    public bool gameOver;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter( Collider other )
    {
        gameOver = true;
    }
}
