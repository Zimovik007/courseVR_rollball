using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    protected GameManager() { }

    public int health = 5;
    public int gotCapsules = 0;
    public bool isWin = false;
    public bool isStart = true;
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

    public void startGame()
    {
        isStart = false;
    }

    public void nullCapsules()
    {
        gotCapsules = 0;
    }

    public void restartGame()
    {
        health = 5;
        gotCapsules = 0;
        isWin = false;
    }

    public void win()
    {
        isWin = true;
    }

    public void decHealth()
    {
        health--;
    }

    public void incGotCapsules()
    {
        gotCapsules++;
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
