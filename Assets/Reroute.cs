using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reroute : MonoBehaviour
{

    public Vector3 offset;
    private MinionAI AI;
    private Vector3 newDirection;
    bool cont = false;
    void Start()
    {
        AI = gameObject.GetComponentInParent<MinionAI>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Bush" && other.tag != "Projectile"){
            GetComponentInParent<MinionAI>().state = MinionAI.MinionState.COLLISION;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag != "Bush" && other.tag != "Projectile"){
            GetComponentInParent<MinionAI>().state = MinionAI.MinionState.MOVING;
        }
    }
}
