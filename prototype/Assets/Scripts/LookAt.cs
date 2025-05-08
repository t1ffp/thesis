using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        //direction.y = 0; 
        transform.forward = direction;
    }
}
