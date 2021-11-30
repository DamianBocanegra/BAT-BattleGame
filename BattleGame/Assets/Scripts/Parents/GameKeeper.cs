using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameKeeper : MonoBehaviour
{

    private Unit playerOne;

    private Unit enemyOne;

    public Unit[] players;
    public Unit[] enemies;
    
    void Awake()
    {
        int existence = FindObjectsOfType<GameKeeper>().Length;
        if(existence > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public Unit getPlayerOne()
    {
        return playerOne;
    }
    

    public void selectHero()
    {
        playerOne = players[0];
    }
    public void selectYevon()
    {
        enemyOne = enemies[0];
    }

    public void moveToEnemySelect()
    {
        if(playerOne != null)
        {
            SceneManager.LoadScene("MainBattle");
        }
    }
}
