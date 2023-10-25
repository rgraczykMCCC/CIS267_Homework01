using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject missile;
    public GameObject player;
    public float speed;
    private Vector3 lastPosition;
    public GameObject gameManager;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = player.transform.position;
        gm = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        moveMissile();
    }

    private void moveMissile()
    {
        //sends missile to player
        missile.transform.position = Vector2.MoveTowards(transform.position, lastPosition, speed * Time.deltaTime);

        //keeps missile pointed in correct direction
        missile.transform.up = player.transform.position - transform.position; 

        //if the missile reaches the player's last position and the player is not there then delete it
        if(transform.position == lastPosition)
        {
            Destroy(missile.gameObject);
        }

        //if the missile doesn't reach the player in this amount of time (doesn't need to be exact) then delete it
        //Destroy(missile.gameObject, 5.0f);
    }
}
