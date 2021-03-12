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

    public GameObject store;
    private Store storeStore;
    private float timer;


    // inicializa controles
    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Auto.started += ctx => Auto();
        controls.Gameplay.Ab1.started += ctx => Auto();
        controls.Gameplay.Ab2.started += ctx => Auto();
        controls.Gameplay.Ab3.started += ctx => Auto();
        controls.Gameplay.fb2sq.started += ctx => ToggleStore();
        controls.Gameplay.fb4tr.started += ctx => Auto();
        if(store.GetComponent<Canvas>().enabled){
            controls.Gameplay.fb3ci.started += ctx => sell(); 
            controls.Gameplay.fb1x.started += ctx => buy();

            controls.Gameplay.DPup.started += ctx => storeUp();
            controls.Gameplay.DPleft.started += ctx => storeLeft();
            controls.Gameplay.DPright.started += ctx => storeRight();
            controls.Gameplay.DPdown.started += ctx => storeDown();
        }
        else{
            controls.Gameplay.fb3ci.started += ctx => Auto(); 
            controls.Gameplay.fb1x.started += ctx => Auto();

            controls.Gameplay.DPup.started += ctx => Auto();
            controls.Gameplay.DPleft.started += ctx => Auto();
            controls.Gameplay.DPright.started += ctx => Auto();
            controls.Gameplay.DPdown.started += ctx => Auto();
        }

        controls.Gameplay.Start.started += ctx => Auto();

        controls.Gameplay.Moving.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Moving.canceled += ctx => move = Vector2.zero;

        controls.Gameplay.Aiming.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.Gameplay.Aiming.canceled += ctx => rotate = Vector2.zero;

        storeStore = store.GetComponent<Store>();
    }

    void Auto()
    {
        Debug.Log("Se realiza un ataque basico.");                                                                  //Función habilidades
    }

    void storeUp(){
        storeStore.moveSelection(Store.move.up);
    }
    void storeRight(){
       storeStore.moveSelection(Store.move.right);
    }
    void storeLeft(){
       storeStore.moveSelection(Store.move.left);
    }
    void storeDown(){
        storeStore.moveSelection(Store.move.down);
    }

    void buy(){
        storeStore.buy();
    }

    void sell(){
        storeStore.sell();
    }

    void ToggleStore(){
        store.GetComponent<Canvas>().enabled = !store.GetComponent<Canvas>().enabled;
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
        if(!store.GetComponent<Canvas>().enabled){
            if(rotate != Vector2.zero)
            {
                aimer.GetComponent<Renderer>().enabled = true;                                                          //aim visible
                aim.transform.eulerAngles = new Vector3(0, Mathf.Atan2(rotate.x, rotate.y) * 180 / Mathf.PI, 0);       //rotacion aim
            }else
                aimer.GetComponent<Renderer>().enabled = false;                                                         //aim invisible
        }
        else{
            timer -= Time.deltaTime;
            if(rotate.x < -0.8 && timer <= 0){
                timer = 0.5f;
                storeStore.moveInv(Store.move.left);
            }
            else if(rotate.x > 0.8 && timer <= 0){
                timer = 0.5f;
                storeStore.moveInv(Store.move.right);
            }
        }
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
