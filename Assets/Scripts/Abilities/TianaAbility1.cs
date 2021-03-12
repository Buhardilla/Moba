using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TianaAbility1 : Ability
{
    

    public float[] cd = {5f, 3f, 2f };
    public override void CastAbility()
    {
        Collider[] enemiesHit;
        this.UpdateCooldown(this.GetCurrentCooldown());
        enemiesHit = Physics.OverlapSphere(this.transform.position, this.range);
        foreach (Collider enemy in enemiesHit)
        {
            if (enemy.gameObject.tag.Contains("Enemy"))
            {
                enemy.gameObject.GetComponent<CharacterStats>().RecibeDmg(this.damage, this.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //this.SetLevel(1);
        //this.SetRange(5);
        //this.SetDamage(10);
        //this.SetCooldowns(cd);
        //this.UpdateCooldown(0);
        //this.UpdateStats();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.currentCooldown > 0)
        {
            this.currentCooldown -= Time.deltaTime;
            if(currentCooldown <= 0)
            {

            }
        }
    }
}
