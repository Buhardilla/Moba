using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    CharacterStats chStats;
    public float vidaMax;
    public float vidaActual;

    public Image barraDeVida;

    private void Start()
    {
        chStats = GetComponent<CharacterStats>();
        vidaMax = chStats.vida.getStat();
    }
    void LateUpdate()
    {
        setHealth(GetComponent<CharacterStats>().vidaActual);
    }
    
    public void setHealth(float health){
        vidaActual = health;

        //para hacer que la vida esté entre esos 2 valores, habra que cambiarlo para cada pj
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);
        
        //para la animacion de la barra de vida, habra que ponerlo entre la vida maxima.
        barraDeVida.fillAmount = vidaActual / vidaMax;
    }
}
