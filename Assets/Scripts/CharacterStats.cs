using UnityEngine;
using UnityEngine.UI;
public class CharacterStats : MonoBehaviour
{
    public GameObject[] previoustowers;
    public bool hidden = false;
    public int bushes = -1;
    public Sprite Minimapicon;
    public GameObject Portait;

    public GameObject Overlay;

    // Cosas de los objetos
    public int[] IdObjs;

    
    private GameObject Objs;

    Vector3 initialPos = new Vector3(0, 1, 0);
    public int currentHealth { get; private set; }
    public int currentMana { get; private set; }
    public int expMax;

    public int level;
    public Stat exp;
    public int currentExp{get; private set;}

    public Stat health;
    public Stat regenHealth;

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

    public Stat Crit;
    public Stat RV;

    public float timerMuerte = 0;
    GameObject[] enemies;

    void updateStats(){
        int iAD, iADpen, iADR, iAP, iAPpen, iMR, iAS, iVEL, iCDR, iRNG, ihealth, iregenHealth, imana, iregenMana, iCrit, iRV; 
        iAD = iADpen = iADR = iAP = iAPpen = iMR = iAS = iVEL = iCDR = iRNG = ihealth = iregenHealth = imana = iregenMana = iCrit = iRV = 0;

        Objects objStats = Objs.GetComponent<Objects>();
        for (int i = 0; i < IdObjs.Length; i++)
        {
            if(IdObjs[i] != -1){
                
                //Debug.Log(objStats.objs[IdObjs[i]].Name);
                iAD += objStats.objs[IdObjs[i]].AD;
                iADpen += objStats.objs[IdObjs[i]].ADpen;
                iADR += objStats.objs[IdObjs[i]].ADR;
                iAP += objStats.objs[IdObjs[i]].AP;
                iAPpen += objStats.objs[IdObjs[i]].APpen;
                iMR += objStats.objs[IdObjs[i]].MR;
                iAS += objStats.objs[IdObjs[i]].AS;
                iVEL += objStats.objs[IdObjs[i]].VEL;
                iCDR += objStats.objs[IdObjs[i]].CDR;
                iRNG += objStats.objs[IdObjs[i]].RNG;
                ihealth += objStats.objs[IdObjs[i]].health;
                iregenHealth += objStats.objs[IdObjs[i]].regenHealth;
                imana += objStats.objs[IdObjs[i]].mana;
                iregenMana += objStats.objs[IdObjs[i]].regenMana;
                iCrit += objStats.objs[IdObjs[i]].Crit;
                iRV += objStats.objs[IdObjs[i]].RV;
            }
        }
        AD.setStatObj(iAD);
        ADpen.setStatObj(iADpen);
        ADR.setStatObj(iADR);
        AP.setStatObj(iAP);
        APpen.setStatObj(iAPpen);
        MR.setStatObj(iMR);
        AS.setStatObj(iAS);
        VEL.setStatObj(iVEL);
        CDR.setStatObj(iCDR);
        RNG.setStatObj(iRNG);
        health.setStatObj(ihealth);
        regenHealth.setStatObj(iregenHealth);
        mana.setStatObj(imana);
        regenMana.setStatObj(iregenMana);
        RV.setStatObj(iRV);
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        currentHealth = health.getStat();
        currentMana = mana.getStat();

        IdObjs = new int[4] {-1,-1,-1,-1};

        if(this.transform.tag.Contains("Player") || this.transform.tag.Contains("Ally") || this.transform.tag.Contains("Enemy")){
            Objs = GameObject.FindGameObjectsWithTag("Objects")[0];
        }


        if(gameObject.tag.Contains("Enemy")){
            enemies = GameObject.FindGameObjectsWithTag("Ally");
        }
        else{
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }

        if(Portait){
            Portait.GetComponent<Image>().sprite = Minimapicon;
        }
    }
    void Update()
    {
        if (timerMuerte > 0)
        {
            timerMuerte -= Time.deltaTime;
            if (timerMuerte <= 0)
            {
                print("revivir");
                this.GetComponent<MeshRenderer>().enabled = true;
                if (Overlay)
                {
                    Overlay.SetActive(false);
                    this.GetComponent<AtaqueMelee>().enabled = true;
                    this.GetComponent<Transform>().position = initialPos;
                    currentHealth = health.getStat();
                    currentMana = mana.getStat();
                }
            }
            else
            {
                print("Sigo muerto");
                if (Overlay)
                {
                    //int death = timermuerte * 10;
                    //float death2 
                    Overlay.GetComponentsInChildren<UnityEngine.UI.Text>()[2].text = ((int)timerMuerte).ToString();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            currentHealth -= 10;
            print("me dolio wey");
            currentMana -= 5;
            currentExp += 30;
            detectLevelUp();
        }
        if(this.transform.tag.Contains("Player") || this.transform.tag.Contains("Ally") || this.transform.tag.Contains("Enemy"))
            updateStats();
    }
    public void RecibeDmg(float dmg, GameObject other)
    {
        //si es un nexo o torre compruebo si se han muerto las torres anteriores, en otro caso no hago comprobación
        if(((gameObject.tag.Contains("Tower") || gameObject.tag.Contains("Nexus")) && activeTowers() == 0) || (!gameObject.tag.Contains("Tower") && !gameObject.tag.Contains("Nexus"))){

            int dmgMultiplier;
            if (ADR.getStat() >= 0)
            {
                dmgMultiplier = 100 / (100 + ADR.getStat());
}
            else
            {
                dmgMultiplier = 2 - (100 / (100 - ADR.getStat()));
            }
            currentHealth -= (int) (dmg * dmgMultiplier);

            if (currentHealth <= 0 && timerMuerte == 0)
            {
                Morir(other);
            }
        }
    }
    public void ReduceMana(int manaCost)
    {
        currentMana -= manaCost;
    }

    public int activeTowers(){
        int count = 0;
        foreach (GameObject tower in previoustowers)
        {
            if(tower.activeSelf){
                ++count;
            }
        }
        return count;
    }

    public void detectLevelUp(){
        if(currentExp>=exp.getStat()){
            ++level;
            currentExp-=exp.getStat();
        }
    }

    public virtual void Morir(GameObject other)
    {
        if(gameObject.tag.Contains("Minion")){
            gameObject.SetActive(false);
            print("se ha muerto un minion");
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
            if(Overlay){
                
                print(gameObject.name + "ha muerto");
                timerMuerte = 5;
                this.GetComponent<AtaqueMelee>().enabled = false;
                this.gameObject.transform.localPosition = gameObject.transform.position;
                Overlay.SetActive(true);
                timerMuerte = 2.5f;
            }
        }
        //TODO aquí habría que llamar al servidor
        giveReward(other); // Toma galletita
    }

    public void giveReward(GameObject other){
        foreach (GameObject enemy in enemies)
        {
            if(enemy == other){
                enemy.GetComponent<CharacterStats>().money += killreward;
                enemy.GetComponent<CharacterStats>().experience += expreward; //aqui y abajo estaba experience y current exp, creo que es experience
            }
            else if(Vector3.Distance(enemy.transform.position,transform.position) < rewardrange){
                enemy.GetComponent<CharacterStats>().money += killreward / 2;
                enemy.GetComponent<CharacterStats>().experience += expreward;
            }
        }
        
        if(Overlay){
            print(gameObject.name + "ha muerto");
            timerMuerte = 5;
            this.GetComponent<AtaqueMelee>().enabled = false;
            this.gameObject.transform.localPosition = gameObject.transform.position;
            //Overlay.SetActive(true);
            timerMuerte = 2.5f;
        }
        
    }
}