using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuiTimer : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gm;
    private float time;
    private TMP_Text guiTime;


    // Start is called before the first frame update
    void Start()
    {
        gm = gameManager.GetComponent<GameManager>();
        time = 30;
        guiTime = GetComponent<TMP_Text>();
        updateTime();
    }

    // Update is called once per frame
    void Update()
    {
        timeTick();
        if(gm.getAddTimeToClock())
        {
            time += 10;
            timeTick();
        }

        gm.setAddTimeToClock(false);
    }

    public void timeTick()
    {
        time -= Time.deltaTime;
        updateTime();

        if(time < 0)
        {
            gm.setGameOver(true);
            time = 0;
            updateTime();
        }
    }

    private void updateTime()
    {
        double t = System.Math.Round(time, 1);
        guiTime.text = "Time: " + t;

    }
}
