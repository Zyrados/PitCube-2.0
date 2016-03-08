////////////////////////////////////////////
////                                    ////
////   Autor: Jonas Fischer             ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class KillSphere : MonoBehaviour 
{
    public AudioSource CubeDestroyed;
    public enum PathID { A, B, C, D, E, F, G };
    public PathID CurrentPathID;
    public int NumberOfWaypoints = 4;
    public float RotationSpeed = 1f;
    public float Speed = 2f;
	
    private int CurrentWaypoint = 1;
    private Vector3 currentVector;
    private Vector3 relativePos;
    private Quaternion rotation;
	
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "ColorBullet")
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Cube")
        {
            CubeDestroyed.Play();
            Destroy(other.gameObject);
            GridManager.Grid.Remove(other.gameObject.transform.position);
        }
   }
   
   	void Update ()
    {
		//Bewegt die Killsphere entlang des eingestellten Pfades
        relativePos = GameObject.FindGameObjectWithTag("Waypoint" + CurrentPathID + CurrentWaypoint).transform.position - this.transform.position;
        this.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        rotation = this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(GameObject.FindGameObjectWithTag("Waypoint" + CurrentPathID + CurrentWaypoint).transform.position - this.transform.position), RotationSpeed * Time.deltaTime);
        transform.rotation = rotation;
		
        if (Vector3.Distance(this.gameObject.transform.position, GameObject.FindGameObjectWithTag("Waypoint" + CurrentPathID + CurrentWaypoint).transform.position) < 1)
        {
            CurrentWaypoint++;
            if (CurrentWaypoint > NumberOfWaypoints)
            {
                CurrentWaypoint = 1;
            }
        }           
	}
}
