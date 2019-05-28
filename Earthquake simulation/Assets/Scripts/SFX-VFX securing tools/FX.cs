using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour {
    private AudioSource audioPlayer;

    // Use this for initialization
    void Start () {
        audioPlayer = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        string otherTag = other.gameObject.tag;
        if (otherTag == "Securable")
        {
            audioPlayer.Play();
        }
           
    }
}
