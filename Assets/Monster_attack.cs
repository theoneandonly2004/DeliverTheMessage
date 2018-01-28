using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_attack : MonoBehaviour {

    NavMeshAgent agent;
    bool is_chasing = false;
    public GameObject player;

	// Use this for initialization
	void Start () {
        agent = this.GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(is_chasing)
        {
            agent.destination = player.transform.position;
        }
	}

    public void chase_player()
    {
        is_chasing = true;
        agent.enabled = true;
        agent.destination = player.transform.position;
    }
}
