using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SmoothMove : MonoBehaviour
{
    Transform target;
    float smoothTime = 1F;
    private Vector3 velocity = Vector3.zero;
    public bool smallMoveX;
    int c1=0;

    void Start()
    {
        target = gameObject.transform;
    }

    void FixedUpdate()
    {   
        if (smallMoveX)
        {
        if (c1<100)
        {
        Vector3 targetPosition = target.TransformPoint(new Vector3(-1, 0, 0));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        c1++;
        }
        if (c1>=100 && c1<200)
        {
        Vector3 targetPosition = target.TransformPoint(new Vector3(1, 0, 0));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        c1++;
        }
        if (c1==200)
        {
            c1=0;
        }
        }
    }
}