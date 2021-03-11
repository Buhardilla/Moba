using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageBars : MonoBehaviour
{
    CharacterStats chStats;

    public Text moneyCount;
    public Text levelCount;


    public Image healthBar;
    public float maxHealth;
    public float currentHealth;

    public Image manaBar;
    public float manaMax;
    public float currentMana;

    public Image expBar;
    public float expMax;
    public float currentExp;

    private void Start()
    {
        chStats = GetComponent<CharacterStats>();
        maxHealth = chStats.health.getStat();
        manaMax = chStats.mana.getStat();
        expMax = chStats.exp.getStat();
    }
    void LateUpdate()
    {
        //Update money value
        moneyCount.text = chStats.money.ToString();
        //moneyCount.GetComponent<UnityEngine.UI.Text>().text = gameObject.GetComponent<CharacterStats>().money.ToString(); SI EL DE ARRIBA DA ERROR

        //Update health value
        currentHealth = chStats.currentHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.fillAmount = currentHealth / maxHealth;

        //Update mana value
        currentMana = chStats.currentMana;
        currentMana = Mathf.Clamp(currentMana, 0, manaMax);
        manaBar.fillAmount = currentMana / manaMax;
        //borrar desde aqui para abajo si error
        //Update exp value
        currentExp = chStats.currentExp;
        currentExp = Mathf.Clamp(currentExp, 0, expMax);
        expBar.fillAmount = currentExp / expMax;

        //Update level value
        levelCount.text = chStats.level.ToString();
    }
}
