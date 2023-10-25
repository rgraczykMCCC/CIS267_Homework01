using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject[] airplanes;
    public GameObject[] spawnLocations;
    private int[] spawnPlanesArray;
    //private int[] spawnedPlaneLocations;
    public float playerPositionOffset;
    private float playerYPosition;
    //private Vector2 playerPositionMoved;

    public GameObject player;
    private PlayerMovement pl;

    // Start is called before the first frame update
    void Start()
    {
        pl = player.GetComponent<PlayerMovement>();
        playerYPosition = pl.getPlayerYPostion();
        // Spawn first row of planes above what is visible
        spawnPlanes();
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously check if the player is moving up so more planes spawn
        playerPositionChange();
    }

    private void playerPositionChange()
    {
        // If player is moving up, spawn planes. Then check again.
        if (pl.getPlayerYPostion() >= playerYPosition + playerPositionOffset)
        {
            pl.playerPositionScore();
            spawnPlanes();
            playerYPosition = pl.getPlayerYPostion();
        }
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


        //      TESTING     Print in console
        /*Debug.Log("Array Length: " +  spawnedPlaneLocations.Length);
        for(int i = 0; i < spawnedPlaneLocations.Length; i++)
        {
            Debug.Log("Array: " + spawnedPlaneLocations[i]);
        }*/

        //Sort array
        sortArray(spawnedPlaneLocations);
    }

    private void sortArray(int[] spawnedPlaneLocations)
    {
        //int tempNumber;

        System.Array.Sort(spawnedPlaneLocations);

        cleanUpArray(spawnedPlaneLocations);
        //  TESTING     Print in console
        /*for(int i = 0; i < spawnedPlaneLocations.Length; i++)
        {
            Debug.Log("Sorted Array: " + spawnedPlaneLocations[i].ToString());
        }*/
    }

    private void cleanUpArray(int[] spawnedPlaneLocations)
    {
        //initialize array with the same length as passed array
        spawnPlanesArray = new int[spawnedPlaneLocations.Length];
        //remove duplicates in spawnedPlaneLocations array and store to array used in the spawnPlanes() function
        spawnPlanesArray = spawnedPlaneLocations.Distinct().ToArray();

        //  TESTING     Print in console
        /*for(int i = 0; i < tempArray.Length; i++)
        {
            Debug.Log("Distinct Array: " + tempArray[i].ToString());
        }*/
    }
}