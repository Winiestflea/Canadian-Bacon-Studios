using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{

    public Rigidbody rb;
    public float forceAmount;
    public float jumpAmount;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RigidbodyForce();
    }

    void RigidbodyForce()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpAmount, 0), ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(new Vector3(0, -jumpAmount, 0), ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector3(forceAmount, 0, 0));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(new Vector3(-forceAmount, 0, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector3(0, 0, forceAmount));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector3(0, 0, -forceAmount));
        }

    }

    }
