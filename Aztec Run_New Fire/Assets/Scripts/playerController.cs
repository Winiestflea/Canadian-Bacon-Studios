using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    [Header("all the connections")]

    // this are all the external connections
    public Rigidbody2D rigidB;
    public Collider2D collition;
    public Collider2D crouchCol;
    public AttackScript rightAttack;
    public AttackScript leftAttack;

    [Header("adjustable stuff")]

    // this is for the personal references or movements
    public int maxspeed = 10;
    public float speedIncrease = 2;
    public float gravity = 1.3f;
    public float drag = 1;
    public float slideDrag = 0.01f;
    public float jumpForce = 1;
    public float normalHmovement = 2;

    [Header("internal calculations")]

    public float currentVspeed = 0; //vertical speed
    public float currentHspeed = 0; //horizontal speed

    public bool grounded = true;
    public bool touchingNormalGround = false;
    public bool jumping = false;

    // all the internal stuff and variables, that are used personally as key detection
    private bool rightPressed = false;
    private bool leftPressed = false;
    private bool crouchStarted = false;
    private float initialDrag;
    private float initialNormalHMOvement;
    private bool crouchEnded = true;
    private bool crouching = false;
    private bool jumpPressed = false;
    private bool jumpEnded = false;
    private bool attackPressed = false;
    public bool falling = true;

    private float VSpeedPositivized;



	// Use this for initialization
	void Start () {
        initialDrag = drag;
        initialNormalHMOvement = normalHmovement;
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    //this update is exact, and so it should not variate, grat for movement and physix and stuff
    private void FixedUpdate( )
    {
        playerMovement();
    }

    // this function is responsible for all player basic movements (jump and gravity and left/right)
    void playerMovement( )
    {
        //detection of movement

        rightPressed = Input.GetKey(KeyCode.D);
        leftPressed = Input.GetKey(KeyCode.A);

        attackPressed = Input.GetKeyDown(KeyCode.Space);

        jumpPressed = Input.GetKeyDown(KeyCode.W);
        jumpEnded = Input.GetKeyUp(KeyCode.W);

        // all the meths that controll the people

        if ( Input.GetKeyDown(KeyCode.S) ) //if you start the slide 
        {
            crouching = true;
            collition.enabled = false;
            crouchCol.enabled = true;
            normalHmovement = 0.5f;
            drag = slideDrag;
            //start here crouching aniation -------------------------------------------------------------------

        }

        if ( Input.GetKeyUp(KeyCode.S) ) //if you realise the slide
        {
            crouching = false;
            collition.enabled = true;
            crouchCol.enabled = false;
            drag = initialDrag;
            normalHmovement = initialNormalHMOvement;
            //return here to normal animation -----------------------------------------------------------------------
        }

        if ( crouching )
        {
            // if you are crouching, deactivate movement and let drag slow you down
            leftPressed = false;
            rightPressed = false;
            jumpPressed = false;
            if ( grounded && !touchingNormalGround )
            {
                grounded = false;
                falling = true;
            }
        }

        //this is for vertival controlls
        if ( rightPressed || leftPressed )
        {
            // this is for when you press right or left, checks if you did, and if you are not on the limit it will try to start runing
            if ( rightPressed && currentHspeed < maxspeed + normalHmovement )
            {
                currentHspeed += speedIncrease + normalHmovement + 2;
            }
            if ( leftPressed && currentHspeed > -maxspeed )
            {
                currentHspeed -= speedIncrease + normalHmovement + 2;
            }
            // insert here the runing animation------------------------------------------------------
        }
        else
        {
            // if you are not pressing anything return to the value of normalHmovement
            if ( currentHspeed < -drag * 2 + normalHmovement )
            {
                currentHspeed += drag;
            }
            else if ( currentHspeed > drag * 2 + normalHmovement )
            {
                currentHspeed -= drag;
            }
            else
            {
                currentHspeed = normalHmovement;
            }
        }

        if ( attackPressed )
        {
            if (currentHspeed >= 0 )
            {
                rightAttack.isActive = true;
            }
            else
            {
                leftAttack.isActive = true;
            }
        }

        // this is for the jumping, if you started jumping start the jump
        if ( jumpPressed && grounded )
        {
            jumping = true;
            currentVspeed = jumpForce;
        }

        if ( jumpEnded )
        {
            jumping = false;
            falling = true;
        }
        // stop the ground from making the player slow
        if ( grounded ) falling = false;

        // controll al the jumping action
        if ( jumping )
        {
            // slowly make the jump fade
            currentVspeed -= gravity * currentVspeed / 10;
            // if the jump is long enough start gravity
            if ( currentVspeed < 1 )
            {
                currentVspeed = 0;
                jumping = false;
                falling = true;
            }
            else falling = false;
            // add here the jumping animation --------------------------------------------
        }

        // make gravity happen
        if ( falling && currentVspeed > -20 && !jumping)
        {
            if ( VSpeedPositivized < 0 ) VSpeedPositivized = -currentVspeed;
            else VSpeedPositivized = currentVspeed;
            currentVspeed += (- (gravity * VSpeedPositivized) / 10 )- 1;
            falling = true;
            // start here the falling animation---------------------------
        }

        // if you are not falling and you are in a certain sopt dont fall
        if ( !falling && !jumping ) currentVspeed = 0;

        // actually make the meths to controll the people
        rigidB.velocity = new Vector2(currentHspeed,currentVspeed);
    }
}
