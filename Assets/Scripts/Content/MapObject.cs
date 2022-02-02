using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class MapObject : MonoBehaviour
{
    public float speed = 0;
    public int id;

    private void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.layer == LayerMask.NameToLayer("Character"))
        {
            GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0, "animation", false);
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    private void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector2(-20.0f, -4.5f), speed * Time.deltaTime);
        if (transform.localPosition.x == -20.0f)
            Managers.Object.RemoveObject(id);
    }
}
