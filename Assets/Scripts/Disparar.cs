using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    private float cadencia;
    public GameObject target;
    public GameObject proyectil;
    List<GameObject> misSpawns = new List<GameObject>();
    public float temporizadordisparo = 0.0f;
    public Vector3 origen;
    private int bulletcount;
    private float damage;

    void Start()
    {
        damage = this.gameObject.GetComponent<CharacterStats>().AD.getStat();        
        cadencia = gameObject.GetComponent<CharacterStats>().AS.getStat();
    }

   public void Shoot()
    {
        if (target) {
            temporizadordisparo += Time.deltaTime;
            if (temporizadordisparo >= cadencia)
            {
                temporizadordisparo = 0.0f;
                spawnproyectil();
            }
        }
    }

   
    void spawnproyectil()
    {
        misSpawns.Clear();
        misSpawns.Add(Instantiate(proyectil, origen, Quaternion.Euler(0,0,0)) as GameObject);
        bulletcount = misSpawns.ToArray().Length-1;
        misSpawns[bulletcount].GetComponent<TrackingProjectile>().FireProjectile(gameObject, target, damage);
    }

    public void setTarget(GameObject e_target)
    {
        target = e_target;
    }

}
