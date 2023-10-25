using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject missile;
    public GameObject missileSpawner;
    private bool checkMissileSpawn;

    // Start is called before the first frame update
    void Start()
    {
        checkMissileSpawn = false;
        StartCoroutine(makeHelicopter());
    }

    // Update is called once per frame
    void Update()
    {
        if (checkMissileSpawn)
        {
            checkMissileSpawn = false;
            StartCoroutine(makeHelicopter());
        }
    }

    IEnumerator makeHelicopter()
    {
        //wait for 5 seconds
        yield return new WaitForSeconds(7);
        Debug.Log("Waited for 2 seconds");

        if (Random.Range(1, 10) % 2 == 0)
        {
            Instantiate(missile.gameObject);
            missile.transform.position = new Vector2(missileSpawner.transform.position.x, missileSpawner.transform.position.y);
        }
        checkMissileSpawn = true;
    }
}
