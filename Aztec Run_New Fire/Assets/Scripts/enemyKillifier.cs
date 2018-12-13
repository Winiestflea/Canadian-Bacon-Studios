using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyKillifier : MonoBehaviour {

    public RestartHotkey killer;
    public GameObject enemmy;

    private void OnTriggerEnter2D( Collider2D collision )
    {
        Debug.Log("it touched me");
        if (collision.name == "DedificatorRight"|| collision.name == "DedificatorLeft" )
        {
            enemmy.active = false;
        }
        else if(collision.name == "Player" )
        {
            Debug.Log("it's me");
            killer.activate = true;
        }
    }
}
