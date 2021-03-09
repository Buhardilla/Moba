using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBushes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] bushes = GameObject.FindGameObjectsWithTag("Bush");
        for (int i = 0; i < bushes.Length; i++)
        {
            bushes[i].GetComponent<hideCharacter>().bushID = i;
        }
    }
}
