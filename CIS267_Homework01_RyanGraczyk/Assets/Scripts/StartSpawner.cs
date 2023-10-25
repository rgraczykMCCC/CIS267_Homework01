using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StartSpawner : MonoBehaviour
{
    public GameObject[] airplanes;
    public GameObject[] spawnLocations;
    private int[] spawnPlanesArray;
    //private bool firstSpawn;


    // Start is called before the first frame update
    void Start()
    {
        // Spawn first row of planes above what is visible
        spawnPlanes();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnPlanes()
    {
        GameObject spawnedPlane;
        GameObject spawner;
        int spawnIndex;
        int randomIndex;

        // Get random numbers for spawner - randomizes how many and which spawners activate and removes duplicates. Every game is different.
        getRandomNumberArray();

        for (int i = 0; i < spawnPlanesArray.Length; i++)
        {
            // Need a way to associate the random number to the Game Object spawner
            spawnIndex = spawnPlanesArray[i];
            spawner = spawnLocations[spawnIndex];
            // Get random number for which type of object to spawn
            randomIndex = Random.Range(0, airplanes.Length);
            // Spawn the Game Object
            spawnedPlane = Instantiate(airplanes[randomIndex].gameObject);
            // Put the Game Object in the correct location chosen by the random number array
            spawnedPlane.transform.position = new Vector2(spawner.transform.position.x, spawner.transform.position.y);
        }

    }

    private void getRandomNumberArray()
    {
        //first get random number to determine how many locations to fill
        int randomArrayLength;
        randomArrayLength = Random.Range(4, spawnLocations.Length);
        int[] spawnedPlaneLocations = new int[randomArrayLength];

        //Debug.Log("Random length: " + randomArrayLength);

        //fill array with random numbers
        for (int i = 0; i < randomArrayLength; i++)
        {
            spawnedPlaneLocations[i] = Random.Range(0, spawnLocations.Length);
        }

        //Sort array
        sortArray(spawnedPlaneLocations);
    }

    private void sortArray(int[] spawnedPlaneLocations)
    {
        System.Array.Sort(spawnedPlaneLocations);

        cleanUpArray(spawnedPlaneLocations);
    }

    private void cleanUpArray(int[] spawnedPlaneLocations)
    {
        //initialize array with the same length as passed array
        spawnPlanesArray = new int[spawnedPlaneLocations.Length];
        //remove duplicates in spawnedPlaneLocations array and store to array used in the spawnPlanes() function
        spawnPlanesArray = spawnedPlaneLocations.Distinct().ToArray();
    }

}
