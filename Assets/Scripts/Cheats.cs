////////////////////////////////////////////
////                                    ////
////   Autor: Christian Langpaap        ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class Cheats : MonoBehaviour 
{
	private string[] cheatCodeAmmo;
    private string[] cheatCodeNext;
    private string[] cheatCodeLife;
    private int indexAmmo;
    private int indexNext;
    private int indexLife;
	
    void Start()
    {
        cheatCodeAmmo = new string[] {"a","m","m","o"};
        cheatCodeNext = new string[] { "n", "e", "x", "t" };
        cheatCodeLife = new string[] { "l", "i", "f", "e" };
        indexAmmo = 0;
        indexNext = 0;
        indexLife = 0;
	}
	
    void Update() 
	{
		if (Input.anyKeyDown) 
        {
			if (Input.GetKeyDown(cheatCodeAmmo[indexAmmo])) 
            {
                indexAmmo++;
            }
            else 
            {
                indexAmmo = 0;
            }
			if(Input.GetKeyDown(cheatCodeNext[indexNext]))
            {
                indexNext++;
            }
            else
            {
                indexNext = 0;
            }
            if (Input.GetKeyDown(cheatCodeLife[indexLife]))
            {
                indexLife++;
            }
            else
            {
                indexLife = 0;
            }
        }
        if(indexNext == cheatCodeNext.Length)
        {
			GameManager.Cheat = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().SaveScoreAndTime();
            Application.LoadLevel("WinScene");
            CubeSpawnP1.CubeAmmo = 0;
            indexNext = 0;
        }   
  
        if (indexAmmo == cheatCodeAmmo.Length) 
        {
            CubeSpawnP1.CubeAmmo += 50;
            CubeSpawnP2.CubeAmmo += 50;
            indexAmmo = 0;
        }

        if (indexLife == cheatCodeLife.Length)
        {
            ControllP1.Lifepoints += 5;
            indexLife = 0;
        }   
    }
}
