////////////////////////////////////////////
////                                    ////
////   Autor: Jonas Fischer             ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class BubbleBullet : MonoBehaviour 
{
    public AudioClip CubeDestroyed;
    public GameObject BubbleCubePrefab;
    public float TimeTillCube = 20f;
	
    private float currentTime;

    void Start()
    {
        currentTime = TimeTillCube;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "BubbleCube")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(CubeDestroyed, this.transform.position);
        }
        else if (other.gameObject.name != "Weapon" && other.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);    
        }
    }
	
	void Update()
    {
        currentTime = currentTime - 1;
        if (currentTime <= 0)
        {
            Instantiate(BubbleCubePrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            currentTime = TimeTillCube; 
        }
    }
}
