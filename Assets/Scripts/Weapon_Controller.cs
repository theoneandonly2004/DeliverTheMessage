using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_details
{
    public string name;
    public bool is_ranged;
    public float damage;

    public Weapon_details(string name, float damage, bool is_ranged)
    {
        this.name = name;
        this.is_ranged = is_ranged;
        this.damage = damage;
    }
}

public class Weapon_Controller : MonoBehaviour {
    string name;
    Weapon_details current_weapon;

	// Use this for initialization
	void Start () {
        name = this.gameObject.name;
        current_weapon = GameObject.Find("GameManager").GetComponent<Manager>().weapons[name];
        Debug.Log(current_weapon.damage);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
