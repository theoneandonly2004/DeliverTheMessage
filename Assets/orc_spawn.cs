using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orc_spawn : MonoBehaviour {

    public GameObject orc;
    int spawned_count = 0;
    public int max_spawn = 5;
    Transform spawn_pos;

	// Use this for initialization
	void Start () {
        spawn_pos = this.transform;
        for(int x =0; x < 3; x++)
        {
            spawn_orc();            
        }
        InvokeRepeating("spawn_orc", 10.0f, 10.0f);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void spawn_orc()
    {
        if(spawned_count < max_spawn)
        {
            GameObject spawned = Instantiate(orc,spawn_pos.position,Quaternion.identity);
            //spawned.GetComponent<Monster_Controller>().current_monster.set_spawned_point(this.gameObject);
            spawned_count++;
        }
        
    }

    public void decrease_spawned_count()
    {
        this.spawned_count -= 1;
    }
}
