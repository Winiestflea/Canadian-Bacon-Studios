using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDown2DPhysicsMovement : MonoBehaviour
{

    /* this script handles the movement and basic interaction of the player's character
	 1. converts input into movement and character direction
	 2. checks for attack input and activates the appropriate hitbox for directional attacks */


    //references the RigidBody2d, used for physics movement
    Rigidbody2D rb;

    //references the Animator, for animating the player
    Animator anim;

    //references the CircleCollider2D, for hit detection of the player
    Collider2D playerBody;

    public float maxSpeed = 2;

    /*
	//creates an enumeration class for the players cartisan direction, you could create 
	additional sprites for diagonal movements and add diagonal (UR, DR, DL, UL) directions 
	to this enum class. Setting the value (U = 1, R= 2,etc...) is not required, but manually 
	assisgning the enums numeric value gives you greater controll over the values.   
	// else serialization of the enum values begins at 0. */
    public enum Direction
    {
        U = 1, R = 2, D = 3, L = 4
    }
    //declares the derection variable, and defines the start value to be facing down
    Direction direction = Direction.D;

    /*the following creates a GameObject Array for the attack hitboxes, these should be assigned in the same order as the 
	 Direction Enum { Up, Right, Down, Left}. You can set the Array size in the inspector (should be 4) 

	The Attack() method later in this script only activates gameobject 0 through 3  (indexes start at zero) 
	using the direction value. You can add safely add more gameobject to this array, either for diagonal attacks,
	special moves, lights, clothing, etc... and reference them by index (greater than 3) through your own method.
	Although for the ease of reading and debuging you code, it would be better to make a seperate array for 
	other objects.

	(Optional) Since this is a GameObject Array, any GameObject can be asigned to it. To make it work ONLY for 
	weapon hitboxes do the following:
	1.replace GameObject[] with WeaponHitBox[] to make it a WeaponHitbox Array instead of a GameObject Array.
	2.In the Attack() method later in this Script: 
	 		replace: AttackHitboxes [(int)direction-1].SetActive (true).
	 		with: AttackHitboxes [(int)direction-1].gameobject.SetActive (true)
	3.Reassign the hitboxes in the appropirate order in the inspector. */
    [Tooltip("container for the attack hitboxes, these should be assigned in the same order as the Direction Enum, Up, Right, Down, Left")]
    [SerializeField]
    GameObject[] AttackHitboxes;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerBody = GetComponent<Collider2D>();

    }

    // Update is called once per frame, and the number of frames per second(fps) varries per computer (and depending on the computer load) 
    void Update()
    {
        //Calls Attack() to check if Attack used
        Attack();
    }

    // Update is called once per physics update and is consistant across nearly all computers
    void FixedUpdate()
    {
        //Calls Attack() to move the character
        Movement();
    }

    //the method for moving the character 
    void Movement()
    {
        //convert button input to speed
        float move = Input.GetAxis("Vertical");
        move = (Mathf.Abs(move) < Mathf.Abs(Input.GetAxis("Vertical"))) ? Input.GetAxis("Vertical") : move;

        float side = Input.GetAxis("Horizontal");
        side = (Mathf.Abs(side) < Mathf.Abs(Input.GetAxis("Horizontal"))) ? Input.GetAxis("Horizontal") : side;

        //Vector2.normalized adjusts the values so the Vector2 magnitude is never greater then 1, 
        //this makes it so that the character doesn't move faster when moving diagonally.  
        Vector2 movementVector = new Vector2(side, move).normalized;

        //changed the velocity of the player multiplying the maxSpeed by the movementVector
        rb.velocity = movementVector * maxSpeed;

        //change direction by side input, tolerences given to account for loose buttons and faulty controller/keyboard inputs
        if (side > 0.01f)
            direction = Direction.R;
        else if (side < -0.01f)
            direction = Direction.L;
        //change direction by vertical input
        if (move > 0.01f)
            direction = Direction.U;
        else if (move < -0.01f)
            direction = Direction.D;

        //tells animator the speed of movement to use as the "Speed" paramater in the Animator, 
        //in this project the "Speed" parameter is used as a modifier in the walk animation, 
        //when the speed is zero, the animation is frozen, which acts as an idle animation, 
        //or you could make your own Idle animation, and use a "Speed" value to triger the transition in the Animator 
        if (anim != null)
        {
            anim.SetFloat("Speed", Mathf.Abs(movementVector.magnitude));
        }

        if (anim != null)
        {
            //cast the direction as a flaot and tell animator the value to use as the "Direction" paramater in the Animator
            anim.SetFloat("Direction", (float)direction);
        }
    }

    //detect if player is holding/pressing "Fire1", which is defined in edit=> project settings=> Input
    void Attack()
    {
        if (Input.GetButton("Fire1") == true)
        {
            if (anim != null)
            {
                anim.SetBool("Attack", true);
                /* 
				Activate the Hitbox in the direction the player is facing at the start of the animation.
				Note: index values can only be integers, so we are casting the enum as an interger. 
				the minus One is to correct for the Enum values being set to start at 1 and the 
				AttackBoxes serialization staring at zero.
				*/
                AttackHitboxes[(int)direction - 1].SetActive(true);
            }
        }
        else
        {
            if (anim != null)
            {
                anim.SetBool("Attack", false);
            }
        }
    }





}