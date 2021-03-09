using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IATorreta : MonoBehaviour
{
    public enum EstadosIA {NEARESTMINION,CHAMPION};
    public EstadosIA estado;//se inicia para atacar al mas cercano


    Disparar torreta;
    public GameObject[] TargetMinions;
    public GameObject[] Enemies;
    public float range;
    void Start()
    {
        if (gameObject.tag.Contains("Enemy"))
        {
            TargetMinions = GameObject.FindGameObjectsWithTag("AllyMinion");
            Enemies = GameObject.FindGameObjectsWithTag("Ally");
        }
        else {
            TargetMinions = GameObject.FindGameObjectsWithTag("EnemyMinion");
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
        torreta = this.GetComponent<Disparar>();
        torreta.origen = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        switch (estado) {
            case EstadosIA.NEARESTMINION:
                TargetNearest(TargetMinions);
                if (!torreta.target) { 
                    TargetNearest(Enemies);
                }
                break;
            case EstadosIA.CHAMPION:
                TargetObject(torreta.target);
                break;
        }
        torreta.Shoot();
    }

    void TargetNearest(GameObject[] array) {
        if(array.Length > 0){
            GameObject curTarget = array[0]; //current target
            float closestDist = (array[0].transform.position - transform.position).magnitude;
            float dist = 0;
            for (int i = 1; i < array.Length; i++) {
                dist = (array[i].transform.position - transform.position).magnitude;
                if (dist < closestDist) {
                    curTarget = array[i];
                    closestDist = dist;
                }
            }
            if( closestDist > range ){
                torreta.setTarget(null);
            }
            else{
                torreta.setTarget(curTarget);
            }
        }
    }


    void TargetObject(GameObject enemy)
    {
        if (enemy)
        {
            
            float dist = (enemy.transform.position - transform.position).magnitude;
            if (dist < range)
            {
                torreta.setTarget(enemy);
                estado = EstadosIA.CHAMPION;
            }
            else {
                estado = EstadosIA.NEARESTMINION;
            }
        }
        else {
            estado = EstadosIA.NEARESTMINION;
        }
        
    }
}
