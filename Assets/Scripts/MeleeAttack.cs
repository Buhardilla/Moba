using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float cadencia;
    private float timerBasico;
    void Awake()
    {
        cadencia = GetComponent<CharacterStats>().AS.getStat();
    }
    public void Attack(GameObject target){
        timerBasico += Time.deltaTime;
        if (timerBasico >= cadencia)
        {
            timerBasico = 0.0f;
            target.GetComponent<CharacterStats>().RecibeDmg( GetComponent<CharacterStats>().AD.getStat(), gameObject);
        }
    }
}
