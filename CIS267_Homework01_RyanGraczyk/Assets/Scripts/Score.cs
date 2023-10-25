using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Attached to Player


public class Score : MonoBehaviour
{
    private int score;
    public TMP_Text guiScore;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;    
    }

    public void setScore(int s)
    {
        score += s;
        guiScore.text = "Score: " + score.ToString();
    }
    
    public int getScore()
    {
        return score;

    }
}
