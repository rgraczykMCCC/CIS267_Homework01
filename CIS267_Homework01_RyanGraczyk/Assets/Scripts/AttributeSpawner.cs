using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttributeSpawner : MonoBehaviour
{
    public GameObject[] attributes;
    public GameObject[] spawnLocations;
    private int[] spawnAttArray;

    public float playerPositionOffset;
    private float playerYPosition;

    public GameObject player;
    private PlayerMovement pl;

    // Start is called before the first frame update
    void Start()
    {
        pl = player.GetComponent<PlayerMovement>();
        playerYPosition = pl.getPlayerYPostion();
        spawnAttributes();
    }

    // Update is called once per frame
    void Update()
    {
        playerPositionChange();
    }

    private void spawnAttributes()
    {
        GameObject spawnedAtt;
        GameObject spawner;
        int spawnIndex;
        int randomIndex;

        getRandomNumberArray();

        for(int i = 0; i < spawnAttArray.Length; i++)
        {
            // associate the random number to the game object spawner
            spawnIndex = spawnAttArray[i];
            spawner = spawnLocations[spawnIndex];
            // get random attribute
            randomIndex = Random.Range(0, attributes.Length);
            // spawn game object
            spawnedAtt = Instantiate(attributes[randomIndex].gameObject);
            // put the game object in the correct location chosen by the random number
            spawnedAtt.transform.position = new Vector2(spawner.transform.position.x, spawner.transform.position.y);
        }




    }

    private void playerPositionChange()
    {
        if(pl.getPlayerYPostion() >= playerYPosition + playerPositionOffset)
        {
            spawnAttributes();
            playerYPosition = pl.getPlayerYPostion();
        }
    }

    private void getRandomNumberArray()
    {
        //first get random number to determine how many locations to fill
        int randomArrayLength;
        randomArrayLength = Random.Range(4, spawnLocations.Length);
        int[] spawnedAttLocations = new int[randomArrayLength];

        //Debug.Log("Random length: " + randomArrayLength);

        //fill array with random numbers
        for (int i = 0; i < randomArrayLength; i++)
        {
            spawnedAttLocations[i] = Random.Range(0, spawnLocations.Length);
        }

        sortArray(spawnedAttLocations);
    }

    private void sortArray(int[] spawnedAttLocations)
    {
        // sort array so the numbers are next to each other to find duplicates
        System.Array.Sort(spawnedAttLocations);

        cleanUpArray(spawnedAttLocations);
    }

    private void cleanUpArray(int[] spawnedAttLocations)
    {
        //initialize array with the same length as passed array
        spawnAttArray = new int[spawnedAttLocations.Length];
        //remove duplicates in spawnedAttLocations array and store to array used in the spawnAttributes() function
        spawnAttArray = spawnedAttLocations.Distinct().ToArray();

    }
}
