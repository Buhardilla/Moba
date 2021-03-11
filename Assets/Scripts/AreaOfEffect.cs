using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffect : MonoBehaviour
{
    float range;
    public float delay;
    // Start is called before the first frame update
    public void castAoe(Vector3 castposition,Vector3 targetposition)
    {
        StartCoroutine(lanzarAoe(targetposition));
    }

    // Update is called once per frame
    public IEnumerator lanzarAoe(Vector3 target)
    {
        yield return new WaitForSeconds(delay);
        gameObject.transform.position = target;
    }
    void extraeffect() { }
}
