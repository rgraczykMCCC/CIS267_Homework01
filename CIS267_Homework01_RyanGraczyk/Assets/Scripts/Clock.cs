using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public int clockValue;

    public void setValue(int v)
    {
        clockValue = v;
    }

    public int getValue()
    {
        return clockValue;
    }

    public void destroyClock()
    {
        Destroy(this.gameObject);
    }
}
