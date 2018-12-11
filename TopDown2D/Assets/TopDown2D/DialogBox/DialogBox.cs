using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {

	Text text;

	[Header("Display Options")]
	//give an option to 
	public bool ShowWholeMessege = false;
	[SerializeField]
	string messege;
	[SerializeField]
	float TextDisplaySpeed = 1f;
	[SerializeField]
	float closeDialogDelay = 3f;


	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		//store text from textbox visible in editor
		messege = text.text;
		//clear displayed text
		text.text = "";
		//start corouting to type text;
		StartCoroutine ("typing");
	}
	
	// Update is called once per frame
	void Update () {
		ShowAllText ();
			
	}

	void ShowAllText(){
		if (ShowWholeMessege) {
			StopCoroutine ("typing");
			text.text = messege;
			StartCoroutine ("closeBox");
		}
	}



	IEnumerator typing(){
		//counter for how many characters of the messege to reveal
		int letterCount = 0;

		while (text.text.Length < messege.Length) {
			//gradually reveal more of the messege
			text.text = messege.Substring (0, letterCount);
			//increment the counter
			letterCount++;
			//hold the next loop cycle for the unscaled TextDisplaySpeed duration 
			yield return new WaitForSecondsRealtime (TextDisplaySpeed);
		}
		text.text = messege;
		//start corouting to close the text box;
		StartCoroutine ("closeBox");
	}

	IEnumerator closeBox(){
		float now = Time.time;

		while ((Time.time - now) < closeDialogDelay) {
			//wait for nothing before next loop
			yield return null;
		}
		//disable the parent gameobject
		transform.parent.gameObject.SetActive (false);
	}



}
