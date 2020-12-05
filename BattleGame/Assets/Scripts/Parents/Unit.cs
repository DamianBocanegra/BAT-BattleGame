using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //StatsChart
    public string unitName;
    public int level;
    public int dmgOutput;
    public int maxHP;
    public int currentHP;
    
    //Basic Conditions
    public bool blocking = false;
    private bool alive = true;

    public string UNITID;

    public void takeDamage(int damage, bool blocking)
    {
        //Damage calc return if blocking
        if(!blocking)
        {
            currentHP -= damage;
        }
        
        //Determine dead
        if(currentHP <= 0)
        {
            alive = false;
        }
    }

    public void Heal()
    {
        currentHP += dmgOutput + 10;
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

    public bool isAlive()
    {
        return alive;
    }

    public virtual string makeDesicion(Unit u)
    {
        return "Override me!";
    }

    public virtual void basicAbility(Unit u)
    {
        Debug.Log("I was not overriden");
        return;
    }

    public virtual void specialAbilityOne(Unit u)
    {
        Debug.Log("I was not overriden");
        return;
    }
    public virtual void specialAbilityTwo(Unit u)
    {
        Debug.Log("I was not overriden");
        return;
    }

    public virtual void checkConditions()
    {
        Debug.Log("I was not overriden");
        return;
    }
}
