﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffects : MonoBehaviour
{
   
    public float stunTimer = 0;
    public float rootTimer = 0;
    public float slowTimer = 0;
    public float knockupTimer = 0;
    public float slowPercentage = 0.4f;
    public void SetStatus(string status, float duration)
    {
        switch (status)
        {
            case ("stun"):
                print("llega");
                this.GetComponent<Controller>().enabled = false;
                this.GetComponent<AtaqueMelee>().enabled = false;
                stunTimer = duration;
                break;

            case ("root"):
                this.GetComponent<Controller>().enabled = false;
                rootTimer = duration;
                break;

            case ("slow"):
                this.GetComponent<Controller>().Mspeed *= slowPercentage;
                break;

            case ("knockup"):
                //this.GetComponent<Transform>().transform.position = Vector3.Lerp();
                break;
        }
    }

    void Update()
    {
        if (stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
            if (stunTimer <= 0)
            {
                this.GetComponent<Controller>().enabled = true;
                this.GetComponent<AtaqueMelee>().enabled = true;
            }
        }

        if (rootTimer > 0)
        {
            rootTimer -= Time.deltaTime;
            if (rootTimer <= 0)
            {
                this.GetComponent<Controller>().enabled = true;
            }
        }

        if (slowTimer > 0)
        {
            slowTimer -= Time.deltaTime;
            if (slowTimer <= 0)
            {
                this.GetComponent<Controller>().enabled = true;
            }
        }
        if (knockupTimer > 0)
        {
            knockupTimer -= Time.deltaTime;
            if (knockupTimer <= 0)
            {
                this.GetComponent<Controller>().enabled = true;
            }
        }
    }
}
