using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gm;
    public GameObject gameOverMenu;





    // Start is called before the first frame update
    void Start()
    {
        gm = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.getGameOver())
        {
            Debug.Log("Update game over");
            showGameOver();
        }
    }

    public void showGameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void restartGame()
    {
        gm.setGameOver(false);
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }
}
