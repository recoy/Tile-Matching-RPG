using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public int attack;
    public int heal;
    public int special;
    public Text currentHealthText, attackText, HealText;

    private void Start()
    {
        currentHealth = maxHealth;
        RefreshAttributeTexts();
    }

    public void RefreshAttributeTexts()
    {
        currentHealthText.text = currentHealth.ToString();
        attackText.text = attack.ToString();
        HealText.text = heal.ToString();
    }
}
