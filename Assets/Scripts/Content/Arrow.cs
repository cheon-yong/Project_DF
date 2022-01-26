using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector3 LocalPosition
    {
        get; set;
    }
    public void SetAngle(float angle, float distance)
    {
        float rad = angle * Mathf.Deg2Rad;
        transform.localPosition = new Vector2(distance * Mathf.Cos(rad), distance * Mathf.Sin(rad));
        LocalPosition = transform.localPosition;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
