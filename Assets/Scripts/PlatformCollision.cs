////////////////////////////////////////////
////                                    ////
////   Autor: Jonas Fischer             ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class PlatformCollision : MonoBehaviour 
{
    public AudioSource CubeDestroyed;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            Destroy(collision.gameObject);
            GridManager.Grid.Remove(this.gameObject.transform.position);
            CubeDestroyed.Play();
        }
    }
}
