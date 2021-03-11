using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    Vector3 origen;
    Vector3 direction;
    bool fired;
    public void FireProjectile(Vector3 castposition,Vector3 target,float damage)
    {
        Vector3 ayuda = new Vector3(target.x + castposition.x, target.y + castposition.y, target.z + castposition.z);
        direction = (ayuda - castposition).normalized;
        fired = true;
    }

    void Update()
    {
        if (fired)
        {
            transform.position += direction * (speed * Time.deltaTime);
        }
    }
    void onTriggerEnter(Collider col) {
        print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        print(col.gameObject.tag);
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Ally") {
            
        //aqui col.gameobkect.stats.updateDMG,  si no funciona aqui, llamar al ontrigger en personaje y añadir un tag de habilidad a proyectil
        //se cogeria el daño de col.totaldmg y se aplicaria al updateDMG
        // finalmente llamar a DELETE
        }
    }
}
