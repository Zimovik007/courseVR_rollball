using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public Button Button;
    public Text gameState;
    public Text gameScore;
    public GameManager gameManager = GameManager.Instance;
    // Start is called before the first frame update
    void Start()
    {
        gameScore.alignment = TextAnchor.MiddleCenter;
        gameState.alignment = TextAnchor.MiddleCenter;
        Button.onClick.AddListener(onClickRestart);
        if (gameManager.isStart)
        {
            gameManager.startGame();
            gameState.text = "Capsule searcher";
            gameScore.text = "";
        }
        else
        {

            if (gameManager.isWin)
            {
                if (gameManager.gotCapsules > 0)
                {
                    gameState.text = "WIN!";
                    gameScore.text = "Собрано капсул: " + gameManager.gotCapsules;
                }
                else
                {
                    gameState.text = "DRAW!";
                    gameScore.text = "Нужно собирать капсулы!";
                }
            }
            else
            {
                gameState.text = "GAME OVER!";
                gameScore.text = "";
            }
        }
    }

    public void onClickRestart()
    {
        gameManager.restartGame();
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
