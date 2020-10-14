using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    
    public GameObject player;
    public GameObject start;
    public GameObject finish;
    public float Distance;
    private void Start()
    {
       transform.position = new Vector3(0, 0, -10);
    }
    void FixedUpdate()
    {
     
        if(player.transform.position.x>start.transform.position.x-Distance  && player.transform.position.x<finish.transform.position.x)
        {
            transform.position = new Vector3(player.transform.position.x+Distance, transform.position.y, -10);
        }
       
    }
}
