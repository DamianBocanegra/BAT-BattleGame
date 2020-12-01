using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{
    //Conditions
    private bool stunned = false;

    public override void basicAbility(Unit enemy)
    {
        enemy.takeDamage(dmgOutput, enemy.blocking);
    }
}