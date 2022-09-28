using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static bool GameEnd;
    // Update is called once per frame

    private void Start()
    {
        GameEnd = false;
    }
    void Update()
    {
       if (GameEnd)
          return;

       
     if(PlayerStats.Lives<=0)
        {
            EndGame();
           
        }
    }
    void EndGame()
    {
        GameEnd=true;
       
        gameOverUI.SetActive(true);
       

    }
}
