using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideCharacter : MonoBehaviour
{
    public int bushID;
    public int hiddenAllies = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Contains("Ally") || other.tag.Contains("Enemy"))
        {
            other.GetComponent<CharacterStats>().hidden = true;
            other.GetComponent<CharacterStats>().bushes = bushID;
        }
        
        
    }


    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        if (other.tag.Contains("Ally") || other.tag.Contains("Enemy"))
        {
            other.GetComponent<CharacterStats>().hidden = false;
            other.GetComponent<CharacterStats>().bushes = -1;
        }
    }
}
