using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float deg;
    public float speed = 3.0f;
    public float energy = 5.0f;
    public GameObject arrow;
    public float distance;

    private Rigidbody2D rigidBody;
    private Vector3 initPosition;
    private Quaternion initRotation;
    private Vector3 initAngle;

    GameScene scene;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        initPosition = transform.position;
        initRotation = transform.rotation;
        initAngle = transform.eulerAngles;

        scene = Managers.Scene.CurrentScene as GameScene;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity = Vector2.zero;
            transform.position = initPosition;
            transform.rotation = initRotation;
            transform.eulerAngles = initAngle;
            rigidBody.angularVelocity = 0;

            deg = 0;
            float rad = deg * Mathf.Deg2Rad;
            arrow.transform.localPosition = new Vector2(distance * Mathf.Cos(rad), distance * Mathf.Sin(rad));
            arrow.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetMouseButton(0))
        {
            deg = deg + Time.deltaTime * speed;
            float rad = deg * Mathf.Deg2Rad;
            arrow.transform.localPosition = new Vector2(distance * Mathf.Cos(rad), distance * Mathf.Sin(rad));
            arrow.transform.eulerAngles = new Vector3(0, 0, deg);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 dir = arrow.transform.position - transform.position;

            deg = 0;
            float rad = deg * Mathf.Deg2Rad;
            arrow.transform.localPosition = new Vector2(distance * Mathf.Cos(rad), distance * Mathf.Sin(rad));
            arrow.transform.eulerAngles = new Vector3(0, 0, 0);

            Vector2 speed = dir * energy;
            rigidBody.velocity = new Vector2(0, speed.y);
            scene.Speed = speed.x;
            scene.State = Define.GameState.Playing;
        }
    }
}
