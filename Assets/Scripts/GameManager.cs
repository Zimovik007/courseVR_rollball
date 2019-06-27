using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    protected GameManager() { }

    public int health = 5;
    private static GameManager instance;

    public int[] movementOffsets = new int[] { 0, 1, 1, 1, 1, -1, 0, 1, 0, -1, 1, -1, 1, 1, 0, -1 };
    public int index = 0;

    public void changeIndex(int i)
    {
        if (index == 0 && i == -1)
        {
            index = 3;
        }
        else
        {
            index = (index + i) % 4;
        }
    }

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
