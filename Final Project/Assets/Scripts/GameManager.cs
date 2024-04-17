using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
     * VARAIBLES/OBJECT DECLARATION 
     */

    // PUBLIC VARAIBLES/OBJECTS

    // Instance of the Game Manager Script 
    public static GameManager instance;

    // This will Keep Track of Players Lives 
    public int lives;

    // List to hold the Player's Inventory 
    public List<string> inventory = new List<string>();


    /*
     * SINGLETON DESIGN METHOD 
     */

    // Method used to Set up the Singleton Design
    private void Awake()
    {
        // Checking if only One Instance of the GameManager Exists
        if (instance == null)
        {
            // Setting the Instance 
            instance = this;
        }
        else if (instance != this)
        {
            // Destorying the Duplicate if Created 
            Destroy(gameObject);

        } // END OF IF/ELSE

        // Setting the Objecto not Destory on a Load 
        DontDestroyOnLoad(gameObject);

    } // END OF METHOD 


    // Method to be Called to Clear Player Inventory 
    public void ClearInventory()
    {
        // Clearing Player Inventory 
        inventory.Clear();

    } // END OF METHOD 

} // END OF CLASS 