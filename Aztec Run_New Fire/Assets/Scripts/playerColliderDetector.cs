using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerColliderDetector : MonoBehaviour {

    public playerController connection;
    public Collider2D collision;

    private void OnTriggerEnter2D( Collider2D collision )
    {
        connection.grounded = true;
        if (collision.gameObject.name == "normalGround" )
        {

        }
    }
    private void OnTriggerExit2D( Collider2D collision )
    {
        connection.grounded = false;
        connection.falling = true;
    }
}
