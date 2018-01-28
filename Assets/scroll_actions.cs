using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll_actions : MonoBehaviour {

    GameObject gate_left, gate_right;

	// Use this for initialization
	void Start () {
        gate_left = GameObject.Find("Gate_Left");
        gate_right = GameObject.Find("Gate_Right");
        Invoke("destroy_scroll", 60.0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    

    public void grabbed_scroll()
    {
        CancelInvoke("destroy_sroll");
        gate_left.SetActive(false);
        gate_right.SetActive(false);
    }

    public void dropped_scroll()
    {
        Invoke("destroy_scroll", 60.0f);
        gate_left.SetActive(true);
        gate_right.SetActive(true);
    }
}
