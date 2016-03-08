////////////////////////////////////////////
////                                    ////
////   Autor: Jonas Fischer             ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;
//using UnityEditor.Animations;

public class ColorDoor : MonoBehaviour
{
    public AudioSource Open;
    //public GameObject CubeDoor;
    //private GameObject[] DoorElements;
    public AudioSource Correct;
    
	
    private bool doorIsOpen = false;

    void Awake()
    {
        //CubeDoor = this.gameObject;
        //DoorElements = GameObject.FindGameObjectsWithTag("DoorElement");
        
    }

    private void OpenDoor()
    {
        Correct.Play();        
        doorIsOpen = true;
        this.GetComponent<Animation>().Play();
        //Debug.Log("Test");
        //foreach (var GameObject in DoorElements)
        //{
        //    CubeDoorElement.DoorOpen = true;
        //}               
        Open.Play(); 
    }

	void Update () 
    {
        //Überprüft ob alle Farben richtig sind und öffnet dann die Tür
        if (GameObject.FindGameObjectWithTag("CCPink").GetComponent<ColorCube>().Match == true &&
            GameObject.FindGameObjectWithTag("CCTurqouis").GetComponent<ColorCube>().Match == true &&
            GameObject.FindGameObjectWithTag("CCOrange").GetComponent<ColorCube>().Match == true)
        {
            if (!doorIsOpen)
            {
                OpenDoor();
            }
        }

        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    Debug.Log("Button Pressed");
        //    OpenDoor();
        //}
	
	}
}
