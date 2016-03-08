////////////////////////////////////////////
////                                    ////
////   Autor: Christian Langpaap        ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{
	void HandleGameOver()
    {
        if(Input.anyKeyDown)
        {
            Application.LoadLevel("Credits");
        }
    }
	
	void Update () 
    {
        HandleGameOver();
	}
}
