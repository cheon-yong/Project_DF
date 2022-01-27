using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    public float speed = 0;
    public int id;

    private void Start()
    {

    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
        
    }

    private void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector2(-20, -4.5f), speed * Time.deltaTime); 
    }
}
