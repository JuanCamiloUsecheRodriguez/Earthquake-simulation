﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyCrusher : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
