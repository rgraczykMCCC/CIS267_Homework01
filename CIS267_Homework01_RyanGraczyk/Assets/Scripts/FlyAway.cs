using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAway : MonoBehaviour
{
    public float speed;
    private bool sendPlane;
    public float planeLife;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        planeLife = 30;
        Invoke("destroyPlane", planeLife);
    }

    // Update is called once per frame
    void Update()
    {
        if(sendPlane)
        {
            planeTakeoff();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 originalPosition = transform.position;
        
        if (collision.gameObject.tag.Equals("Player"))
        {
            sendPlane = true;
            collision.transform.parent = gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            collision.transform.parent = null;
        }
    }

    private void planeTakeoff()
    {
        transform.Translate(Vector2.up * speed/2  * Time.deltaTime);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void destroyPlane()
    {
        Destroy(this.gameObject);
    }
}
