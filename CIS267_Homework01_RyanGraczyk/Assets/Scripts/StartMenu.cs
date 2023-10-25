using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private int[] scores;
    public GameObject highScoreMenu;
    public GameObject startMenu;

    public TMP_Text highScore1;
    public TMP_Text highScore2;
    public TMP_Text highScore3;
    public TMP_Text highScore4;
    public TMP_Text highScore5;



    // Start is called before the first frame update
    void Start()
    {
        //readHighScores();
        //checkHighScores();
        //displayHighScores();
    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void backToMenu()
    {
        highScoreMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    

    public void showHighScoreMenu()
    {
        startMenu.SetActive(false);
        highScoreMenu.SetActive(true);

        scores = SaveScore.readHighScores();
        displayHighScores();

    }

    public void displayHighScores()
    {
        highScore1.text = scores[0].ToString();
        highScore2.text = scores[1].ToString();
        highScore3.text = scores[2].ToString();
        highScore4.text = scores[3].ToString();
        highScore5.text = scores[4].ToString();
    }

    
}
