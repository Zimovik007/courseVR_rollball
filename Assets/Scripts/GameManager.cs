using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    protected GameManager() { }

    public int health = 5;
    private static GameManager instance;

    public void decHealth()
    {
        health--;
    }

    public static GameManager Instance
    {
        get
        {
            if (GameManager.instance == null)
            {
                //DontDestroyOnLoad(GameManager.instance);
                GameManager.instance = new GameManager();
            }
            return GameManager.instance;
        }

    }
}
