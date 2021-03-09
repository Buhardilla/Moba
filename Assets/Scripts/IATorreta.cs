using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IATorreta : MonoBehaviour
{
    public enum EstadosIA {NEARESTALLYMINION,NEARESTENEMYMINION,CHAMPION};
    public EstadosIA estado = EstadosIA.NEARESTALLYMINION; //se inicia para atacar al mas cercano


    Disparar torreta;
    public GameObject[] Allies;
    public GameObject[] Enemies;
    public GameObject[] AllyMinions;
    public GameObject[] EnemyMinions;
    // Start is called before the first frame update
    public float range = 1;
    void Start()
    {
        Allies = GameObject.FindGameObjectsWithTag("Ally");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        AllyMinions = GameObject.FindGameObjectsWithTag("AllyMinion");
        EnemyMinions = GameObject.FindGameObjectsWithTag("EnemyMinion");
        torreta = this.GetComponent<Disparar>();
        torreta.origen = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        switch (estado) {
            case EstadosIA.NEARESTALLYMINION:
                TargetNearest(AllyMinions);
                break;
            case EstadosIA.NEARESTENEMYMINION:
                TargetNearest(EnemyMinions);
                break;
            case EstadosIA.CHAMPION:
                TargetNearest(Enemies);
                break;
        }
        torreta.Shoot();
    }

    void TargetNearest(GameObject[] array) {
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
