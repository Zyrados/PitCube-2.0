////////////////////////////////////////////
////                                    ////
////   Autor: Christian Langpaap        ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class GameManagerMenu : MonoBehaviour 
{
    public int Playerlifes;
    public GameObject NewGameScreen;
    public GameObject KoopScreen;
    public GameObject Info;

	private GameObject Player;
    private int LoadedLifes;
    private int LoadedLevel;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	void SetLife()
    {
        ControllP1.Lifepoints = Playerlifes;
    }

    void CheckSingleplayer()
    {
        if(Teleport.Singleplayer)
        {
            NewGameScreen.SetActive(true);
            Screen.lockCursor = false;
            Player.SetActive(false);
        }
        if (Teleport.Koop)
        {
            KoopScreen.SetActive(true);
            Screen.lockCursor = false;
            Player.SetActive(false);
        }
    }

    public void ButtonPressed(string Name)
    {
        if (Name == "New Game")
        {
            SetLife();
            Application.LoadLevel(1);
            Teleport.Singleplayer = false;
        }
        if (Name == "Load")
        {
            LoadedLevel = PlayerPrefs.GetInt("Savegame");
            LoadedLifes = PlayerPrefs.GetInt("Life");
            Playerlifes = LoadedLifes;
            Application.LoadLevel(LoadedLevel);
            SetLife();
            Teleport.Singleplayer = false;
        }
        if (Name == "Koop")
        {
            Application.LoadLevel("Koop");
            
            Teleport.Koop = false;
        }
        if (Name == "BattleMode")
        {
            Application.LoadLevel("BattleMode");
            
            Teleport.Koop = false;
        }
        if (Name == "Info")
        {
            Info = GameObject.Find("Info");
            Info.SetActive(false);
           
        }
    }
	
	void Update()
    {
        CheckSingleplayer();
    }
}
