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



    } // END OF METHOD 
}
