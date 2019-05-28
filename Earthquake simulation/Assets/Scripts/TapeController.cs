using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TapeController : MonoBehaviour {

    private Rigidbody rgb;
	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
		if(rgb.IsSleeping())
        {
            gameObject.GetComponent<Canvas>().enabled = true;

        }
        else{
            gameObject.GetComponent<Canvas>().enabled = false;
        }
    }
}
