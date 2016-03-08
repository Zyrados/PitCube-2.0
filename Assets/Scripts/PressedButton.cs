////////////////////////////////////////////
////                                    ////
////   Autor: Christian Langpaap        ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class PressedButton : MonoBehaviour 
{
	public GameObject Button;
	
    private GameObject GameManager;
    private GameObject KoopManager;
	private GameObject GameManagerMenu;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");

        if (!GameManager)
        {
            GameManagerMenu = GameObject.Find("GameManagerMenu");
        }
        if (!GameManager || !GameManagerMenu)
        {
            KoopManager = GameObject.Find("KoopManager");
        }
	}

    void OnClick()
    {
		if (GameManagerMenu)
        {
            GameManagerMenu.GetComponent<GameManagerMenu>().ButtonPressed(Button.name);
        }
        else if (GameManager)
        {
            GameManager.GetComponent<GameManager>().ButtonPressed(Button.name);
        }
        else if (KoopManager)
        {
            KoopManager.GetComponent<KoopManager>().ButtonPressed(Button.name);
        }
	}
}
