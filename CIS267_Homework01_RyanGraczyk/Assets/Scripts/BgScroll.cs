using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BgScroll : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 startPosition;
    private Vector3 playerPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.down * speed * Time.deltaTime);
        /*if(transform.position.y < -14f)
        {
            transform.position = startPosition;
        }*/
    }
}
