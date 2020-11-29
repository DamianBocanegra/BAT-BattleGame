using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Slider health;

    public void setHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        health.maxValue = unit.maxHP;
        health.value = unit.currentHP;
    }

    public void setHP(int hp)
    {
        health.value = hp;
    }
}
