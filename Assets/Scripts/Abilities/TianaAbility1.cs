using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TianaAbility1 : Ability
{
    

    public float[] cd = {5f, 3f, 2f };
    public Animator animate;
    public override void CastAbility()
    {
        if (currentCooldown <= 0)
        {
            animate.SetTrigger("Ability 1");
            Collider[] enemiesHit;
            this.UpdateCooldown(this.GetCurrentCooldown());
            enemiesHit = Physics.OverlapSphere(this.transform.position, this.range);
            foreach (Collider enemy in enemiesHit)
            {
                if (this.tag.Equals("Ally"))
                {
                    if (enemy.gameObject.tag.Contains("Enemy") && !enemy.gameObject.tag.Contains("Tower"))
                    {
                        enemy.gameObject.GetComponent<CharacterStats>().RecibeDmg(this.damage, this.gameObject);
                        enemy.gameObject.GetComponent<CharacterStats>().ReduceMana(this.manaCost);
                    }
                }
                else if (this.tag.Equals("Enemy"))
                {
                    if (enemy.gameObject.tag.Contains("Ally") && !enemy.gameObject.tag.Contains("Tower"))
                    {
                        enemy.gameObject.GetComponent<CharacterStats>().RecibeDmg(this.damage, this.gameObject);
                        enemy.gameObject.GetComponent<CharacterStats>().ReduceMana(this.manaCost);
                    }
                }
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
                currentCooldown = 0;
            }
        }
    }
}
