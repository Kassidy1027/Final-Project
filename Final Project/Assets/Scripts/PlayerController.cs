using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    [Header("Player Movement")]
    // Variable to hold the Players Speed 
    public int speed;

    // Variable to Hold the Move Force on the Player
    public float moveForce;

    // Variable to Hold the Jump Force of the Player 
    public float jumpForce; 

    [Header("Double Jump Prevention")]
    // Variable to hold the GroundCheck Object
    public GameObject GroundCheck;

    [Header("Attack Objects")]
    public GameObject fire;
    public Transform firePoint;
    
    [Header("Win Screen")]
    public CanvasGroup winScreen;



    // PRIVATE VARIABLES

    // Variable to get the Player's Movement 
    private float horizontal;

    // Variable to get the Player's Facing Direction 
    private Vector2 facingDirection = Vector2.right;

    // Different Player Components
    private Animator anim;
    private Rigidbody2D rbody;

    // Variable to Prevent the Player from Double Jumping 
    private bool isJumping = false;

    // Variable to Slow Player Fire Rate 
    private float nextTimeToFire = 0;

    // Variable to Delay Time Between Fire 
    private float fireDelay = .7f;


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

        } // END OF IF/ELSEIF


        // Checking if the Player is Jumping 
        if (Input.GetButtonDown("Jump"))
        {
            // Setting jump to true
            isJumping = true;

        } // END OF IF 


        // Checking if the Fire Button is Pressed
        if (Input.GetButton("Fire1") && Time.time > nextTimeToFire)
        {
            // Setting the Animator to Show Shooting Animation
            anim.SetBool("isShooting", true);

            // Instantiate the Fire Sprite                      If Statment in one Line (Testing ? True : False)
            Instantiate(fire, firePoint.position, facingDirection == Vector2.left ? Quaternion.Euler(0, 180, 0) : firePoint.rotation);

            // Setting up Fire Delay 
            nextTimeToFire = Time.time + fireDelay;

        }
        else
        {
            // Resetting the Shooting Animation 
            anim.SetBool("isShooting", false);

        } // END OF IF/ELSE


    } // END OF METHOD 


    /*
     * EXTRA/CUSTOM METHODS
     */

    // Method the Handle the Physics of the Game 
    private void FixedUpdate()
    {
        // Creating a RayCast so Player Can't Double Jump
        RaycastHit2D hitInfo = Physics2D.Raycast(GroundCheck.transform.position, Vector2.down, .25f);

        // Seeing the Raycast; Will Draw it in the Scene
        Debug.DrawRay(GroundCheck.transform.position, Vector2.down, Color.red, 1f);

        // Player Movement
        if (rbody.velocity.x < 8 && rbody.velocity.x > -8)
        { 
            // Adding Force and Moving Player 
            rbody.AddForce(Vector2.right * horizontal * moveForce);

        } // END OF IF


        // Checking if Player is Jumping and Touching the Ground 
        if (isJumping)
        {
            if (hitInfo.collider != null)
            {
                // Doing the Jump Animation 
                anim.SetBool("isJumping", true);

                // Adding Force to the Player to Jump 
                rbody.AddForce(Vector2.up * jumpForce);

            } // END OF IF

            // Starting the Coroutine to Reset Jump Animation 
            StartCoroutine(JumpAnimationReset());

        } // END OF IF

    } // END OF METHOD 


    // Method Called to Reset the Jump Animation 
    IEnumerator JumpAnimationReset()
    {
        // Waiting a few Seconds for the Player to Land
        yield return new WaitForSeconds(.5f);

        // Resetting the Jump Boolean 
        isJumping = false;

        // Resetting the Jump Animation 
        anim.SetBool("isJumping", false);

    } // END OF METHOD 


    // Used to Flip the Entire Player Sprite and Entities Attaches (From Mini-Quest 2)
    public void FlipX()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = theScale.x * -1;
        transform.localScale = theScale;

    } // END OF METHOD


    // Method Called when the Player Runs into Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checking if the Player Runs into the Gravestone
        if (collision.gameObject.tag == "GraveStone1")
        {
            // Changing Scene
            SceneManager.LoadScene(2);

        }
        // Checking if the Player Runs into the Second GraveStone
        else if (collision.gameObject.tag == "GraveStone2")
        {
            // Changing Sceen
            SceneManager.LoadScene(1);

            // Setting the Player Position After Reloading the Scene
            transform.position = new Vector2(26.5f, 0.2f);


        }
        // Checking if the Player Runs into the Stump 
        else if (collision.gameObject.tag == "Stump")
        {
            // Checking if the Player has the Axe in Inventory 
            if (GameManager.instance.inventory.Contains("Axe"))
            {
                // Calling the GameOverWin Method 
                GameOverWin();

            } // END OF IF 

        } // END OF IF/ELSEIF



    } // END OF METHOD 


    // Method for When the Player Runs into the Axe 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checking if the Player Ran into the Axe 
        if (collision.gameObject.tag == "Axe")
        {
            // Add the Axe to Player Inventory 
            GameManager.instance.inventory.Add("Axe");

            // Remove the Axe Game Object 
            Destroy(collision.gameObject);

        } // END OF IF  

    } // END OF METHOD 


        // Method to Load Main Menu
    public void MainMenu()
    {
        // Loading the Main Menu Scene 
        SceneManager.LoadScene(0);

    } // END OF METHOD 


    // Method Called When the Player Wins
    void GameOverWin()
    {
        // Setting the Win Screen 
        winScreen.alpha = 2;

        // Loading Back to the Main Screen 
        Invoke("MainMenu", 8f);

    } // END OF METHOD 

} // END OF CLASS 
