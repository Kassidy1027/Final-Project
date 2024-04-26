using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Kassidy Chase 
 * 3-29-24
 * This script will control the Camera in relation to the player. 
 */


public class CameraController : MonoBehaviour
{
    /*
     * VARIABLE/OBJECT DECLARATION 
     */

    // Tranform Variable for the Player
    public Transform playerTransform;

    // Vector to have the Player Offset
    public Vector3 offset;


    /*
     * UNITY METHODS
     */

    // LateUpdate Method to Move Camera After Player 
    private void LateUpdate()
    {
        // Moving the Camera Based off Player Position and Offset
        transform.position = playerTransform.position + offset;

    } // END OF METHOD 

} // END OF CLASS 
