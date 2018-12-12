using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneStarter : MonoBehaviour {
    public Transform player;
    public Transform camara;
    public cameraFollower camScript;
    public playerController playerScripts;
    public dedificatorHelper dedificator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player.position.x < 0 )
        {
            player.position = new Vector3(player.position.x + 0.05f, player.position.y, player.position.z);

        }
        else
        {
            playerScripts.enabled = true;
            camScript.isActive = true;
            dedificator.isActive = true;
        }
	}
}
