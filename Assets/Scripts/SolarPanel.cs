////////////////////////////////////////////
////                                    ////
////   Autor: Christian Langpaap        ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class SolarPanel : MonoBehaviour 
{
	public float LightTime;
	public static bool LightOn = false;
	
    private float LightTimer = 0;
    private bool LightActivated = false;
    private bool Light = false;
    private GameObject LevelLight;

	void Start () 
    {
        LevelLight = GameObject.FindGameObjectWithTag("LevelLight");
	}
	
	void Update () 
    {
        if(LightOn)
        {
            if(!LightActivated)
            {
                Debug.Log("LightActivated false");  
                LightTimer = Time.time + LightTime;
                LightActivated = true;
                LevelLight.GetComponent<Light>().enabled = true;
            }
        }
        if (Time.time >= LightTimer)
        {
            LightOn = false;
            LightActivated = false;
            LevelLight.GetComponent<Light>().enabled = false;
            LightTimer = 0;
        }
	}
}
