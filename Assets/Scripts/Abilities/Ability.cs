using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public float[] cooldown;
    public float currentCooldown;
    public float damage;
    public float dmgScaling;
    public float range;
    public int level;
    public string dmgType;
    public float adRatio;
    public float apRatio;

    public abstract void CastAbility();

    public void UpdateStats()
    {
        damage += (dmgScaling * level);
        level++;
    }

    public void UpdateCooldown(float cd)
    {
        currentCooldown = cd;
    }

    public void SetCooldowns(float[] cd)
    {
        cooldown = cd;
    }
    public float GetCurrentCooldown()
    {
        return cooldown[level];
    }

    public void SetDamage(float dmg)
    {
        damage = dmg;
    }

    public void SetRange(float rng)
    {
        range = rng;
    }

    public void SetLevel(int lvl)
    {
        level = lvl;
    }

    public void setScaling(float scl)
    {
        dmgScaling = scl;
    }
}
