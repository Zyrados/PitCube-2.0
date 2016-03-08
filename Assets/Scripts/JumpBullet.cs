////////////////////////////////////////////
////                                    ////
////   Autor: Jonas Fischer             ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class JumpBullet : MonoBehaviour 
{
    public GameObject JumpCubePrefab;
    public float TimeTillCube = 20f;
	
    private float currentTime;

    void Start()
    {
        currentTime = TimeTillCube;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Weapon" && other.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);     
        }
    }
	
	void Update()
    {
        currentTime = currentTime - 1;
        if (currentTime <= 0)
        {
            Instantiate(JumpCubePrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            currentTime = TimeTillCube;
        }
    }
}
