using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called before the first frame update

    public bool hidden = false;
    public int bushes = -1;

    public GameObject Minimapicon;

    void Start()
    {
        origen = transform.position;

    }
    public Vector3 final;
    public float velocidad;
    private Vector3 origen;
    private bool direction = true;
    private Vector3 aux;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position ,final,Time.deltaTime * velocidad);            
        if(direction && transform.position.x > (final.x - 1)){
            direction = !direction;
            aux = final;
            final = origen;
            origen = aux;
        }
        if(!direction && transform.position.x < (final.x + 2)){
            direction = !direction;
            aux = final;
            final = origen;
            origen = aux;
        }
    }
}
