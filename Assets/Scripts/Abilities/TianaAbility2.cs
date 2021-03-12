using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TianaAbility2 : Ability
{
    Collider[] enemiesHit;
    public override void CastAbility()
    {
        print("esto ocurre");
        if (currentCooldown <= 0)
        {
            if (enemiesHit != null)
            {
                Array.Clear(enemiesHit, 0, enemiesHit.Length);
            }
            this.UpdateCooldown(this.GetCurrentCooldown());
            
            print("tiro R");
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.currentCooldown > 0)
        {
            enemiesHit = Physics.OverlapSphere(this.transform.position, this.range);
            foreach (Collider enemy in enemiesHit)
            {
                if (this.tag.Equals("Ally"))
                {
                    if (enemy.gameObject.tag.Contains("Enemy") && !enemy.gameObject.tag.Contains("Tower"))
                    {
                        //enemy.gameObject.GetComponent<StatusEffects>().SetStatus("slow", 1);
                        enemy.gameObject.GetComponent<CharacterStats>().RecibeDmg(this.damage, this.gameObject);
                        enemy.gameObject.GetComponent<CharacterStats>().ReduceMana(this.manaCost);
                    }
                }
                else if (this.tag.Equals("Enemy"))
                {
                    if (enemy.gameObject.tag.Contains("Ally") && !enemy.gameObject.tag.Contains("Tower"))
                    {
                        //enemy.gameObject.GetComponent<StatusEffects>().SetStatus("slow", 1);
                        enemy.gameObject.GetComponent<CharacterStats>().RecibeDmg(this.damage, this.gameObject);
                        enemy.gameObject.GetComponent<CharacterStats>().ReduceMana(this.manaCost);
                    }
                }
            }
            this.currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0)
            {
                currentCooldown = 0;
            }
        }
    }
}
