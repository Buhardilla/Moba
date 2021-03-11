using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    PlayerControls controls;
    public Transform aim;       //movimiento aim
    public GameObject aimer;    //render aim
    Vector2 move;
    Vector2 rotate;

    //COSAS DE HABILIDADES
    private int counthab;
    public GameObject[] habilidades; //cambiar a private si se le pasa desde arriba por el personaje que sera lo suyo si mas arriba en la jerarquia se necesitase llamar al lv up
    private List<GameObject> misHabilidades = new List<GameObject>();
    public Vector3 origen;
    Vector3 rota;
    public float Mspeed = 6.0f;


    // inicializa controles
    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Auto.started += ctx => Auto();
        controls.Gameplay.Ab1.started += ctx => Auto();
        controls.Gameplay.Ab2.started += ctx => Auto();
        controls.Gameplay.Ab3.started += ctx =>Auto();
        controls.Gameplay.fb1x.started += ctx =>  CastAbility(0,rota); //A x,y, xz
        controls.Gameplay.fb2sq.started += ctx => Auto(); //X
        controls.Gameplay.fb3ci.started += ctx => CastAbility(1,rota); //B
        controls.Gameplay.fb4tr.started += ctx => Auto(); // Y
        controls.Gameplay.DPup.started += ctx => Auto();
        controls.Gameplay.DPleft.started += ctx => Auto();
        controls.Gameplay.DPright.started += ctx => Auto();
        controls.Gameplay.DPdown.started += ctx => Auto();
        controls.Gameplay.Start.started += ctx => Auto();

        controls.Gameplay.Moving.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Moving.canceled += ctx => move = Vector2.zero;

        controls.Gameplay.Aiming.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.Gameplay.Aiming.canceled += ctx => rotate = Vector2.zero;
    }

    void Auto()
    {
        Debug.Log("Se realiza un ataque basico.");                                                                  //Función habilidades
    }
    void CastAbility(int i, Vector3 target)
    {
        print(target);
        misHabilidades[i].SetActive(true);
        misHabilidades[i].transform.position = gameObject.transform.position;
        misHabilidades[i].GetComponent<AbilityTest>().cast(gameObject.transform.position, target);
    }

    //para hacer invisible aim
    void Start()
    {
        aimer.GetComponent<Renderer>().enabled = false;
        //aim invisible
        foreach (GameObject habilidad in habilidades)
        {
                
            misHabilidades.Add(Instantiate(habilidad));
            counthab = misHabilidades.ToArray().Length - 1;
            misHabilidades[counthab].GetComponent<AbilityTest>().CreateAbility(3, 3, 3, 3, misHabilidades[counthab]);
            misHabilidades[counthab].SetActive(false);
        }
    }

    void Update()
    {
        if (move != Vector2.zero)
        {
            UpdateRotate();
        }
        Vector3 m = new Vector3(move.x, 0.0f, move.y) * Mspeed * Time.deltaTime;                                    //movimiento personaje
        transform.Translate(m, Space.World);

       if(move != Vector2.zero)
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(move.x, move.y) * 180 / Mathf.PI, 0);              //rotacion personaje
        //transform.Rotate(0, -Mathf.Atan2(rotate.y, rotate.x) * 180 / Mathf.PI, 0);
        //transform.Rotate(r, Space.World);

        // para hacer invisible aim
        if(rotate != Vector2.zero)
        {
            aimer.GetComponent<Renderer>().enabled = true;                                                          //aim visible
            aim.transform.eulerAngles = new Vector3(0, Mathf.Atan2(rotate.x, rotate.y) * 180 / Mathf.PI, 0);      //rotacion aim
            UpdateRotate();

        }
        else
            aimer.GetComponent<Renderer>().enabled = false;                                                         //aim invisible
        
        //aim.transform.eulerAngles = new Vector3(0, -Mathf.Atan2(rotate.y, rotate.x) * 180 / Mathf.PI, 0);
    }
 
    public void UpdateRotate()
    {
        if (rotate.x != 0 && rotate.y != 0)
        {
            rota = new Vector3(rotate.x, this.transform.position.y, rotate.y);
        }
        else
        {
            rota = new Vector3(move.x, 0, move.y);
        }
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

}
