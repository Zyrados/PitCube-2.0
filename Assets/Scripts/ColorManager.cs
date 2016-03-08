////////////////////////////////////////////
////                                    ////
////   Autor: Jonas Fischer             ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;


public class ColorManager : MonoBehaviour 
{
    public enum CubeToSpawn { turqouis, pink, orange };
    public CubeToSpawn cts;

	//Vergleicht die Farben des Cubes mit den Farben der Bullets und gibt die zu spawnende Farbe für den Cube zurück
    public bool MixColors(GameObject colorBullet, GameObject cubeB)
    {
        if (colorBullet.GetComponent<ColorBullet>().BC == ColorBullet.BulletColor.green && cubeB.GetComponent<ColorCube>().ci == ColorCube.ColorInstatiated.blue
            || colorBullet.GetComponent<ColorBullet>().BC == ColorBullet.BulletColor.blue && cubeB.GetComponent<ColorCube>().ci == ColorCube.ColorInstatiated.green)
        {
            Debug.Log("Mix Turkis");
            cts = CubeToSpawn.turqouis;
            GameObject.Destroy(colorBullet);
            return true;
        }
        else if (colorBullet.GetComponent<ColorBullet>().BC == ColorBullet.BulletColor.blue && cubeB.GetComponent<ColorCube>().ci == ColorCube.ColorInstatiated.red
                || colorBullet.GetComponent<ColorBullet>().BC == ColorBullet.BulletColor.red && cubeB.GetComponent<ColorCube>().ci == ColorCube.ColorInstatiated.blue)
        {
            cts = CubeToSpawn.pink;
            GameObject.Destroy(colorBullet);
            return true;
        }
        else if (colorBullet.GetComponent<ColorBullet>().BC == ColorBullet.BulletColor.red && cubeB.GetComponent<ColorCube>().ci == ColorCube.ColorInstatiated.yellow
                || colorBullet.GetComponent<ColorBullet>().BC == ColorBullet.BulletColor.yellow && cubeB.GetComponent<ColorCube>().ci == ColorCube.ColorInstatiated.red)
        {
            cts = CubeToSpawn.orange;
            GameObject.Destroy(colorBullet);
            return true;
        }
        else
        {
            GameObject.Destroy(colorBullet);
            return false;
        }
    }
}
