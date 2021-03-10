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
    string enemiestag;
    void Start()
    {
        if (gameObject.tag.Contains("Enemy"))
        {
            enemiestag = "Ally";
        }
        else {
            enemiestag = "Enemy";
        }
        torreta = this.GetComponent<Disparar>();
        torreta.origen = transform.position;
    }
    // Update is called once per frame
    void Update()
    {

        TargetMinions = GameObject.FindGameObjectsWithTag(enemiestag + "Minion");
        Enemies = GameObject.FindGameObjectsWithTag(enemiestag);

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

        GameObject curTarget = null; //current target
        float closestDist = 0;
        float dist = 0;
        for (int i = 0; i < array.Length; i++) {
            dist = (array[i].transform.position - transform.position).magnitude;
            if(curTarget){
                if (dist < closestDist) {
                    curTarget = array[i];
                    closestDist = dist;
                }

            }
            else{
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
