using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateVisibility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        findEnemies(); 
    }
     private void findEnemies(){
        GameObject[] Allies = GameObject.FindGameObjectsWithTag("Ally");
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach(GameObject ally in Enemies){
            ally.GetComponent<MeshRenderer>().enabled = false;
        }

        foreach (GameObject ally in Allies)
        {
            PlayerData dataAlly = ally.GetComponent<PlayerData>();
            foreach (GameObject enemy in Enemies)
            {
                PlayerData dataEnemy = enemy.GetComponent<PlayerData>();
                    if(dataAlly.hidden){
                        if(!dataEnemy.hidden){
                            enemy.GetComponent<MeshRenderer>().enabled = true;
                        }
                        else{
                            if(dataAlly.bushes == dataEnemy.bushes){
                                enemy.GetComponent<MeshRenderer>().enabled = true;
                            }
                        }
                    }
                    else{
                        if(!dataEnemy.hidden){
                            enemy.GetComponent<MeshRenderer>().enabled = true;
                        }
                    }
            }
        }
    }
}