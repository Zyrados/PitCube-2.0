using UnityEngine;
using System.Collections;

public class Movie : MonoBehaviour {

    Renderer r;
    MovieTexture movie; 
	void Start () 
    {
        r = GetComponent<Renderer>();
        movie = (MovieTexture)r.material.mainTexture;
        movie.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            movie.Play();
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" && movie.isPlaying)
        {
            movie.Pause();
        }
    }
}
