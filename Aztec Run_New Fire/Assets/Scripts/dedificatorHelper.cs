using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dedificatorHelper : MonoBehaviour {

    public int screenSize;
    public bool isActive = false;
    public RestartHotkey restarter; 


	// Use this for initialization
	void Start () {
        screenSize = Screen.width;
        transform.position = new Vector3(-screenSize / 200 - 5, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.gameObject.name == "Player" && isActive)
        {
            restarter.activate = true;
        }
    }
}
