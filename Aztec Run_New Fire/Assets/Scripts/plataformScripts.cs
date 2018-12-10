using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformScripts : MonoBehaviour {

    public playerController connection;
    public Collider2D collision;

    private void OnTriggerStay2D( Collider2D collision )
    {
        connection.currentVspeed += 10;
    }
}
