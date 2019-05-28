using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour {

    private GameObject[] tables;
    private bool showTables;
    private GameObject[] tools;
    private bool showTools;
    private GameObject[] collectables;
    private bool showCollectables;




    // Use this for initialization
    void Start () {
        tables = GameObject.FindGameObjectsWithTag("Table");
        showTables = false;
        tools = GameObject.FindGameObjectsWithTag("Tool");
        showTools = true;
        collectables = GameObject.FindGameObjectsWithTag("FirstAid");
        showCollectables = true;
	}
	
	// Update is called once per frame
	void Update () {

        if( Time.time >= 5f )
        {
            if (showTables)
            {
                showTables = false;
                foreach (GameObject obj in tables)
                {

                    obj.SetActive(false);
                }

            }

            if (showTools)
            {
                showTools = false;
                foreach (GameObject obj in tools)
                {

                    obj.SetActive(false);
                }
            }

            if (showCollectables)
            {
                showCollectables = false;
                foreach (GameObject obj in collectables)
                {
                    obj.SetActive(false);
                }
            }
           
        }
		
	}
}
