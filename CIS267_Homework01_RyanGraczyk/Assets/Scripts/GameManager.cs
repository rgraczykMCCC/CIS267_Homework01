using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameOver;

    public GameObject player;
    private PlayerMovement pm;
    private int score;
    private bool finalScoreRan;
    private bool addTime;

    // Start is called before the first frame update
    void Start()
    {
        pm = player.GetComponent<PlayerMovement>();
        setGameOver(false);
        finalScoreRan = false;
        //displayScoreArray();
    }

    private void Update()
    {
        gameState();
    }

    private void FixedUpdate()
    {
        //timePassed += Time.deltaTime * 1000.0f;
        //progress = (timePassed / time);
    }

    public bool getGameOver()
    {
        return gameOver;
    }

    public void setGameOver(bool go)
    {
        gameOver = go;
    }

    public void gameState()
    {
        if(gameOver)
        {
            Time.timeScale = 0f;
            Debug.Log("Player Dead");
            if(!finalScoreRan)
            {
                finalScoreRan = true;
                finalScore();
            }

        }
        else
        {
            Time.timeScale = 1f;
        }

        if(pm.getAddToClock())
        {
            addTime = true;
            pm.setAddToClock(false);
        }
    }


    public void finalScore()
    {
        score = pm.getFinalScore();
        Debug.Log("Final score: " + score);
        SaveScore.checkHighScores(score);
    }

    public bool getAddTimeToClock()
    {
        return addTime;
    }

    public void setAddTimeToClock(bool t)
    {
        addTime = t;
    }

    public void displayScoreArray()
    {
        int[] scores = SaveScore.readHighScores();

        Debug.Log("Path: " + SaveScore.showPath());

        for(int i = 0; i < scores.Length; i++)
        {
            Debug.Log("Score at " + i + ": " + scores[i]);
        }
    }
    

}
