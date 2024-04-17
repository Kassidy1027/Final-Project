using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Kassidy Chase   
 * 4-15-24
 * This Script will Control the Menu for the Game as well as be called to changed Levels when Needed by other Scripts. 
 */


public class MenuController : MonoBehaviour
{
    /*
     * CUSTOM/EXTRA METHODS
     */

    // Method Called to Load the Level
    public void LoadScene(int index)
    {
        // Loading the Scene Based on the Index Given 
        SceneManager.LoadScene(index);

    } // END OF METHOD 

    // Method Called to Exit the Game
    public void Exit()
    {
        // Exiting the Application 
        Application.Quit();

    } // END OF METHOD 

} // END OF CLASS 
