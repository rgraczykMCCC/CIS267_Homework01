using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    public float yOffset;

    [SerializeField]
    private float xMin;
    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMin;
    [SerializeField]
    private float yMax;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y + yOffset, yMin, yMax), transform.position.z);
    }

    ///*Mathf.Max(Mathf.Clamp(target.position.y + yOffset, yMin, yMax)*/ Mathf.Max(target.position.y, transform.position.y)
}