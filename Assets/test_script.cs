﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
       		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "blade")
        {
            Debug.Log("oh no i wasdestroyed byt he mighty blade");
        }
    }
}
