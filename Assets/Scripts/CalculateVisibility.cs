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
    }

    // Update is called once per frame
    void Update()
    {
        AllyMinions = GameObject.FindGameObjectsWithTag("AllyMinion");
        EnemyMinions = GameObject.FindGameObjectsWithTag("EnemyMinion");
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
            areEnemiesVisible(ally, ally.GetComponent<CharacterStats>(),Enemies);
            areEnemiesVisible(ally, ally.GetComponent<CharacterStats>(),EnemyMinions);
        }
        foreach (GameObject minion in AllyMinions)
        {
            areEnemiesVisible(minion, minion.GetComponent<CharacterStats>(),Enemies);
            areEnemiesVisible(minion, minion.GetComponent<CharacterStats>(),EnemyMinions);
        }
    }

    private void areEnemiesVisible(GameObject ally, CharacterStats allyData, GameObject[] enemyArray){
            foreach (GameObject enemy in enemyArray)
            {
            CharacterStats dataEnemy = enemy.GetComponent<CharacterStats>();

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