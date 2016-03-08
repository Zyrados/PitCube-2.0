////////////////////////////////////////////
////                                    ////
////   Autor: Jonas Fischer             ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class JumpCube : MonoBehaviour 
{
    public AudioSource Jump;
    public GameObject Player1;
    public GameObject Player2;
    public float JumpPower = 10f;

    void Start()
    {
		Player1 = GameObject.Find ("Player");
		if (Player1 = null) {
			Player1 = GameObject.Find ("Player 1 Koop").gameObject;
			Player2 = GameObject.Find ("Player 2 Koop").gameObject;
		}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player 1 Koop" || other.gameObject.name == "Player")
        {
            other.GetComponent<ControllP1>().verticalVelocity = JumpPower;
            Jump.Play();
        }
        else if (other.gameObject.name == "Player 2 Koop")
        {
            other.GetComponent<ControllP2>().verticalVelocity = JumpPower;
            Jump.Play();
        }
        //else if (other.gameObject.tag != "Acid")
        //{
        //    Destroy(other.gameObject);
        //}
    }
}
