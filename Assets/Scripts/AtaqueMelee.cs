using System.Collections;
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
    public float cooldownBasico = 2f;
    public float cooldownHab1;
    public float cooldownHab2;
    public float cooldownHab3;
    public float cooldownHechizo;

    public float timerBasico = 0;
    public float activarTimer = 0.5f;

    List<GameObject> enemigosEnRango;
    GameObject masCercano;

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
        //Pendiente hacer animación de ataque
        Debug.Log("ataca");

        //Para el movimiento del personaje
        

        //Activa el collider del ataque
        hitboxMelee.enabled = true;
        timerBasico = activarTimer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Enemy"))
        {
            print("Yo, "+this.gameObject.name+" colisiono con "+other.gameObject.name);
            enemigosEnRango.Add(other.gameObject);
        }
    }

    void Update()
    {
        stats = GetComponent<CharacterStats>();
        jugador = GetComponent<Transform>();


        if(enemigosEnRango.ToArray().Length > 0)
        {
            print("enemigos en rango" + enemigosEnRango.ToArray());
            masCercano = enemigosEnRango[0];
            foreach(GameObject enemigo in enemigosEnRango)
            {
                if(Vector3.Distance(this.transform.position, enemigo.transform.position) < Vector3.Distance(this.transform.position, masCercano.transform.position))
                {
                    masCercano = enemigo;
                }
            }
            print(this.gameObject.name);
            masCercano.GetComponent<CharacterStats>().RecibeDmg(5,this.gameObject);
            enemigosEnRango.Clear();
        }


        if(Input.GetAxisRaw("GatilloDer") != 0 && cooldownBasico <= 0)
        {
            if(gatDerPulsado == false)
            {
                AtaqueBasico();
                gatDerPulsado = true;
            }
        }
        if(Input.GetAxisRaw("GatilloDer") == 0)
        {
            gatDerPulsado = false;
        }

        if(Input.GetAxisRaw("GatilloIzq") != 0)
        {
            if(gatIzqPulsado == false)
            {
                //Gatillo izquierdo hace cosas
                Debug.Log("Gatillo izquierdo pulsado");
                gatIzqPulsado = true;
            }
        }
        if(Input.GetAxisRaw("GatilloIzq") == 0)
        {
            gatIzqPulsado = false;
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
        }
    }
}
