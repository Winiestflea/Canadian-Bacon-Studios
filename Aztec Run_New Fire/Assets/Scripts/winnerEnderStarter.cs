using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winnerEnderStarter : MonoBehaviour {
    public sceneEnder activation;

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if(collision.name == "Player" )
        {
            Debug.Log("activated");
            activation.enabled = true;
        }
    }
}
