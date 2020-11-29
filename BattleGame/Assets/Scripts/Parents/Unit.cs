using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int level;
    public int dmg;
    public int maxHP;
    public int currentHP;
    public bool blocking = false;

    public bool takeDamage(int damage, bool blocking)
    {
        //Damage calc return if blocking
        if(blocking)
        {
            return false;
        }
        else
        {
            currentHP -= damage;   
        }
        
        //Determine dead
        if(currentHP <= 0)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    public void Heal()
    {
        currentHP += dmg + 10;
        if(currentHP >= maxHP)
        {
            currentHP = maxHP;
        }
    }

    public void Block()
    {
        blocking = true;
    }

    public void endBlock()
    {
        blocking = false;
    }

    public virtual string makeDesicion()
    {
        return "Override me!";
    }
}
