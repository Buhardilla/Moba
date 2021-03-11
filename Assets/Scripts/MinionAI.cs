using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAI : MonoBehaviour
{
    public enum MinionState{MOVING,COLLISION, ATTACK}

    public MinionState  state = MinionState.MOVING;

    public Collider collide;
    
    // Public variables
    public GameObject[] Enemies;
    public GameObject[] EnemyMinions;
    public GameObject[] EnemyTowers;

    public GameObject[] nexus;
    public int speed;
    public int detectionRadius;
    private int attackRange;
    public int forgettingTime;
    public bool needHelp;

    // Private variables
    private int frameCount;
    private GameObject target;

    private float distanceTimer;
    private float distanceTimerPlayer;

    public Vector3 moveDirection = new Vector3(0,0,0);
    public float step;

    private float evaderoffset = 100;
    private string enemytag;
    void evadeCollider(){ 
        if(collide){
            moveDirection = transform.position - collide.transform.position;
            if (moveDirection.z >= 0)
            {
                moveDirection.z += evaderoffset;
            }
            else{
                moveDirection.z -= evaderoffset;
            }   
            if(moveDirection.x >= 0){
                moveDirection.x -= evaderoffset;
            }
            else{
                moveDirection.x += evaderoffset;
            }
            moveDirection.y = transform.position.y;
            moveDirection = Vector3.MoveTowards(transform.position, moveDirection, step);
            transform.position = moveDirection;  
        }
    }
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
            target = closest;
        }
        else{
            AttackNexus();
        }
    }

    void MinionTarget(){
        if(target != null){
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
            target = EnemyMinions[closestID];
            distanceTimer = 0;
        }
    }

    void PlayerTarget(){
        if(target != null) return;
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
            target = Enemies[closestID];
            distanceTimerPlayer = 0;
        }
    }

    void AttackMinion(){
        float distance = (target.transform.position - gameObject.transform.position).magnitude;
        
        // Si esta fuera de rango cuenta tiempo
        // para ver si deja de perseguirlo
        if(distance > detectionRadius){
            distanceTimer += Time.deltaTime;
        }

        // Cuando haya pasado el tiempo deja de perseguirlo
        if(distanceTimer % 60 > forgettingTime){
            target = null;
            distanceTimer = 0;
        }
        else{
            isInRange(distance,target);
        }
    }

    void AttackTurret(){
        if(target && target.activeSelf){
            float distance = (target.transform.position - gameObject.transform.position).magnitude;

            isInRange(distance,target);
        }
        else{
            target = null;
            TurretTarget();
        }
    }

    void AttackNexus(){
        target = nexus[0];
        float distance = (target.transform.position - gameObject.transform.position).magnitude;
        isInRange(distance - 3, target);
    }
    void AttackPlayer(){
        PlayerTarget();
        if(target == null){
            needHelp = false;
            return;
        } 

        float distance = (target.transform.position - gameObject.transform.position).magnitude;
        if(distance > detectionRadius){
            distanceTimerPlayer += Time.deltaTime;
        }

        // Cuando haya pasado el tiempo deja de perseguirlo
        if(distanceTimerPlayer % 60 > forgettingTime){
            needHelp = false;
            target = null;
            distanceTimerPlayer = 0;
        }
        else
        {
            isInRange(distance,target);
        }
    }
    private void moveTowardsTarget(GameObject target){
        Vector3 dir = target.transform.position;
        dir.y = transform.position.y;
        moveDirection = Vector3.MoveTowards(transform.position, dir, step);
        transform.position = moveDirection;

        dir -= transform.position;
        var rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, step);
    }

    private void isInRange(float distance, GameObject target){
        // Si no esta a distancia de ataque se acerca a el
        if(distance > attackRange){
            moveTowardsTarget(target);
        }
        else{
            state = MinionState.ATTACK;
        }
    }
    void Awake()
    {
        if(this.tag.Contains("Enemy")){
            enemytag="Ally";
        }
        else{
            enemytag="Enemy";
        }
        Enemies = GameObject.FindGameObjectsWithTag(enemytag);
        EnemyTowers = GameObject.FindGameObjectsWithTag(enemytag + "Tower");
        nexus = GameObject.FindGameObjectsWithTag(enemytag + "Nexus");
        frameCount = 0;
        distanceTimer = 0;
        needHelp = false;
        attackRange = gameObject.GetComponent<CharacterStats>().AS.getStat();
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;
        EnemyMinions = GameObject.FindGameObjectsWithTag(enemytag + "Minion");
        switch (state)
        {
            case MinionState.MOVING:
                if(needHelp){
                    step = speed * Time.deltaTime;
                    AttackPlayer();
                }
                else{
                    step = speed * Time.deltaTime;
                    // IA funcionara cada 5 frames
                    if (frameCount > 5){
                        AttackNexus();
                        TurretTarget();
                        MinionTarget();
                        frameCount = 0;
                    } 
                    if(target){  
                        // AttackNexus();  
                        if(target.tag.Contains("Minion")){
                            AttackMinion();
                        }
                        else if(target.tag.Contains("Tower")){   
                            AttackTurret();
                        }
                        else{
                            AttackNexus();
                        }
                    }
                }
                break;
            case MinionState.COLLISION:
                    evadeCollider();

                break;
            case MinionState.ATTACK:
                if(target && !target.activeSelf){
                    state = MinionState.MOVING;
                }
                else{
                    if(GetComponent<Disparar>()){
                        GetComponent<Disparar>().setTarget(target);
                        GetComponent<Disparar>().Shoot();
                    }
                    else{
                        GetComponent<MeleeAttack>().Attack(target);
                    }
                }
            break;
        }        
    }
}
