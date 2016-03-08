////////////////////////////////////////////
////                                    ////
////   Autor: Christian Langpaap        ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class Acid : MonoBehaviour
{
	public static bool leaveExitZone;

	void AcidRise()
    {
        if (leaveExitZone)
        {
            this.transform.Translate(0, 0.01f, 0);
        }
    }
	
	void Update () 
    {
        AcidRise();
	}
}
