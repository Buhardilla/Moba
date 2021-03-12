using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleStats : MonoBehaviour
{
    public float exp;
    public float health;
    public float regenhealth;
    public float mana;
    public float regenMana;
    public float AD;
    public float ADpen;
    public float ADR;
    public float AP;
    public float APpen;
    public float MR;
    public float AS;
    public float VEL;
    public float CDR;
    public float RNG; // OWO 
    public float Crit;
    public float RV;

    CharacterStats characterStats;
    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        
        characterStats.exp.setScale(exp);
        characterStats.health.setScale(health);
        characterStats.regenHealth.setScale(regenhealth);
        characterStats.mana.setScale(mana);
        characterStats.regenMana.setScale(regenMana);
        characterStats.AD.setScale(AD);
        characterStats.ADpen.setScale(ADpen);
        characterStats.ADR.setScale(ADR);
        characterStats.AP.setScale(AP);
        characterStats.APpen.setScale(APpen);
        characterStats.MR.setScale(MR);
        characterStats.AS.setScale(AS);
        characterStats.VEL.setScale(VEL);
        characterStats.CDR.setScale(CDR);
        characterStats.RNG.setScale(RNG);
        characterStats.Crit.setScale(Crit);
        characterStats.RV.setScale(RV);
    }
}