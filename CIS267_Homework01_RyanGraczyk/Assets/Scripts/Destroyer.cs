using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gm;

    void Start()
    {
        gm = gameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gm.setGameOver(true);
        }
        else
        {
            Destroy(collision.gameObject);
        }
        
    }


}
