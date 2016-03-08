////////////////////////////////////////////
////                                    ////
////   Autor: Jonas Fischer             ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class ColorCube : MonoBehaviour 
{
    public enum ColorInstatiated { green, blue, red, yellow, none, turqouis, orange, pink };
    public ColorInstatiated ci;
    public GameObject GreenCubePrefab;
    public GameObject BlueCubePrefab;
    public GameObject RedCubePrefab;
    public GameObject YellowCubePrefab;
    public GameObject PinkCubePrefab;
    public GameObject TurqouisCubePrefab;
    public GameObject OrangeCubePrefab;
    public bool Match = false;

    private int spawnedCubeID = 0;
    private GameObject newCube;
    private Vector3 newCubePosition;
    public Material[] ColorCubes;
    private ColorManager colorManager;

	void Start () 
    {
        //newCubePosition = this.gameObject.transform.position + new Vector3(0f, 1f, 0f);
        newCubePosition = this.gameObject.transform.position;
        ci = ColorInstatiated.none;
        colorManager = GameObject.FindGameObjectWithTag("ColorManager").GetComponent<ColorManager>();
        
	}
	
    void OnTriggerEnter(Collider other)
    {
        if (!Match)
        {
            if (other.gameObject.tag == "ColorBullet")
            {
                //Erstellt einen ColorCube entsprechend der Farbe der kollidierenden ColorBullet
                if (ci == ColorInstatiated.none)
                {
                    if (other.GetComponent<ColorBullet>().BC == ColorBullet.BulletColor.blue)
                    {
                        newCube = (GameObject)Instantiate(BlueCubePrefab, newCubePosition, Quaternion.identity);
                        ci = ColorInstatiated.blue;
                        
                    }
                    if (other.GetComponent<ColorBullet>().BC == ColorBullet.BulletColor.green)
                    {
                        newCube = (GameObject)Instantiate(GreenCubePrefab, newCubePosition, Quaternion.identity);
                        ci = ColorInstatiated.green;
                    }
                    if (other.GetComponent<ColorBullet>().BC == ColorBullet.BulletColor.red)
                    {
                        newCube = (GameObject)Instantiate(RedCubePrefab, newCubePosition, Quaternion.identity);
                        ci = ColorInstatiated.red;
                    }
                    if (other.GetComponent<ColorBullet>().BC == ColorBullet.BulletColor.yellow)
                    {
                        newCube = (GameObject)Instantiate(YellowCubePrefab, newCubePosition, Quaternion.identity);
                        ci = ColorInstatiated.yellow;
                    }

                }
                else if (ci != ColorInstatiated.none)
                {
                    if (colorManager.MixColors(other.gameObject, this.gameObject))
                    {
                        if (colorManager.cts == ColorManager.CubeToSpawn.orange)
                        {
                            newCube.GetComponent<Renderer>().material = ColorCubes[0];
                            ci = ColorInstatiated.orange;
                        }
                        else if (colorManager.cts == ColorManager.CubeToSpawn.pink)
                        {
                            newCube.GetComponent<Renderer>().material= ColorCubes[1];
                            ci = ColorInstatiated.pink;
                        }
                        else if (colorManager.cts == ColorManager.CubeToSpawn.turqouis)
                        {
                            newCube.GetComponent<Renderer>().material = ColorCubes[2];
                            ci = ColorInstatiated.turqouis;
                            
                        }
                    }
                    else if (!colorManager.MixColors(other.gameObject, this.gameObject))
                    {
                        this.GetComponent<AudioSource>().Play();
                        Destroy(newCube);
                        ci = ColorInstatiated.none;
                    }
                }
            } 
        }      
    }
	
	void Update ()
    {
		//Überprüft ob die Farben der beiden ColorCubes identisch sind
        if (this.gameObject.tag == "CCTurqouis" && ci == ColorInstatiated.turqouis)
        {
            Match = true;
        }
        else if (this.gameObject.tag == "CCOrange" && ci == ColorInstatiated.orange)
        {
            Match = true;
        }
        else if (this.gameObject.tag == "CCPink" && ci == ColorInstatiated.pink)
        {
            Match = true;
        }
	}
}
