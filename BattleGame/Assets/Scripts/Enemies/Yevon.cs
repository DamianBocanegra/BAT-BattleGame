using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yevon : Unit
{
    private int baseDamage = 10;
    private int charge = 0;
    private bool charged = false;

    //Dice rolls
    //9 8 7 6 = charge ultimate
    //5 4 3 = basic
    //3 2 1 = block
    //0 = ultimate 
    public override string makeDesicion(Unit unit)
    {
        if(unit.currentHP <= baseDamage)
        {
            basicAbility(unit);
            return "Yevon is attacking!"; 
        }

        if(charge == 5)
        {
            specialAbilityTwo(unit);
            return "Yevon has unleashed an unmesurable energy field!";
        }

        if(charged)
        {
            basicAbility(unit);
            charged = false;
            return "Yevon is attacking";
        }
        else
        {
            specialAbilityOne(unit);
            charged = true;
            return "Yevon is gathering energy";
        }


    }


    /*
        Name: Purge Swipe
        Decription: Deal Physical damage to target.
    */
    public override void basicAbility(Unit unit)
    {
        unit.takeDamage(baseDamage, unit.blocking);
    }
 

    /*
        Name: Gather Energy
        Decription: Yevon is given one stack of charge

        Charge: This unit's damage output is increased by 10%
    */
    public override void specialAbilityOne(Unit unit)
    {
        charge += 1;
    }

    /*
        Name: Judgement Blast
        Description: Yevon loses all stacks of charge and deals damage to the target.
        This damage is double for every stack lost.
    */ 
    public override void specialAbilityTwo(Unit unit)
    {
        dmgOutput = baseDamage;
        while(charge != 0)
        {
            dmgOutput = dmgOutput * 2;
            charge -= 1;
        }
        unit.takeDamage(dmgOutput, unit.blocking);
    }

}
