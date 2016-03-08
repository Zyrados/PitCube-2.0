////////////////////////////////////////////
////                                    ////
////   Autor: Jonas Fischer             ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class ColorBullet : MonoBehaviour
{
    public enum BulletColor { blue, green, yellow, red, none };
    public BulletColor BC;
	public float CubeSize = 1f;

    void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
