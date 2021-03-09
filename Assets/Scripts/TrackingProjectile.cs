using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingProjectile : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject mytarget;
    public GameObject mylauncher;

    
    public void FireProjectile(GameObject lanzador, GameObject target, int danyo) { //se puede abstraer para herencia este constructor
        //para el linea recta se añadiria direccion y disparo y esta clase de trackingprojectile pasa a heredar de proyectil Base

            mytarget = target;

        if (lanzador)
        {
            mylauncher = lanzador;
            transform.position = mylauncher.transform.position;
        }



    }
    
    void Update()
    {
        if (mytarget) {
            transform.position = Vector3.MoveTowards(transform.position, mytarget.transform.position, speed * Time.deltaTime);
            float closestDist = (transform.position - mytarget.transform.position).magnitude;
            if (closestDist < 0.3) {
                Destroy(gameObject);
            }
        }
    }




   public void setTarget(GameObject target)
    {
        mytarget = target;
    }
}
