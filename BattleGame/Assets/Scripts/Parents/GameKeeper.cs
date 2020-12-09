using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    

    public void selectHero()
    {
        playerOne = players[0];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
