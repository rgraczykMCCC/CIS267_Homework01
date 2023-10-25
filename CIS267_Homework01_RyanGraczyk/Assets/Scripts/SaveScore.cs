using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveScore
{
    public static int[] readHighScores()
    {
        int[] scores = new int[5];

        string path = Application.persistentDataPath + "/playerScore.ps";

        if (File.Exists(path))
        {
            StreamReader sr = new StreamReader(path);

            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = int.Parse(sr.ReadLine());
                //Debug.Log("Score " + i + ": " + scores[i]);
            }

            sr.Close();
        }

        return scores;
    }

    public static void checkHighScores(int currentScore)
    {
        Debug.Log("Checking Scores");
        int[] scores = readHighScores();
        Array.Sort(scores);
        Array.Reverse(scores);
        /*//Debug.Log(scores.Length + "");
        Debug.Log("=======================");
        Debug.Log("Score at 0: " + scores[0]);
        Debug.Log("Score at 1: " + scores[1]);
        Debug.Log("Score at 2: " + scores[2]);
        Debug.Log("Score at 3: " + scores[3]);
        Debug.Log("Score at 4: " + scores[4]);
        Debug.Log("=======================");*/

        /*
        Debug.Log("Score at 4 " + scores[4]);
        Debug.Log("Current Score: " + currentScore);*/
        //scorestring = scores[i];
        //scoreint = int.Parse(scorestring, System.Globalization.NumberStyles.AllowLeadingWhite | System.Globalization.NumberStyles.AllowTrailingWhite);
        if (scores[4] < currentScore)
        {
            scores[4] = currentScore;
        }

        Array.Sort(scores);
        Array.Reverse(scores);
        /*Debug.Log("Score at 0: " + scores[0]);
        Debug.Log("Score at 1: " + scores[1]);
        Debug.Log("Score at 2: " + scores[2]);
        Debug.Log("Score at 3: " + scores[3]);
        Debug.Log("Score at 4: " + scores[4]);*/

        writeFile(scores);

    }

    public static void writeFile(int[] scores)
    {
        string path = Application.persistentDataPath + "/playerScore.ps";

        //read text from the text file


        if (path != null)
        {
            StreamWriter writer = new StreamWriter(path);
            //for (int i = 0; i < 5; i++)
            //{
            //    scores[i] = int.Parse(reader.ReadToEnd());
            //}

            for (int i = 0; i < scores.Length; i++)
            {
                writer.WriteLine(scores[i].ToString());
            }

            writer.Close();

        }
        else
        {
            Debug.Log("Path does not exist");
        }
    }

    public static string showPath()
    {
        return Application.persistentDataPath + "/playerScore.ps";
    }
}
