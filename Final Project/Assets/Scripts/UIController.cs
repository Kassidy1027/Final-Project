using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Kassidy Chase   
 * 4-15-24
 * This Script will Control the Different UI Elements in the Game; More Specifically the Buttons 
 */


public class UIController : MonoBehaviour
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


    // Method Called to Show the Hints
    public void HintButton(GameObject hintScreen)
    {
        // Checking if the hintScreen is active
        if (hintScreen.active)
        {
            // Setting it to False
            hintScreen.SetActive(false);

        }
        // Checking if hintScreen is Not Active
        else if (!hintScreen.active)
        {
            // Setting hintScreen to True
            hintScreen.SetActive(true);

        } // END OF IF/ELSEIF

    } // END OF METHOD

} // END OF CLASS 
