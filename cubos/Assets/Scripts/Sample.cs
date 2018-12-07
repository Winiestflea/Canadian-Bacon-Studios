using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{

    public int force;
    public int max;
    public float spood;
    public float jumpSpood;
    public bool spaceOn;
    public int jtyme = 0;

    // Use this for initialization
    void Start( )
    {
        spood = 0;
        jumpSpood = 0;
    }

    // Update is called once per frame
    void Update( )
    {

        if ( Input.GetKey(KeyCode.D) )
        {
            if ( spood < max )
            {
                spood = spood + force / 10;
            }
        }
        else if ( Input.GetKey(KeyCode.A) )
        {
            if ( spood > -max )
            {
                spood = spood - force / 10;
            }
        }
        else
        {
            if ( spood < 2 || spood > -2 )
            {
                spood = 0;
            }
            else if ( spood <= -1 )
            {
                spood = spood + force / 2;

            }
            else if ( spood >= 1 )
            {
                spood = spood - force / 2;
            }
        }
        if ( Input.GetKeyDown(KeyCode.Space) )
            spaceOn = true;
        if ( Input.GetKeyUp(KeyCode.Space) )
            spaceOn = false;
        if ( spaceOn )
        {
            if ( jtyme < 10 )
            {
                jtyme++;
                jumpSpood = jumpSpood + force / jtyme;
            }
            else
            {
                spaceOn = false;
                jumpSpood = 0;
            }
        }
        else
        {
            jumpSpood = -10;
            if ( jtyme > 0 ) jtyme--;
        }


        GetComponent<Rigidbody>().velocity = new Vector3(spood, jumpSpood, 0);

    }


}
