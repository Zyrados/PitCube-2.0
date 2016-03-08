using UnityEngine;
using System.Collections;

public class CubeDoorElement : MonoBehaviour {

    public static bool DoorOpen = false;
    public Animation doorAnimation;
    public AnimationClip doorOpen;
    private Animator ani;
	void Start () 
    {
        ani = GetComponent<Animator>();
	}
	
	
	void Update () 
    {
        if(DoorOpen)
        {
            ani.SetBool("DoorOpen", true);
            GameObject.Destroy(this.gameObject);
        }
	}
}
