using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAI : MonoBehaviour
{
    
    // Public variables
    public GameObject[] Enemies;
    public GameObject[] EnemyMinions;
    public GameObject[] EnemyTowers;

    public GameObject nexus;
    public int speed;
    public int detectionRadius;
    public int attackRadius;
    public int forgettingTime;
    public bool needHelp;

    // Private variables
    private int frameCount;
    private GameObject targetTurret;

    private GameObject targetMinion;
    private GameObject targetPlayer;

    private float distanceTimer;
    private float distanceTimerPlayer;

    // Start is called before the first frame update
    void TurretTarget()
    {    
        GameObject closest = null;
        float closestDistance = 10000;
        float distance = 10000;
        for (int i = 0; i<EnemyTowers.Length; i++)
        {
            if(EnemyTowers[i].activeSelf){
                distance = (EnemyTowers[i].transform.position - gameObject.transform.position).magnitude;
                if (distance < closestDistance )
                {
                    closestDistance = distance;
                    closest = EnemyTowers[i];
                }
            }
        }
        if(closest){
            targetTurret = closest;
        }
        else{
            AttackNexus();
        }
    }

    void MinionTarget(){
        if(targetMinion != null){
            return;
        }
        int closestID = -1;  // if there is no turrets target nexus
        float closestDistance = 10000.0f;
        float distance = 10000.0f;
        for (int i = 0; i<EnemyMinions.Length; i++)
        {
            distance = (EnemyMinions[i].transform.position - gameObject.transform.position).magnitude;
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestID = i;
            }
        }

        if(closestDistance < detectionRadius){
            targetMinion = EnemyMinions[closestID];
            distanceTimer = 0;
        }
    }

    void PlayerTarget(){
        if(targetPlayer != null) return;
        int closestID = -1;  // if there is no turrets target nexus
        float closestDistance = 10000.0f;
        float distance = 10000.0f;
        for (int i = 0; i < Enemies.Length; i++)
        {
            distance = (Enemies[i].transform.position - gameObject.transform.position).magnitude;
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestID = i;
            }
        }
        if(closestDistance < detectionRadius){
            targetPlayer = Enemies[closestID];
            distanceTimerPlayer = 0;
        }
    }

    void AttackMinion(){
        float step = speed * Time.deltaTime;
        float distance = (targetMinion.transform.position - gameObject.transform.position).magnitude;
        
        // Si esta fuera de rango cuenta tiempo
        // para ver si deja de perseguirlo
        if(distance > detectionRadius){
            distanceTimer += Time.deltaTime;
        }

        // Cuando haya pasado el tiempo deja de perseguirlo
        if(distanceTimer % 60 > forgettingTime){
            targetMinion = null;
            distanceTimer = 0;
        }
        else{
            // Si no esta a distancia de ataque se acerca a el
            if(distance > attackRadius){
                transform.position = Vector3.MoveTowards(transform.position, targetMinion.transform.position, step);
            }
        }
    }

    void AttackTurret(){
        if(targetTurret && targetTurret.activeSelf){
            float step = speed * Time.deltaTime;
            float distance = (targetTurret.transform.position - gameObject.transform.position).magnitude;

            // Si no esta a distancia de ataque se acerca a el
            if(distance > attackRadius){
                transform.position = Vector3.MoveTowards(transform.position, targetTurret.transform.position, step);
            }
        }
        else{
            targetTurret = null;
            TurretTarget();
        }
    }

    void AttackNexus(){
        float step = speed * Time.deltaTime;
        float distance = (nexus.transform.position - gameObject.transform.position).magnitude;

        // Si no esta a distancia de ataque se acerca a el
        if(distance > attackRadius){
            transform.position = Vector3.MoveTowards(transform.position,nexus.transform.position, step);
        }
    }
    void AttackPlayer(){
        PlayerTarget();
        if(targetPlayer == null){
            needHelp = false;
            return;
        } 

        float step = speed * Time.deltaTime;
        float distance = (targetPlayer.transform.position - gameObject.transform.position).magnitude;
        if(distance > detectionRadius){
            distanceTimerPlayer += Time.deltaTime;
        }

        // Cuando haya pasado el tiempo deja de perseguirlo
        if(distanceTimerPlayer % 60 > forgettingTime){
            needHelp = false;
            targetPlayer = null;
            distanceTimerPlayer = 0;
        }
        else
        {
            if(distance > attackRadius){
                transform.position = Vector3.MoveTowards(transform.position, targetPlayer.transform.position, step);
            }    
        }
    }

    void Start()
    {
        if(this.tag.Contains("Enemy")){
            Enemies = GameObject.FindGameObjectsWithTag("Ally");
            EnemyMinions = GameObject.FindGameObjectsWithTag("AllyMinion");
            EnemyTowers = GameObject.FindGameObjectsWithTag("AllyTower");
            nexus = GameObject.FindGameObjectWithTag("AllyNexus");
        }
        else{
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            EnemyMinions = GameObject.FindGameObjectsWithTag("EnemyMinion");
            EnemyTowers = GameObject.FindGameObjectsWithTag("EnemyTower");
            nexus = GameObject.FindGameObjectWithTag("EnemyNexus");
        }
        frameCount = 0;
        distanceTimer = 0;
        needHelp = false;
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;
        
        if(needHelp){
            AttackPlayer();
        }
        else{
            // IA funcionara cada 5 frames
            if (frameCount > 5){
                TurretTarget();
                MinionTarget();
                frameCount = 0;
            }        
            if(targetMinion != null){
                print("ataco minions");
                AttackMinion();
            }
            else if(targetTurret){   
                print("ataco torre");
                AttackTurret();
            }
            else{
                print("ataco nexo");
                AttackNexus();
            }
        }
    }
}
