﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMelee : MonoBehaviour
{
    public Collider hitboxMelee;
    public LayerMask capaEnemigos;
    CharacterStats stats;
    Transform jugador;

    private bool gatDerPulsado = false;
    private bool gatIzqPulsado = false;
    public float cooldownBasico = 30f;
    public float cooldownHab1;
    public float cooldownHab2;
    public float cooldownHab3;
    public float cooldownHechizo;

    public float timerBasico = 0;
    public float activarTimer = 0.5f;

    List<GameObject> enemigosEnRango;
    GameObject masCercano;

    public bool hasAttacked = false;
    public Animator animate;
    public bool move;
    private void Start()
    {
        enemigosEnRango = new List<GameObject>();
    }

    void Awake()
    {
        hitboxMelee.enabled = false;
    }

    void AtaqueBasico()
    {
        //Activa el collider del ataque
        hitboxMelee.enabled = true;
        timerBasico = activarTimer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Enemy"))
        {
            enemigosEnRango.Add(other.gameObject);
        }
    }

    void Update()
    {
        stats = GetComponent<CharacterStats>();
        jugador = GetComponent<Transform>();


        if(enemigosEnRango.ToArray().Length > 0)
        {
            masCercano = enemigosEnRango[0];
            foreach(GameObject enemigo in enemigosEnRango)
            {
                if(Vector3.Distance(this.transform.position, enemigo.transform.position) < Vector3.Distance(this.transform.position, masCercano.transform.position))
                {
                    masCercano = enemigo;
                }
            }
            if (!hasAttacked)
            {
                masCercano.GetComponent<CharacterStats>().RecibeDmg(5, this.gameObject);
                enemigosEnRango.Clear();
                hasAttacked = true;
            }
            
        }


        if(Input.GetAxisRaw("GatilloDer") != 0 && cooldownBasico <= 0)
        {
            print("attack");
            if(gatDerPulsado == false)
            {
                hasAttacked = false;

                if(animate){
                    animate.SetTrigger("Attack");
                }
                AtaqueBasico();
                gatDerPulsado = true;
            }
        }

        if(cooldownBasico > 0)
        {
            cooldownBasico -= Time.deltaTime;
        }

        if(timerBasico > 0)
        {
            timerBasico -= Time.deltaTime;
            if(timerBasico <= 0)
            {
                hitboxMelee.enabled = false;
            }
            if(move){
                hitboxMelee.enabled = false;
                move = false;
            }
        }
    }
}
