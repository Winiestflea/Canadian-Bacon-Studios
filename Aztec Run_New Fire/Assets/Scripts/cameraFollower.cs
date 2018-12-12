using System.Collections;
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
    public int allowence = 20;

    private void Start( )
    {
        
    }

    private void Update() //This is to toggle the camera movement
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            isActive = !isActive;
            Debug.Log("Switch");
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
            if ( player.position.x - camXPos > allowence )
            {
                camXPos += ( player.position.x - camXPos ) / 30;
            }
            transform.position = new Vector3(camXPos, camYPos, -10);
        }



        
    }

}
