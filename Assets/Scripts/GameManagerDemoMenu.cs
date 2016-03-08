////////////////////////////////////////////
////                                    ////
////   Autor: Christian Langpaap        ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class GameManagerDemoMenu : MonoBehaviour 
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
            SetLife();
            Application.LoadLevel("TrainingGround");
            Teleport.Singleplayer = false;
        }
       
    }
  
	void Update()
    {
        CheckSingleplayer();
    }
}
