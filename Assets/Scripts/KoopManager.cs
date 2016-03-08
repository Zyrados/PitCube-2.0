////////////////////////////////////////////
////                                    ////
////   Autor: Christian Langpaap        ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class KoopManager : MonoBehaviour 
{	
	public GameObject WinP1;
    public GameObject WinP2;
    public GameObject PauseMenu;
    public bool BattleMode = false;
    public GameObject HelpScreen;	
	public int Player1Ammo;
    public int Player2Ammo;
    public bool ColorLevel = false;
    public bool LightLevel = false;
    public bool BubbleLevel = false;
    public bool JumpLevel = false;
	
    private bool pause = false;
    private bool ContinuePressed;
    private bool HelpScreenIsShown;
    private int elapsedTime;
    private GameObject Spawn;
    private GameObject[] Players;

    void Start()
    {
        pause = false;
        HelpScreenIsShown = false;
        Players = GameObject.FindGameObjectsWithTag("Player");
        SetAmmo();
        elapsedTime = 0;       
        Screen.lockCursor = true;
    }   

    void Win()
    {
		//Checkt ob beide Spieler das Ziel erreicht haben
        if(ControllP1.reachEnd && ControllP2.reachEnd)
        {
            Application.LoadLevel("MainMenu");
        }
		//Checkt ob ein Spieler tot ist und macht den anderen zum Gewinner
        if (BattleMode)
        {
            if (ControllP1.dead)
            {
                WinP2.SetActive(true);
            }
            else if (ControllP2.dead)
            {
                WinP1.SetActive(true);
            }
        }
    }

    void Fail()
    {
        if(ControllP1.dead && ControllP2.dead)
        {
            Application.LoadLevel("GameOver");
        }
    }    

    void ShowHelp()
    {
        if (HelpScreenIsShown)
        {
            HelpScreen.SetActive(true);
        }
        if (HelpScreenIsShown && Input.anyKeyDown)
        {
            Debug.Log("AnyKeypressed");
            HelpScreen.SetActive(false);
            HelpScreenIsShown = false;
        }
    }

    void SetAmmo()
    {
        foreach (GameObject Player in Players)
        {
            CubeSpawnP1.CubeAmmo = Player1Ammo;
            CubeSpawnP2.CubeAmmo = Player2Ammo;
        }
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pause == false)
        {
            pause = true;
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
            Screen.lockCursor = false;
            foreach (GameObject Player in Players)
            {
                Player.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pause == true || ContinuePressed == true)
        {
            pause = false;
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
            Screen.lockCursor = true;
            ContinuePressed = false;           

            foreach (GameObject Player in Players)
            {
                Player.SetActive(true);
            }
        }
    }    

    public void ButtonPressed(string Name)
    {
        if (Name == "Continue")
        {
            ContinuePressed = true;
        }
        if (Name == "Help")
        {
            HelpScreenIsShown = true;
        }
        if (Name == "Exit")
        {
            Application.LoadLevel("MainMenu");
            Time.timeScale = 1;
        }
    }
	
	void Update()
    {
        elapsedTime = (int)Time.time;
        Pause();
        ShowHelp();
		Win();
        Fail();

        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Deleted");
            PlayerPrefs.DeleteAll();
        }
    }
}
