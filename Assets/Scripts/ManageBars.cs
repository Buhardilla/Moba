using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageBars : MonoBehaviour
{
    CharacterStats chStats;

    public GameObject moneyCount;


    public Image healthBar;
    public float maxHealth;
    public float currentHealth;

    public Image manaBar;
    public float manaMax;
    public float currentMana;

    public Image expBar;
    public int expMax;
    public int ActualExp;

    private void Start()
    {
        chStats = GetComponent<CharacterStats>();
        maxHealth = chStats.health.getStat();
        manaMax = chStats.mana.getStat();
        expMax = chStats.expMax;
    }
    void LateUpdate()
    {
        //Update money value
        moneyCount.GetComponent<UnityEngine.UI.Text>().text = gameObject.GetComponent<CharacterStats>().money.ToString();

        //Update health value
        currentHealth = chStats.currentHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.fillAmount = currentHealth / maxHealth;

        //Update mana value
        currentMana = chStats.currentMana;
        currentMana = Mathf.Clamp(currentMana, 0, manaMax);
        manaBar.fillAmount = currentMana / manaMax;
    }
}
