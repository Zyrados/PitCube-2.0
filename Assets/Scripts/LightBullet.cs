////////////////////////////////////////////
////                                    ////
////   Autor: Christian Langpaap        ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class LightBullet : MonoBehaviour 
{
    void OnCollisionEnter(Collision other)
    {        
        if(other.gameObject.tag == "SolarPanel")
        {
            SolarPanel.LightOn = true;
            Destroy(this.gameObject);
        }
        else
        { 
            Destroy(this.gameObject);
        }
    }
}
