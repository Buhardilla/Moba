using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reroute : MonoBehaviour
{

    public Vector3 offset;
    private MinionAI AI;
    private Vector3 newDirection;
    bool cont = false;
    float distance;
    Vector3 bounds;
    void Start()
    {
        AI = gameObject.GetComponentInParent<MinionAI>();
    }
    void OnTriggerEnter(Collider other)
    {   
        Vector3 targetDir = transform.position - other.transform.position;
		float dir = Vector3.Dot(targetDir, transform.up);
		if (dir < 0f) {
            if((other.gameObject.tag != "Bush" && other.gameObject.tag != "Projectile" && other.gameObject.tag != "Untagged") &&  GetComponentInParent<MinionAI>().state == MinionAI.MinionState.MOVING){
                GetComponentInParent<MinionAI>().state = MinionAI.MinionState.COLLISION;
                GetComponentInParent<MinionAI>().collide = other;
                GetComponentInParent<MinionAI>().moveDirection = targetDir;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if((other.tag != "Bush" && other.tag != "Projectile")&&  GetComponentInParent<MinionAI>().state == MinionAI.MinionState.COLLISION){
            GetComponentInParent<MinionAI>().state = MinionAI.MinionState.MOVING;
            GetComponentInParent<MinionAI>().collide = null;
        }
    }
}
