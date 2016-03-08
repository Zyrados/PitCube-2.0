////////////////////////////////////////////
////                                    ////
////   Autor: Christian Langpaap        ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

public class GameManager : MonoBehaviour 
{
	public GameObject PauseMenu;
	public GameObject SaveLabel;
    public GameObject HelpScreen;
	public int Player1Ammo;
    public int Player2Ammo;
	public bool ColorLevel = false;
    public bool LightLevel = false;
    public bool BubbleLevel = false;
    public bool JumpLevel = false;
    public static bool Cheat = false;
    private float rotate = 1f;

	private bool ContinuePressed;
    private bool HelpScreenIsShown;
	private int elapsedTime;
	private GameObject Spawn;
    private GameObject[] Players;
	private bool pause = false;
    
	void Start()
    {
        pause = false;
        HelpScreenIsShown = false;
        Players = GameObject.FindGameObjectsWithTag("Player");
        SetAmmo();
        elapsedTime = 0;
        SaveScoreAndTime();
        Screen.lockCursor = true;
    }
	
    void SaveGame()
    {
        PlayerPrefs.SetInt("Savegame", Application.loadedLevel);
        PlayerPrefs.SetInt("Life", ControllP1.Lifepoints);
        SaveLabel.SetActive(true);
    }

    void ShowHelp()
    {
        if(HelpScreenIsShown)
        {
            HelpScreen.SetActive(true);
        }        
       
        if (HelpScreenIsShown && Input.GetKeyDown(KeyCode.Space))
        {
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
        else if (Input.GetKeyDown(KeyCode.Escape) && pause == true || ContinuePressed == true )
        {
            pause = false;
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
            Screen.lockCursor = true;
            ContinuePressed = false;
            SaveLabel.SetActive(false);
           
            foreach (GameObject Player in Players)
            {
                Player.SetActive(true);
            }
        }
    }

    public void SaveScoreAndTime()
    {
        if (ControllP1.reachEnd == true || Cheat)
        {
            //switch(Application.loadedLevel)
            //{
            //    case 1:
            //        PlayerPrefs.SetInt("TimeLevel1", elapsedTime);
            //        PlayerPrefs.SetInt("CubesUsedLevel1", CubeSpawnP1.CubeInUse);
            //        break;

            //    case 2:
            //        PlayerPrefs.SetInt("TimeLevel2", elapsedTime);
            //        PlayerPrefs.SetInt("CubesUsedLevel2", CubeSpawnP1.CubeInUse);
            //        break;

            //    case 3:
            //        PlayerPrefs.SetInt("TimeLevel3", elapsedTime);
            //        PlayerPrefs.SetInt("CubesUsedLevel3", CubeSpawnP1.CubeInUse);
            //        break;

            //    case 4:
            //        PlayerPrefs.SetInt("TimeLevel4", elapsedTime);
            //        PlayerPrefs.SetInt("CubesUsedLevel4", CubeSpawnP1.CubeInUse);
            //        break;

            //    case 5:
            //        PlayerPrefs.SetInt("TimeLevel5", elapsedTime);
            //        PlayerPrefs.SetInt("CubesUsedLevel5", CubeSpawnP1.CubeInUse);
            //        break;
            //    case 6:
            //        PlayerPrefs.SetInt("TimeLevel6", elapsedTime);
            //        PlayerPrefs.SetInt("CubesUsedLevel6", CubeSpawnP1.CubeInUse);
            //        break;
            //    case 7:
            //        PlayerPrefs.SetInt("TimeLevel7", elapsedTime);
            //        PlayerPrefs.SetInt("CubesUsedLevel7", CubeSpawnP1.CubeInUse);
            //        break;
            //    case 8:
            //        PlayerPrefs.SetInt("TimeLevel8", elapsedTime);
            //        PlayerPrefs.SetInt("CubesUsedLevel8", CubeSpawnP1.CubeInUse);
            //        break;
            //}
			
            PlayerPrefs.SetInt("Time", elapsedTime);
            PlayerPrefs.SetInt("CubesUsed", CubeSpawnP1.CubeInUse);
            PlayerPrefs.SetInt("actualLevel", Application.loadedLevel);
            ControllP1.reachEnd = false;
            Cheat = false;
        }
    }

    public void ButtonPressed(string Name)
    {
        if(Name == "Continue")
        {
            ContinuePressed = true;
        }
        if(Name == "Save")
        {
            SaveGame();
        }
        if(Name == "Help")
        {
            HelpScreenIsShown = true;
        }
        if (HelpScreenIsShown == false)
        {
            if (Name == "Exit")
            {
                Application.LoadLevel("MainMenuDemo");
                Time.timeScale = 1;
            }
        }
    }
	
	void Update()
    {
        elapsedTime = (int)Time.timeSinceLevelLoad;
        Pause();
        ShowHelp();
        SaveScoreAndTime();
        TurnLevel();
	}

    private void TurnLevel()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Rotate");
            GameObject Level = GameObject.Find("LevelGeometry");
            for (int i = 0; i < 360; i++)
            {
                Level.transform.Rotate(Vector3.left, rotate * Time.deltaTime);   
            }
            
        }
    }
}
