using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneStarter : MonoBehaviour {

    public Transform player;
    public Transform camara;
    public cameraFollower camScript;
    public playerController playerScripts;
    public dedificatorHelper dedificator;
    // this canvas group is for the opacity of the object
    public CanvasGroup image;

    //this is the duration time
    public float fadeDur = 5f;


	// Use this for initialization
	void Start () {
        StartCoroutine(fadeIn());
        StartCoroutine( startup());
	}
	
	/*
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
    */

    // this IEnumerator is the thing that gets called and starts working next to our code
    IEnumerator fadeIn()
    {
        // this float tells us at what time we started
        float start = Time.time;

        while ( (Time.time - start) //we start taking the opacity away and count the time that has passed
            < fadeDur ) // if the time passed is smaller, than the finish, just continue
        {
            image.alpha = Mathf.Lerp(1 // this one means 
                , 0, ( Time.time - start ) / fadeDur); // take the alpha of our image away
            yield return null; // This helps the function keep track of the time that it has

        }
        image.alpha = 0; // take out that little float remainder and just turn it of
    }

    IEnumerator startup( )
    {
        while ( player.position.x < 0 )
        {
            player.position = new Vector3(player.position.x + 0.05f, player.position.y, player.position.z);
            yield return new WaitForEndOfFrame();
        }
        playerScripts.enabled = true;
        camScript.isActive = true;
        dedificator.isActive = true;
        
    }
}
