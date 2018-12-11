using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class WeaponHitbox : MonoBehaviour {

	/*this script handles the behaviour of the attackng hitbox
	 * 1. Sets the duration of the hitbox activation
	 * 2. turns off the hitbox after the durration has ended
	 * 3. provided the standard trigger methods that are used for 2d collisions  */

	// this is the durration in seconds that the hitbox is active, the default value of 0.5 seconds
	//can be overridden in the inspector without editing the code.
	[SerializeField]
	float attackDurration= .5f;

	// Use this for initialization. Note: Start() and Awake() methods
	//are only callled once in the lifetime of a script. Use OnEnabled() 
	//for behaviors that you want to call everytime a game object becomes active
	void Start () {
		
		/* idiot proofing. this ensures that the collider is a trigger so that OnTriggerEnter() is called 
		when something enters the Trigger. Absolutely everyone makes the mistate of forgetting to 
		set the collider to a trigger at somepoint.	*/
		GetComponent<Collider2D>().isTrigger = true;

		//more idiot proofing. the hitbox should be inactive at the start of the game.
		gameObject.SetActive (false);
	}
		
		//called everytime gameobject is turned on
	void OnEnable(){
		//start coroutine to deactive the hitbox after up brief lifespan;
		StartCoroutine ("temporaryActivation");
	}


	// these are the standard Tigger2d methods. 

	//stuff happens when a 2D colider enters the trigger
	void OnTriggerEnter2D(Collider2D other){
		//stuff 
		Debug.Log(other.gameObject + " Entered");
	}


	//stuff happens when a 2D colider stays in the trigger
	void OnTriggerStay2D(Collider2D other) {
		//more stuff
		Debug.Log(other.gameObject + " Stayed");
	}

	//stuff happens when a 2D colider exits the trigger
	void OnTriggerExit2D(Collider2D other){
		//even more stuff
		Debug.Log(other.gameObject + " Exited");
	}





	//coroutine to deactive the hitbox after up brief lifespan;
	IEnumerator temporaryActivation(){
		bool isAttacking = true;
		while (isAttacking) {
			yield return new WaitForSecondsRealtime (attackDurration);
			isAttacking = false;
		}

		gameObject.SetActive (false);
	}





}
