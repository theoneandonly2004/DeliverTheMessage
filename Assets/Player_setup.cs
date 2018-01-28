using UnityEngine;
using UnityEngine.Networking;


public class Player_setup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] components_to_disable;

    void Start()
    {
        if(!isLocalPlayer)
        {
            for(int x = 0; x < components_to_disable.Length;x++)
            {
                components_to_disable[x].enabled = false;   
            }
        }
    }
}
