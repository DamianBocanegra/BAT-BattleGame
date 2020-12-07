using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{
    //Conditions
    private bool stunned = false;

    void Awake()
    {
        basicAbilityName = "Brave Strike";
        specialAbilityOneName = "Hero's Retreat";
        specialAbilityTwoName = "Play Defense!";
    }
    

    //Hero's basic:
    /*
        Ability Name: Brave Strike
        Description: Deal damage to target enemy.
    */
    public override void basicAbility(Unit enemy)
    {
        enemy.takeDamage(dmgOutput, enemy.blocking);
    }

    /*
        Ability Name: Hero's retreat
        Description: Hero recovers health equal to 10% of 
        his max health. 
    */
    public override void specialAbilityOne(Unit enemy)
    {
        currentHP += maxHP / 10;
        if(maxHP <= currentHP)
        {
            currentHP = maxHP;
        }
    }

    /*
        Ability Name: Play to Defense
        Description: Hero gains Block.

        Block: The next time damage is inflicted it is reduced to 0
        then Block expires.

    */
    public override void specialAbilityTwo(Unit enemy)
    {
        blocking = true;
    }
    
}