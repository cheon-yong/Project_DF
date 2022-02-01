using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField]
    Renderer quadRenderer;
    public bool isPlaying = false;
    float speed;
    int distance;

    public float percentage = 60.0f;
    public float cycleTime = 0.1f;
    GameScene gameScene;
    GameObject firstObject;

    
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void Start()
    {
        firstObject = Managers.Resource.Instantiate("Object/MapObject", this.transform);
        firstObject.transform.localPosition = new Vector3(-7.5f, -3f, -1f);
        if (gameScene == null)
        {
            gameScene = Managers.Scene.CurrentScene as GameScene;
        }
        gameScene.Score = 0;
    }

    float deltaTime = 0;
    private void Update()
    {
        deltaTime += Time.deltaTime;
        if (isPlaying)
        {
            float score = Time.time * speed / 10;
            gameScene.Score += score / 100;
            quadRenderer.material.mainTextureOffset = new Vector2(score, 0);
            if (deltaTime > cycleTime)
            {
                CreateObject();
                deltaTime = 0;
            }
        }
    }

    private void CreateObject()
    {
        if (Random.Range(0, 100) > percentage)
        {
            GameObject go = Managers.Resource.Instantiate("Object/MapObject", this.transform);
            go.transform.localPosition = new Vector3(20.5f, -3f, -1f);
            go.GetComponent<MapObject>().SetSpeed(Speed + Random.Range(0, Speed));
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
        if (firstObject != null)
            firstObject.GetComponent<MapObject>().SetSpeed(speed);
    }

}
