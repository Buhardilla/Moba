using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    CharacterStats chStats;
    public float maxHealth;
    public float currentHealth;

    public Image barraDeVida;

    private void Start()
    {
        chStats = GetComponent<CharacterStats>();
        maxHealth = chStats.health.getStat();
    }
    void LateUpdate()
    {
        chStats = GetComponent<CharacterStats>();
        currentHealth = chStats.currentHealth;

        //para hacer que la vida esté entre esos 2 valores, habra que cambiarlo para cada pj
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        //para la animacion de la barra de vida, habra que ponerlo entre la vida maxima.
        barraDeVida.fillAmount = currentHealth / maxHealth;
    }
}
