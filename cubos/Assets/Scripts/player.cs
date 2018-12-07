using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public Rigidbody cube;
    public int moveAmount;
    public int jtyme;
    bool spaceOn;
    public gameOverDetector gameOver;

    // Use this for initialization
    void Start( )
    {

    }

    // Update is called once per frame
    void Update( )
    {
        rigidBodyForce();
    }
    void rigidBodyForce( )
    {
        if ( cube.velocity.y < 0 )
        {
            //cube.AddForce(new Vector3(0, -jtyme / 2, 0));
        }


        if ( Input.GetKey(KeyCode.A) )
        {
            cube.AddForce(new Vector3(-moveAmount, 0, 0));
        }
        if ( Input.GetKey(KeyCode.D) )
        {
            cube.AddForce(new Vector3(moveAmount, 0, 0));
        }
        if ( Input.GetKeyDown(KeyCode.Space) )
        {
            if ( jtyme < 1 )
            {
                spaceOn = true;
                cube.AddForce(new Vector3(0, moveAmount / 10, 0), ForceMode.Impulse);
                if ( cube.velocity.x == 0 )
                {
                    cube.AddForce(new Vector3(0, moveAmount / 10, 0), ForceMode.Impulse);
                }
            }
        }
        if ( Input.GetKeyUp(KeyCode.Space) )
        {
            spaceOn = false;
            //cube.AddForce(new Vector3(0, -moveAmount * 2 - jtyme * 4, 0));

        }

        if ( spaceOn )
        {
            if ( jtyme < 50 )
            {
                jtyme++;
                cube.AddForce(new Vector3(0, moveAmount - jtyme, 0));
            }
            else
            {
                spaceOn = false;
                // cube.AddForce(new Vector3(0, -moveAmount + jtyme, 0));
                /*
                if(cube.velocity.y < 0)
                {
                    cube.AddForce(new Vector3(0, -moveAmount * 2, 0));
                }
                */
            }
        }
        else
        {
            if ( jtyme > 2 )
            {
                jtyme--;
                cube.AddForce(new Vector3(0, -moveAmount / 2, 0));
            }
        }

        if ( gameOver.gameOver )
        {
            transform.position = new Vector3(30, 15, 0);
            gameOver.gameOver = false;
            jtyme = 2;
        }
    }
    private void OnTriggerEnter( Collider other )
    {
        jtyme = 0;
        jtyme = 0;
    }
    void transformMove( )
    {

    }
}
