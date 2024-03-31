using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Kassidy Chase 
 * 3-29-24
 * This script will hold the code to control all things about the player. 
 */

public class PlayerController : MonoBehaviour
{
    /*
     * VARIABLE/OBJECT DECLARATION
     */

    // PUBLIC VARIABLES

    // Variable to Hold the Player's Speed 
    public int speed;

    // Variable to Hold the Move Force on the Player
    public float moveForce;

    // Variable to Hold the Jump Force of the Player 
    public float jumpForce; 

    // Variable to get the Player's Facing Direction 
    public Vector2 facingDirection = Vector2.right;

    // Variable to hold the GroundCheck Object
    public GameObject GroundCheck;


    // PRIVATE VARIABLES

    // Variable to get the Player's Movement 
    public float horizontal;

    // Different Player Components
    private Animator anim;
    private Rigidbody2D rbody;

    // Variable to Make sure the Player is Alive 
    private bool isDead = false;

    // Variable to Prevent the Player from Double Jumping 
    private bool jump;


    /*
     * UNITY DEFAULT METHODS
     */

    // Start is called before the first frame update
    void Start()
    {
        // Getting the Player's Components 
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();

    } // END OF METHOD 

    // Update is called once per frame
    void Update()
    {
        // Getting the Player's Horizontal Movement 
        horizontal = Input.GetAxis("Horizontal");

        // Checking the Direction the Player is Facing
        if (horizontal < 0 && facingDirection == Vector2.right)
        {
            // Flipping the Player 
            FlipX();

            // Changing the facingDirection 
            facingDirection = Vector2.left;

        }
        else if (horizontal > 0 && facingDirection == Vector2.left)
        {
            // Flipping Player 
            FlipX();

            // Changing facingDirection 
            facingDirection = Vector2.right;

        } // END OF IF/ELSEIF


        // Checking if the Player is Moving and Setting the Animation 
        if (horizontal > 0 | horizontal < 0)
        {
            // Setting the Walking Animation to True 
            anim.SetBool("isWalking", true);
        }
        else if (horizontal == 0)
        {
            // Setting the Walking Animation to False 
            anim.SetBool("isWalking", false);
        }


        // Checking if the Player is Jumping 
        if (Input.GetButtonDown("Jump"))
        {
            // Setting jump to true
            jump = true;
        }


    } // END OF METHOD 


    /*
     * EXTRA/CUSTOM METHODS
     */

    // Method the Handle the Physics of the Game 
    private void FixedUpdate()
    {
        // As Long as Player is not Dead Do Movement  NOTE: Taken from Mini-Quest 2
        if (!isDead)
        {
            // Creating a RayCast so Player Can't Double Jump
            RaycastHit2D hitInfo = Physics2D.Raycast(GroundCheck.transform.position, Vector2.down, .25f);

            // Seeing the Raycast; Will Draw it in the Scene
            Debug.DrawRay(GroundCheck.transform.position, Vector2.down, Color.red, 1f);

            // Player Movement
            if (rbody.velocity.x < 15 && rbody.velocity.x > -15)
            { 
                // Adding Force and Moving Player 
                rbody.AddForce(Vector2.right * horizontal * moveForce);

            } // END OF IF


            // Checking if Player is Jumping and Touching the Ground 
            if (jump)
            {
                if (hitInfo.collider != null)
                {
                    // Adding Force to the Player to Jump 
                    rbody.AddForce(Vector2.up * jumpForce);

                } // END OF IF

                // Resetting the Jump Boolean 
                jump = false;

            } // END OF IF


        } // END OF IF




    } // END OF METHOD 




    // Used to Flip the Entire Player Sprite and Entities Attaches (From Mini-Quest 2)
    public void FlipX()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = theScale.x * -1;
        transform.localScale = theScale;
    } // END OF METHOD

} // END OF CLASS 
