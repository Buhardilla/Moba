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

    public float Mspeed = 6.0f;



    // inicializa controles
    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Auto.started += ctx => Auto();
        controls.Gameplay.Ab1.started += ctx => Auto();
        controls.Gameplay.Ab2.started += ctx => Auto();
        controls.Gameplay.Ab3.started += ctx => Auto();
        controls.Gameplay.fb1x.started += ctx => Auto();
        controls.Gameplay.fb2sq.started += ctx => Auto();
        controls.Gameplay.fb3ci.started += ctx => Auto();
        controls.Gameplay.fb4tr.started += ctx => Auto();
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

    //para hacer invisible aim
    void Start()
    {
        aimer.GetComponent<Renderer>().enabled = false;                                                             //aim invisible
    }

    void Update()
    {
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
            aim.transform.eulerAngles = new Vector3(0, Mathf.Atan2(rotate.x, rotate.y) * 180 / Mathf.PI, 0);       //rotacion aim
        }else
            aimer.GetComponent<Renderer>().enabled = false;                                                         //aim invisible
        
        //aim.transform.eulerAngles = new Vector3(0, -Mathf.Atan2(rotate.y, rotate.x) * 180 / Mathf.PI, 0);
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
