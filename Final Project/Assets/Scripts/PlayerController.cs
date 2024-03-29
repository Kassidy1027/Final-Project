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

    // Variable to get the Player's Facing Direction 
    public Vector2 facingDirection = Vector2.right;


    // PRIVATE VARIABLES

    // Variable to get the Player's Movement 
    private float horizontal;

    // Different Player Components
    private Animator anim;


    /*
     * UNITY DEFAULT METHODS
     */

    // Start is called before the first frame update
    void Start()
    {
        // Getting the Player's Components 
        anim = GetComponent<Animator>();

    } // END OF METHOD 

    // Update is called once per frame
    void Update()
    {
        // Getting the Player's Horizontal Movement 
        horizontal = Input.GetAxis("Horizontal");

        // Checking if Player is Moving
        if (horizontal > 0 | horizontal < 0)
        {
            // Dealing with Player Movement and Sprite Direction 
            if (horizontal > 0 && facingDirection == Vector2.left)
            {
                // Setting the isWalking Bool to True
                anim.SetBool("isWalking", true);

                // Chaning the Scale to Rotate Everything on Player
                FlipX();

                // Flipping the Vector for Bullet Firing
                facingDirection = Vector2.right;

            }
            else if (horizontal < 0 && facingDirection == Vector2.right)
            {
                // Setting the isWalking Bool to True
                anim.SetBool("isWalking", true);

                // Chaning the Scale to Rotate Everything on Player
                FlipX();

                // Flipping the Vector for Bullet Firing
                facingDirection = Vector2.left;

            } // END OF IF/ELSEIF

            // Updating the Player's Transform
            transform.Translate(new Vector3(horizontal, 0, 0) * speed * Time.deltaTime);

        }
        // Player Not Moving
        else 
        {
            // Setting the isWalking Bool to False
            anim.SetBool("isWalking", false);

        } // END OF IF/ELSE


    } // END OF METHOD 


    /*
     * EXTRA/CUSTOM METHODS
     */

    // Used to Flip the Entire Player Sprite and Entities Attaches (From Mini-Quest 2)
    public void FlipX()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = theScale.x * -1;
        transform.localScale = theScale;
    } // END OF METHOD

} // END OF CLASS 
