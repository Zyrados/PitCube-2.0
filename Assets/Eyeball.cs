using UnityEngine;
using System.Collections;

public class Eyeball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(GameObject.Find("Camera P1").transform.position);
	}
}
