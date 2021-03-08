using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public int danyo = 10;
    public float cadencia;
    public GameObject target;
    public GameObject proyectil;
    List<GameObject> misSpawns = new List<GameObject>();
    public float temporizadordisparo = 0.0f;
    public Vector3 origen;
    public int bulletcount;
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
        misSpawns[bulletcount].GetComponent<TrackingProjectile>().FireProjectile(gameObject, target, danyo);
    }

    public void setTarget(GameObject e_target)
    {
        target = e_target;
    }

}
