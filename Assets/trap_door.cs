using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_door : MonoBehaviour {

    public GameObject arrow_obj,spawn_point;
    public int arrow_rows = 100;
    public int arrow_cols = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Transform pos = spawn_point.transform;
            float x = pos.position.x;
            float z = pos.position.z;

            for (int count = 0; count < arrow_rows; count++)
            {
                for (int countz = 0; countz < arrow_cols; countz++)
                {
                    GameObject current_arrow = Instantiate(arrow_obj, new Vector3(x + count, 300, z + countz), Quaternion.identity);
                    current_arrow.transform.Rotate(new Vector3(90,0,0));
                }
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject[] orcs;
        Debug.Log("i collided with " + other.gameObject.name);
        if(other.gameObject.name == "[VRTK][AUTOGEN][BodyColliderContainer]")
        {
            Debug.Log("now spawning arrows and alerting the orcs");
            orcs = GameObject.FindGameObjectsWithTag("enemy");

            for(int count = 0; count < orcs.Length;count++)
            {
                orcs[count].GetComponent<Monster_attack>().chase_player();
                orcs[count].GetComponent<Wander>().enabled = false;
            }

            Transform pos = spawn_point.transform;
            float x = pos.position.x;
            float z = pos.position.z;

            this.GetComponent<Renderer>().material.color = Color.red;
            

            for(int count = 0; count < arrow_rows;count++)
            {
                for (int countz = 0; countz < arrow_cols; countz++)
                {
                    GameObject arrow = Instantiate(arrow_obj, new Vector3(x + count, 50, z + countz), Quaternion.identity);
                    arrow.GetComponent<Rigidbody>().AddForce(-Vector3.up*10000);
                }
            }

            
        }
    }

   
}
