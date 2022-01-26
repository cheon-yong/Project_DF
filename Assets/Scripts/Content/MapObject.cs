using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    public float speed = 0;
    //private Rigidbody2D rigidBody;

    private void Start()
    {
        //rigidBody = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
        //GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        
    }

    private void OnBecameInvisible()
    {
        Destroy(this);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector2(-20, -4.5f), speed * Time.deltaTime); 
    }
}
