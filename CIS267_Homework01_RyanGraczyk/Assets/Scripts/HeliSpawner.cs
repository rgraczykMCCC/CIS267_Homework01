using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliSpawner : MonoBehaviour
{
    public GameObject helicopter;
    public GameObject heliSpawner;
    //private Vector2 heliSpawnLocation;
    private bool checkWeather;

    // Start is called before the first frame update
    void Start()
    {
        checkWeather = false;
        //heliSpawnLocation = heliSpawner.transform.position;
        StartCoroutine(makeHelicopter());
    }

    // Update is called once per frame
    void Update()
    {
        if (checkWeather)
        {
            checkWeather = false;
            StartCoroutine(makeHelicopter());
        }
    }

    IEnumerator makeHelicopter()
    {
        //wait for 5 seconds
        yield return new WaitForSeconds(10);
        Debug.Log("Waited for 2 seconds");

        if (Random.Range(1, 10) % 2 == 0)
        {
            Instantiate(helicopter.gameObject);
            helicopter.transform.position = new Vector2(heliSpawner.transform.position.x, heliSpawner.transform.position.y);
        }
        checkWeather = true;
    }
}
