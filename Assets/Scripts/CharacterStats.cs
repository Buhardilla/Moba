using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public GameObject[] previoustowers;
    public bool hidden = false;
    public int bushes = -1;
    public GameObject Minimapicon;

    Vector3 initialPos = new Vector3(0, 1, 0);
    public int currentHealth { get; private set; }
    public int currentMana { get; private set; }
    public int expMax;

    public Stat level;
    public Stat exp;

    public Stat health;
    public Stat regenhealth;

    public Stat mana;
    public Stat regenMana;

    public int money;
    public int killreward;
    public float rewardrange;

    public int experience;
    public int expreward;
    public Stat AD;
    public Stat ADpen;
    public Stat ADR;

    public Stat AP;
    public Stat APpen;
    public Stat MR;

    public Stat AS;
    public Stat VEL;
    public Stat CDR;
    public Stat RNG;

    public float timerMuerte = 0;
    GameObject[] enemies;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        currentHealth = health.getStat();
        currentMana = mana.getStat();

        if(gameObject.tag.Contains("Enemy")){
            enemies = GameObject.FindGameObjectsWithTag("Ally");
        }
        else{
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
    }
    void Update()
    {
        if(timerMuerte > 0)
        {
            timerMuerte -= Time.deltaTime;
            if (timerMuerte <= 0)
            {
                this.GetComponent<AtaqueMelee>().enabled = true;
                //this.GetComponent<Movimiento>().enabled = true;
                this.GetComponent<Transform>().position = initialPos;
            }
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            currentHealth -= 10;
            print("me dolio wey");
            currentMana -= 5;
        }
        
    }
    public void RecibeDmg(float dmg, GameObject other)
    {
        //si es un nexo o torre compruebo si se han muerto las torres anteriores, en otro caso no hago comprobación
        if(((gameObject.tag.Contains("Tower") || gameObject.tag.Contains("Nexus")) && activeTowers() == 0) || (!gameObject.tag.Contains("Tower") && !gameObject.tag.Contains("Nexus"))){

            currentHealth -= (int) dmg;

            if(currentHealth <= 0)
            {
                Morir(other);
            }
        }
    }

    public int activeTowers(){
        int count = 0;
        foreach (GameObject tower in previoustowers)
        {
            if(tower.activeSelf){
                ++count;
            }
        }
        print(count);
        return count;
    }

    public virtual void Morir(GameObject other)
    {
        if(gameObject.tag.Contains("Minion")){
            gameObject.SetActive(false);
            print("se ha muerto una torre");
        }
        else if(gameObject.tag.Contains("Tower")){
            gameObject.SetActive(false);
            //GameObject.FindGameObjectsWithTag("");
        }
        else if(gameObject.tag.Contains("Nexus")){
            print("fin del juego, llamar al servidor y que jose haga cosas");
        }
        else{
            print("soy un jugador y me muero");
        }
        //TODO aquí habría que llamar al servidor
        giveReward(other);
    }

    public void giveReward(GameObject other){
        foreach (GameObject enemy in enemies)
        {
            if(enemy == other){
                enemy.GetComponent<CharacterStats>().money += killreward;
                enemy.GetComponent<CharacterStats>().experience += expreward;
            }
            else if(Vector3.Distance(enemy.transform.position,transform.position) < rewardrange){
                enemy.GetComponent<CharacterStats>().money += killreward / 2;
                enemy.GetComponent<CharacterStats>().experience += expreward;
            }
        }
    }
}
