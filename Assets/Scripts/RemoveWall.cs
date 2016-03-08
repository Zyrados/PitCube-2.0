using UnityEngine;
using System.Collections;

public class RemoveWall : MonoBehaviour 
{
    public AudioClip CubeDestroyed;
    public GameObject Waypoint1;
    public GameObject Waypoint2;

    public float Speed;

    private float CurrentWaypoint = 1;
    private Vector3 relativePos;


	void Start () 
    {
        SetAtStart();       
	}

    private void SetAtStart()
    {
        this.transform.position = Waypoint1.transform.position;	
    }
	
	// Update is called once per frame
	void Update ()
    {
        //this.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime);

		
        relativePos = Waypoint1.transform.position - this.transform.position;
        this.transform.position = Vector3.MoveTowards(this.transform.position, GameObject.Find("Waypoint" + CurrentWaypoint).transform.position, Speed*Time.deltaTime);


        if (Vector3.Distance(this.gameObject.transform.position, GameObject.Find("Waypoint" + CurrentWaypoint).transform.position) < 1)
        {
            Debug.Log(CurrentWaypoint);
            CurrentWaypoint++;
            if (CurrentWaypoint > 2)
            {
                CurrentWaypoint = 1;
            }
        }
                                
	}
	
	


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            Debug.Log("Collision with " + other.gameObject.name);
            AudioSource.PlayClipAtPoint(CubeDestroyed, this.transform.position, 0.10f);
            Destroy(other.gameObject);
            GridManager.Grid.Remove(other.gameObject.transform.position);

            CubeSpawnP1.CubeAmmo++;
        }
        else if (other.gameObject.tag == "BubbleCube" || other.gameObject.tag == "JumpCube")
        {
            AudioSource.PlayClipAtPoint(CubeDestroyed, this.transform.position);
            Destroy(other.gameObject);

            CubeSpawnP1.CubeAmmo++;
        }
    
    }
}
