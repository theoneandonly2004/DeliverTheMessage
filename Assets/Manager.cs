using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
    public Dictionary<string,Monster_details> monsters;
    public Dictionary<string, Weapon_details> weapons;
    public int count_to_drop = 0;

    void add_monster(string name, float health, float damage)
    {
        Monster_details monster = new Monster_details(name, health, damage);
        monsters.Add(name, monster);
    }

    void add_weapons(string name, float damage, bool is_ranged)
    {
        Weapon_details weapon = new Weapon_details(name, damage, is_ranged);
        weapons.Add(name, weapon);
    }

    private void Awake()
    {
        monsters = new Dictionary<string, Monster_details>();
        add_monster("player", 200, 10);
        add_monster("bruiser", 200, 200);
        add_monster("bruiser(Clone)", 200, 200);
        add_monster("scout", 20, 20);

        weapons = new Dictionary<string, Weapon_details>();
        add_weapons("arrow", 20, true);
        add_weapons("sword", 50,false);

    }

    // Use this for initialization
    void Start () {
        count_to_drop = Random.Range(1, 10);            
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
