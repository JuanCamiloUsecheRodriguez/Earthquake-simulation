using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolScript : MonoBehaviour {
    private Vector3 p;
    private GameObject game;
    private GameController script;
    private bool organized = false;
    // Use this for initialization
    void Start () {
        p = transform.position;
        game = GameObject.FindGameObjectWithTag("Game");
        script = game.GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        int level = script.level;
        if(level == 4 && !organized)
        {
           transform.position = p;
           organized = true;
        }
    }
}
