////////////////////////////////////////////
////                                    ////
////   Autor: Christian Langpaap        ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour 
{
	public static bool Singleplayer;
    public static bool Koop;
	
	private GameObject Player;

	void Start () 
    {
        Player = GameObject.FindGameObjectWithTag("Player");	
	}
	
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.name == "TeleportSinglePlayer")
        {
            Singleplayer = true;
        }
        if (other.gameObject.tag == "Player" && this.gameObject.name == "TeleportSinglePlayerDemo")
        {
            Singleplayer = true;
        }  
        if (other.gameObject.tag == "Player" && this.gameObject.name == "TeleportKoop")
        {
            Koop = true;
        }
        if (other.gameObject.tag == "Player" && this.gameObject.name == "TeleportHelp")
        {
            Application.LoadLevel("Help");
        }
        if (other.gameObject.tag == "Player" && this.gameObject.name == "TeleportCredits")
        {
            Application.LoadLevel("Credits");
        }
        if (other.gameObject.tag == "Player" && this.gameObject.name == "TeleportMenu")
        {
            Application.LoadLevel("MainMenuDemo");
        }
        if (other.gameObject.tag == "Player" && this.gameObject.name == "TeleportExit")
        {
            Application.Quit();
        }
    }
}
