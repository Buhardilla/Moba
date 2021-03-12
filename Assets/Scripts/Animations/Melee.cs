using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    // Start is called before the first frame update
    public bool attack;
    Animator an;
    public GameObject minion;


    void Start()
    {
        an = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if((int)minion.GetComponent<MinionAI>().state == 2) an.SetTrigger("Attack");
    }
}
