using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winnerEnderStarter2 : MonoBehaviour
{
    public LVL02Ender activation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            activation.enabled = true;
        }
    }
}

