using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public float flySpeed;
    public float distance;
    private float heliSpawnLocation;
    private bool maxRight;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        heliSpawnLocation = transform.position.x;
        maxRight = false;

    }

   // Update is called once per frame
    void Update()
    {
        flyHelicopter();
    }

    private void flyHelicopter()
    {
        //Fly the helicopter back and forth


        if (maxRight)
        {
            spriteRenderer.flipX = false;
            transform.Translate(Vector2.left * flySpeed * Time.deltaTime);
        }
        else
        {
            spriteRenderer.flipX = true;
            transform.Translate(Vector2.right * flySpeed * Time.deltaTime);
        }

        if (transform.position.x <= heliSpawnLocation)
        {
            maxRight = false;
        }
        if (transform.position.x >= heliSpawnLocation + distance)
        {
            maxRight = true;
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered trigger for: " + collision.name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered collision for: " + collision.gameObject.name);
    }*/
}
