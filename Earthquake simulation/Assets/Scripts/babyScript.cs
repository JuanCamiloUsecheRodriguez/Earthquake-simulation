using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class babyScript : MonoBehaviour {
    private AudioSource audioPlayer;
    public AudioClip babyCry;

    // Use this for initialization
    void Start () {
        audioPlayer = GetComponent<AudioSource>();
    }
	
    public void Cry()
    {
        audioPlayer.PlayOneShot(babyCry, 2f);
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        string otherTag = other.gameObject.tag;
        if (otherTag == "Unsecured")
        {
            Destroy(gameObject);
        }
    }
}
