﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollower : MonoBehaviour {

    public Transform player;

    public bool isActive = false;
    public bool pressedF = false;

    public float camXPos = 0;
    public float camYPos = 0;

    public float sliding = 0.2f;
    public float vSliding;

    public int spacing = 10;

    private void Start( )
    {
        camYPos = player.position.x;
    }

    private void Update() //This is to toggle the camera movement
    {
        if (Input.GetKeyDown(KeyCode.F) && pressedF == false)
        {
            isActive = true;
            pressedF = true;
        }

        else if (Input.GetKeyDown(KeyCode.F) && pressedF == true)
        {
            isActive = false;
            pressedF = false;
        }
    }

    private void FixedUpdate( )
    {
        Vector2 playerPos = player.position;
        if ( isActive )
        {
            camXPos += sliding;

            if ( !( camYPos - playerPos.y < spacing && camYPos - playerPos.y > -spacing ))
            {
                if ( camYPos - playerPos.y > 0 )
                {
                    camYPos -= vSliding;
                }
                else
                {
                    camYPos += vSliding;
                }
            }
        }

        transform.position = new Vector3(camXPos, camYPos, -10);
    }

}
