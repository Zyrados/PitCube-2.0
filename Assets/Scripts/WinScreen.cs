////////////////////////////////////////////
////                                    ////
////   Autor: Christian Langpaap        ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class WinScreen : MonoBehaviour 
{	
	public TextMesh CubesUsed;
    public TextMesh TimeNeeded;
	
    private int cubes;
    private int time;
    private int previousLevel;

	void Start () 
    {
        GetData();
        this.CubesUsed.text = cubes.ToString();
        this.TimeNeeded.text = time.ToString();
	}
	
	void GetData()
    {   
        previousLevel = PlayerPrefs.GetInt("actualLevel");
        cubes = PlayerPrefs.GetInt("CubesUsed");
       time = PlayerPrefs.GetInt("Time");
        //switch(previousLevel)
        //{
        //    case 1:
        //        cubes = PlayerPrefs.GetInt("CubesUsedLevel1");
        //        time = PlayerPrefs.GetInt("TimeLevel1");
        //        break;

        //    case 2:
        //        cubes = PlayerPrefs.GetInt("CubesUsed");
        //        time = PlayerPrefs.GetInt("TimeLevel2");
        //        break;

        //    case 3:
        //       cubes = PlayerPrefs.GetInt("CubesUsed");
        //       time = PlayerPrefs.GetInt("TimeLevel3");
        //        break;

        //    case 4:
        //        cubes = PlayerPrefs.GetInt("CubesUsed");
        //        time = PlayerPrefs.GetInt("TimeLevel4");
        //        break;

        //    case 5:
        //        cubes = PlayerPrefs.GetInt("CubesUsed");
        //        time = PlayerPrefs.GetInt("TimeLevel5");
        //        break;

        //    case 6:
        //        cubes = PlayerPrefs.GetInt("CubesUsed");
        //        time = PlayerPrefs.GetInt("TimeLevel6");
        //        break;

        //    case 7:
        //        cubes = PlayerPrefs.GetInt("CubesUsed");
        //        time = PlayerPrefs.GetInt("TimeLevel7");
        //        break;

        //    case 8:
        //        cubes = PlayerPrefs.GetInt("CubesUsed");
        //        time = PlayerPrefs.GetInt("TimeLevel8");
        //        break;
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            int nextLevel = previousLevel + 1;
            Application.LoadLevel(nextLevel);
		}
    }
}
