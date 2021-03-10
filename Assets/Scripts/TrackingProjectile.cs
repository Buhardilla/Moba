using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingProjectile : MonoBehaviour
{
    public float speed;
    private float damage;
    public GameObject mytarget;
    public GameObject mylauncher;

    
    public void FireProjectile(GameObject lanzador, GameObject target, float damage) { //se puede abstraer para herencia este constructor
        //para el linea recta se añadiria direccion y disparo y esta clase de trackingprojectile pasa a heredar de proyectil Base
        mytarget = target;
        this.damage = damage;
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
                mytarget.GetComponent<CharacterStats>().RecibeDmg(damage, null);
                Destroy(gameObject);
            }
        }
    }




   public void setTarget(GameObject target)
    {
        mytarget = target;
    }
}
