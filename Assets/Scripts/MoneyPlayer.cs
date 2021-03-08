using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPlayer : MonoBehaviour
{
    public GameObject counter;
    void LateUpdate()
    {
        counter.GetComponent<UnityEngine.UI.Text>().text = gameObject.GetComponent<CharacterStats>().money.ToString();
    }
}
