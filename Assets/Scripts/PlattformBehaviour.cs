////////////////////////////////////////////
////                                    ////
////   Autor: Jonas Fischer             ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class PlattformBehaviour : MonoBehaviour 
{
    public float WaypointSetOff;
    public int CurrentWaypoint = 1;
    public int NumberOfWaypoints = 2;
    public enum WaypointID { A, B };
    public WaypointID WID = WaypointID.A;
    public float Speed = 2f;
	
    private Vector3 relativePos;
    private Rigidbody rigidbody;

	void Start ()
    {
        rigidbody = this.GetComponent<Rigidbody>();
	}

	void Update ()
    {
		//Bewegt die Plattform entlang des eingestellten Pfades
        relativePos = GameObject.FindGameObjectWithTag("PWaypoint" + WID + CurrentWaypoint).transform.position - this.transform.position;
        this.transform.Translate(relativePos.normalized * Speed * Time.deltaTime);
        if (Vector3.Distance(this.transform.position, GameObject.FindGameObjectWithTag("PWaypoint"+ WID + CurrentWaypoint).transform.position)<= WaypointSetOff)
        {
            CurrentWaypoint++;
            if (CurrentWaypoint > 2)
            {
                this.CurrentWaypoint = 1;
            }
        }
	}
}
