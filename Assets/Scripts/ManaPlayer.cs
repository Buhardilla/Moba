using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaPlayer : MonoBehaviour
{
    CharacterStats chStats;
    public float manaMax;
    public float manaActual;

    public Image barraDeMana;

    private void Start()
    {
        chStats = GetComponent<CharacterStats>();
        manaMax = chStats.mana.getStat();
    }
    void LateUpdate()
    {
        chStats = GetComponent<CharacterStats>();
        manaActual = chStats.currentMana;

        //para hacer que la vida esté entre esos 2 valores, habra que cambiarlo para cada pj
        manaActual = Mathf.Clamp(manaActual, 0, manaMax);
        
        //para la animacion de la barra de vida, habra que ponerlo entre la vida maxima.
        barraDeMana.fillAmount = manaActual / manaMax;
    }
}
