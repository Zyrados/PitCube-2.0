////////////////////////////////////////////
////                                    ////
////   Autor: Jonas Fischer             ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class EraserBullet : MonoBehaviour 
{
    public AudioClip CubeDestroyed;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cube")
        {
            AudioSource.PlayClipAtPoint(CubeDestroyed, this.transform.position,0.10f);
            Destroy(other.gameObject);
            GridManager.Grid.Remove(other.gameObject.transform.position);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "BubbleCube" || other.gameObject.tag == "JumpCube")
        {
            AudioSource.PlayClipAtPoint(CubeDestroyed, this.transform.position);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
