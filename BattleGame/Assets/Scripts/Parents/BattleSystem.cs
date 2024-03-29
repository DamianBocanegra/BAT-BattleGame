﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum battleStates {START, PLAYERTURN, ENEMYTURN, WIN, LOSS}

public class BattleSystem : MonoBehaviour
{
    
    //UI
    public Text dialouge;
    public Text btnOne;
    public Text btnTwo;
    public Text btnThree;

    public battleStates state;

    public GameObject player;
    public GameObject enemy;

    public Transform playerStation;
    public Transform enemyStation;

    private Unit playerUnit;
    private Unit enemyUnit;

    private GameKeeper keeper;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    
    // Start is called before the first frame update
    void Start()
    {
        state = battleStates.START;
        
        //FIND HOW TO GET ACTIVE GAME MANGER!
        keeper = GameObject.Find("GameManager");
        StartCoroutine(SetupBattle());
    }

    private void playerTurn()
    {
        dialouge.text = "Attack now " + playerUnit.unitName + "!";
    }

    IEnumerator SetupBattle()
    {
        //Spawn Player and Enemy
        GameObject playerGO = Instantiate(keeper.getPlayerOne(), playerStation);
        playerUnit = playerGO.GetComponent<Unit>();
        
        GameObject enemyGO = Instantiate(enemy, enemyStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialouge.text = enemyUnit.unitName + " has appeared!"; 


        //Set Player Ablities
        btnOne.text = playerUnit.basicAbilityName;
        btnTwo.text = playerUnit.specialAbilityOneName;
        btnThree.text = playerUnit.specialAbilityTwoName;

        playerHUD.setHUD(playerUnit);
        enemyHUD.setHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = battleStates.PLAYERTURN;
        playerTurn();
    }

    
    //Player Coroutines
    
    IEnumerator PlayerAttack()
    {
        playerUnit.basicAbility(enemyUnit);
        bool isAlive = enemyUnit.isAlive();
        enemyHUD.setHP(enemyUnit.currentHP);

        if(enemyUnit.blocking)
        {
            dialouge.text = enemyUnit.unitName + " has blocked the attack!";
            enemyUnit.endBlock();
        }
        else
        {
            dialouge.text = playerUnit.unitName + " has attacked!";
        }
        yield return new WaitForSeconds(2f);

        if(!isAlive)
        {
            state = battleStates.WIN;
            EndBattle();
        }
        else
        {
            state = battleStates.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
   
    }

    IEnumerator PlayerHeal()
    {
        
        playerUnit.specialAbilityOne(enemyUnit);
        playerHUD.setHP(playerUnit.currentHP);
        dialouge.text = playerUnit.unitName + " is recovering!";
        yield return new WaitForSeconds(2f);

        state = battleStates.ENEMYTURN;
        StartCoroutine(EnemyTurn());

    }

    IEnumerator PlayerBlock()
    {
        playerUnit.specialAbilityTwo(enemyUnit);
        dialouge.text = playerUnit.unitName + " moving to defensive position!";
        yield return new WaitForSeconds(2f);

        state = battleStates.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    //End Player Coroutines


    IEnumerator EnemyTurn()
    {
        dialouge.text = enemyUnit.makeDesicion(playerUnit);
        if(playerUnit.blocking)
        {
            dialouge.text = playerUnit.unitName + " has blocked!";
            playerUnit.endBlock();
        }

        bool isAlive = playerUnit.isAlive();
       
        playerHUD.setHP(playerUnit.currentHP);

        yield return new WaitForSeconds(2f);

        if(!isAlive)
        {
            state = battleStates.LOSS;
            EndBattle();
        }
        else
        {
            state = battleStates.PLAYERTURN;
            playerTurn();
        }

        
    }

    //Player button functions
    public void onAttackButton()
    {
        if(state != battleStates.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack());
    }

    public void onHealButton()
    {
        if(state != battleStates.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerHeal());
    }

    public void onBlockButton()
    {
        if(state != battleStates.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerBlock());
    }

    private void EndBattle()
    {
        if(state == battleStates.WIN)
        {
            dialouge.text = "Good work " + playerUnit.unitName + "!";
        }
        else if(state == battleStates.LOSS)
        {
            dialouge.text = "No! we have lost " + playerUnit.unitName + "!";
        }
    }
}
