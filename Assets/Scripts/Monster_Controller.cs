using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_details
{
    public string name;
    public float health;
    public float damage;
    public Transform spawned_point;

    public Monster_details(string name, float health, float damage)
    {
        this.name = name;
        this.health = health;
        this.damage = damage;
    }




}

public class Monster_Controller : MonoBehaviour
{
    string name;
    [HideInInspector]
    public Monster_details current_monster;
    public float current_health;
    public ParticleSystem blood;
    public GameObject scroll;

	// Use this for initialization
	void Start () {
        name = this.gameObject.name;        
        current_monster=GameObject.Find("GameManager").GetComponent<Manager>().monsters[name];
        Debug.Log(current_monster.health);
        current_health = current_monster.health;
        SteamVR_Controller.Input(0).TriggerHapticPulse(500);
    }
	
	// Update is called once per frame
	void Update () {

        if(current_health <= 0)
        {
            this.GetComponent<Animator>().SetBool("is_dead", true);
            this.GetComponent<Wander>().enabled = false;

            this.GetComponent<Monster_Controller>().enabled = false;
            this.GetComponent<NavMeshAgent>().isStopped = true;

            int rand = Random.Range(0, 10);

            if(rand >= 7)
            {
                Instantiate(scroll, this.transform);
            }
            
        }
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "blade")
        {            
            Debug.Log("oh no i was stabbed");          
            
            Debug.Log("current health:" + current_health);           
        }
    }

    




}
