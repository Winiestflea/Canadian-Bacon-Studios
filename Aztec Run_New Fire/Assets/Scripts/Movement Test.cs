using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour {

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if ( Input.GetKey(KeyCode.A) )
        {
            Vector2 movement = new Vector2 (-1, 0);
        }

        if ( Input.GetKey(KeyCode.D) )
        {
            Vector2 movement = new Vector2 (1, 0);
        }

    }
}
