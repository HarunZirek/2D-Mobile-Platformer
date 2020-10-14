using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "HE" || coll.gameObject.name == "SHE")
        {
            player.GetComponent<playables>().health -= 1;
        }
    }
}
