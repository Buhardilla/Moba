using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public float amount = 1;

    // Start is called before the first frame update
    void Start()
    {
        transform.position  = player.transform.position + offset;    
    }


    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {
        Vector3 newposition = player.transform.position + offset;
        transform.position = newposition;
        transform.LookAt(player.transform);
    }
}
