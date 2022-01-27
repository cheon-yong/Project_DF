using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField]
    Renderer quadRenderer;
    public bool isPlaying = false;
    float speed;

    public float percentage = 60.0f;
    public float cycleTime = 0.1f;
    GameObject firstObject;

    Dictionary<int, GameObject> objects = new Dictionary<int, GameObject>();
    
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void Start()
    {
        firstObject = Managers.Resource.Instantiate("Object/MapObject", this.transform);
        firstObject.transform.localPosition = new Vector3(-9.5f, -3f, -1f);
    }

    float deltaTime = 0;
    private void Update()
    {
        deltaTime += Time.deltaTime;
        if (isPlaying)
        { 
            quadRenderer.material.mainTextureOffset = new Vector2(Time.time * speed / 10, 0);
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
        firstObject.GetComponent<MapObject>().SetSpeed(speed);
    }

}
