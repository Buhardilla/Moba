 using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public bool hidden = false;
    public int bushes = -1;
    //TODO cada personaje tendrá su icono a enseñar en el mapa
    public GameObject Minimapicon;
    public GameObject Overlay;

    Vector3 initialPos = new Vector3(0, 1, 0);
    public int vidaActual { get; private set; }
    public int manaActual { get; private set; }

    public Stat nivel;
    public Stat exp;

    public Stat vida;
    public Stat regenVida;

    public Stat mana;
    public Stat regenMana;

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
    private void Start()
    {
        vidaActual = vida.getStat();
        manaActual = mana.getStat();
    }
    void Update()
    {
        if(timerMuerte > 0)
        {
            timerMuerte -= Time.deltaTime;
            if (timerMuerte <= 0)
            {
                print("revivir");
                this.GetComponent<MeshRenderer>().enabled = true;
                if(Overlay){
                    Overlay.SetActive(false);
                    this.GetComponent<Movimiento>().enabled = true;
                    this.GetComponent<AtaqueMelee>().enabled = true;
                    this.GetComponent<Transform>().position = initialPos;
                    vidaActual = vida.getStat();
                    manaActual = mana.getStat();
                }
            }
            else{
                print("Sigo muerto");
                if(Overlay){
                    Overlay.GetComponentsInChildren<UnityEngine.UI.Text>()[1].text = timerMuerte.ToString();
                }
            }
        }
    }
    public void RecibeDmg(int dmg)
    {
        
        vidaActual -= dmg;
        print(transform.name + " recibe " + dmg + " de daño.");
        print("Vida actual: " + vidaActual);

        if(vidaActual <= 0)
        {
            Morir();
        }
    }

    public virtual void Morir()
    {
        print("muero");
        //this.GetComponent<Movimiento>().moveDirection = new Vector3(0,0,0);
        this.GetComponent<AtaqueMelee>().enabled = false;
        this.GetComponent<Movimiento>().enabled = false;
        this.gameObject.transform.localPosition = gameObject.transform.position;
        Overlay.SetActive(true);
        timerMuerte = 2.5f;
    }
}
