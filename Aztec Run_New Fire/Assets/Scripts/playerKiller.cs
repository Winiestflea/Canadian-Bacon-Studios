using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerKiller : MonoBehaviour {

    public Transform player;
    public Transform camara;
    public cameraFollower camScript;
    public playerController playerScripts;
    public Rigidbody2D playerRigidbod;
    // this canvas group is for the opacity of the object
    public CanvasGroup image;

    public string nameOfChangingScene;

    //this is the duration time
    public float fadeDur = 5f;
    public int done = 0;

    // Use this for initialization
    void Start( )
    {
        StartCoroutine(endUp());
    }
    IEnumerator endUp( )
    {
        
        playerScripts.enabled = false;
        camScript.isActive = false;

        camara.position = new Vector3(player.position.x, camara.position.y, camara.position.z);

        playerRigidbod.velocity = new Vector3(0, 0, 0);
        playerRigidbod.simulated = false;

        while (done < 10 )
        {
            player.position = new Vector3(player.position.x, player.position.y + 0.1f, player.position.z);
            done++;
            yield return new WaitForFixedUpdate();
        }
        float start = Time.time;
        while ( ( Time.time - start ) < fadeDur )
        {
            player.position = new Vector3(player.position.x, player.position.y - 0.2f, player.position.z);
            image.alpha = Mathf.Lerp(0, 1, ( Time.time - start ) / fadeDur);
            yield return null;
        }
        image.alpha = 1;

        SceneManager.LoadScene(nameOfChangingScene);
    }
}
