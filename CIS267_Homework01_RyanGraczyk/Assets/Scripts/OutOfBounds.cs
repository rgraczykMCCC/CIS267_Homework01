using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    //public GameObject player;
    //private PlayerMovement pl;
    public GameObject gameManager;
    private GameManager gm;
    //public float outOfBoundsOffset;
    //private bool playerMovingUp;
    //private float startPos;

    // Start is called before the first frame update
    void Start()
    {
        //pl = player.GetComponent<PlayerMovement>();
        gm = gameManager.GetComponent<GameManager>();
        //playerMovingUp = true;
        //startPos = pl.getPlayerYPostion();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Player startPos: " + startPos);
        //playerFellOff();
        //moveOutOfBounds();
    }

    /*private void playerFellOff()
    {
        if (pl.getPlayerYPostion() < startPos)
        {
            //playerMovingUp = false;
            Debug.Log("Player fell");
        }
    }

    private void moveOutOfBounds()
    {
        if (pl.getPlayerYPostion() >= startPos)
        {
            transform.position = new Vector2(0, pl.getPlayerYPostion() - outOfBoundsOffset);

            //startPos = pl.getPlayerYPostion() - outOfBoundsOffset;
            Debug.Log("Player moving up");
            //transform.position.Set(0, startPos - outOfBoundsOffset, 0);
        }
        //else if (!playerMovingUp || startPos > pl.getPlayerYPostion())
        //{
       //     Debug.Log("Player Dead by falling");
        //}

        startPos = pl.getPlayerYPostion() - outOfBoundsOffset;
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            gm.setGameOver(true);
        }
    }
}
