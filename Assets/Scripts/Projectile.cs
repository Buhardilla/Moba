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

}
