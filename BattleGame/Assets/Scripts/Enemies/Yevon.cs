using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yevon : Unit
{
    private int baseDamage = 10;
    private int ultimateDamage = 0;

    //Dice rolls
    //9 8 7 6 = charge ultimate
    //5 4 3 = basic
    //3 2 1 = block
    //0 = ultimate 
    public override string makeDesicion()
    {
        int diceRoll = Random.Range(0, 10);

        if(diceRoll >= 6)
        {
            if(ultimateDamage != 0)
            {
                ultimateDamage = ultimateDamage * 2;
            }
            else
            {
                ultimateDamage = baseDamage;
            }
            dmg  = 0;

            return "Yevon is gathering energy!";
        }
        else if(diceRoll >= 3)
        {
            dmg = baseDamage;
            return "Yevon is attacking!";
        }

        else if(diceRoll >= 1)
        {
            blocking = true;
            dmg = 0;
            return "Yevon is moving into a defense position!";
        }
        else
        {
            dmg = ultimateDamage;
            return "A unmesureable energy is being unleashed!!";

        }
        dmg = 0;
        return "ERROR!";
    }
}
