using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    //private Score score;
    public int lightningValue;

    /*private void Start()
    {

    }*/

    public int getValue()
    {
        return lightningValue;
    }

    public void setValue(int v)
    {
        lightningValue = v;
    }

    public void destroyLightning()
    {
        Destroy(this.gameObject);
    }

    
}
