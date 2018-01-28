using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_collision : MonoBehaviour {

    bool can_harm = true;

	// Use this for initialization
	void Start () {
        Invoke("destroy_object", 60.0f);		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "floor")
        {
            Invoke("destroy_object", 5.0f);
        }
        else if(other.gameObject.tag == "shield")
        {
            CancelInvoke("destroy_object");
            Invoke("destroy_object", 10.0f);            
            this.transform.parent = other.gameObject.transform.GetChild(0);
            Destroy(this.GetComponent<Rigidbody>());
            Destroy(this.GetComponent<BoxCollider>());
            print("yay i hit a shield");
            can_harm = false;

        }
        else if(other.gameObject.tag == "player")
        {
            if (!can_harm)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void destroy_object()
    {
        Destroy(this.gameObject);
    }
}


/*
    * 
    *  private void OnTriggerEnter(Collider other)
   {
       if(other.tag == "Shield" && !has_collided)
       {
           
       }

   }
    * 
    * */
