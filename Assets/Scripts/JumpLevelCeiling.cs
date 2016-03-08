////////////////////////////////////////////
////                                    ////
////   Autor: Jonas Fischer             ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class JumpLevelCeiling : MonoBehaviour
{
    public GameObject Player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.GetComponent<ControllP1>().verticalVelocity = 0;
        }
    }
}
