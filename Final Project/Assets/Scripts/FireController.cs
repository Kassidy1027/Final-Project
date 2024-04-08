using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Kassidy Chase 
 * 4-8-24
 * This script will be used to control the bullets/fireballs that the player shoots
 */


public class FireController : MonoBehaviour     // NOTE: FROM MINI-QUEST 2
{
    /*
     * VARIABLE DECLARATION
     */

    // Variable for the Speed of the Bullet
    public int speed = 8;

    // Used to Shoot the Bullet in Correct Direction 
    private Vector2 direction = Vector2.right;


    /*
     * UNITY DEFAULT METHODS
     */

    // Start is called before the first frame update
    void Start()
    {
        // Destroys Bullet After 2 Seconds 
        Invoke("Die", 2f);

    } // END OF METHOD 


    // Update is called once per frame
    void Update()
    {
        // Updating the Fire's Position
        transform.Translate(direction * speed * Time.deltaTime);

    } // END OF METHOD 


    /*
     * CUSTOM METHODS
     */

    // Method Called to Have the Bullet be Destroyed 
    void Die()
    {
        // Checking to Make Sure the Object is not Null
        if (gameObject != null)
        {
            // Destroying the Bullets
            Destroy(gameObject);

        } // END OF IF

    } // END OF METHOD 


    // When Bullet Runs into Dragon or other Game Objects
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Will Destroy the Bullet in Running into Enemy 
        if (collision.CompareTag("Enemy"))
        {
            // Destroying the Bullet
            Destroy(gameObject);

        } // END OF IF 

    } // END OF METHOD 

} // END OF CLASS