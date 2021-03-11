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
        print("pañun pañun ");
        direction = (target - castposition).normalized;
        fired = true;
    }

    void Update()
    {
        if (fired)
        {

            print("pañun pañun ");
            transform.position += direction * (speed * Time.deltaTime);
        }
    }

}
