using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public int position;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(1, 1, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - new Vector3(1, 0, 0);
        }

    }
}
