using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    //private Score score;
    public int rocketValue;

    // Start is called before the first frame update
    /*void Start()
    {
        rocketValue = 10;
    }*/

    public int getValue()
    {
        return rocketValue;
    }

    public void setValue(int v)
    {
        rocketValue = v;
    }

    public void destroyRocket()
    {
        Destroy(this.gameObject);
    }
}
