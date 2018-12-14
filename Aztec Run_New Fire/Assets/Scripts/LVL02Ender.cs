using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVL02Ender : MonoBehaviour
{

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
    void Start()
    {
        StartCoroutine(endUp());
    }
    IEnumerator endUp()
    {
        float start = Time.time;
        playerScripts.enabled = false;
        camScript.isActive = false;
        dedificator.isActive = false;

        camara.position = new Vector3(player.position.x, camara.position.y, camara.position.z);
        while ((Time.time - start) < fadeDur)
        {
            player.position = new Vector3(player.position.x + 0.001f, player.position.y, player.position.z);
            camara.position = new Vector3(camara.position.x + 0.02f, camara.position.y, camara.position.z);
            image.alpha = Mathf.Lerp(0, 1, (Time.time - start) / fadeDur);
            yield return null;
        }
        image.alpha = 1;

        SceneManager.LoadScene("nextLvl");
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("lvl01");

    }
}