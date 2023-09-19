using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowX : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        Vector2 desiredPosition = target.position;
        Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, 1f);
    }
}
