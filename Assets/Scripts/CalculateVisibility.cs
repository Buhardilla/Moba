using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateVisibility : MonoBehaviour
{
    public GameObject[] Allies;
    public GameObject[] Enemies;
    public GameObject[] AllyMinions;
    public GameObject[] EnemyMinions;
    // Start is called before the first frame update
    void Start()
    {
        Allies = GameObject.FindGameObjectsWithTag("Ally");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        AllyMinions = GameObject.FindGameObjectsWithTag("AllyMinion");
        EnemyMinions = GameObject.FindGameObjectsWithTag("EnemyMinion");
    }

    // Update is called once per frame
    void Update()
    {
        findEnemies(); 
    }
     private void findEnemies(){

        foreach(GameObject enemy in Enemies){
            enemy.GetComponent<MeshRenderer>().enabled = false;
        }
        foreach(GameObject enemy in EnemyMinions){
            enemy.GetComponent<MeshRenderer>().enabled = false;
        }

        foreach (GameObject ally in Allies)
        {
            areEnemiesVisible(ally, ally.GetComponent<PlayerData>(),Enemies);
            areEnemiesVisible(ally, ally.GetComponent<PlayerData>(),EnemyMinions);
        }
        foreach (GameObject minion in AllyMinions)
        {
            areEnemiesVisible(minion, minion.GetComponent<PlayerData>(),Enemies);
            areEnemiesVisible(minion, minion.GetComponent<PlayerData>(),EnemyMinions);
        }
    }

    private void areEnemiesVisible(GameObject ally, PlayerData allyData, GameObject[] enemyArray){
            foreach (GameObject enemy in enemyArray)
            {
                PlayerData dataEnemy = enemy.GetComponent<PlayerData>();

                    if(allyData.hidden && dataEnemy.hidden){
                        if(allyData.bushes == dataEnemy.bushes){
                            enemy.GetComponent<MeshRenderer>().enabled = true;
                        }
                    } 
                    else if(!dataEnemy.hidden){
                        enemy.GetComponent<MeshRenderer>().enabled = true;
                    }
            }
    }
}