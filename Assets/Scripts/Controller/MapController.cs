using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField]
    Renderer quadRenderer;
    bool isPlaying = false;
    float speed;
    float cycleTime = 3.0f;
    int objectCount = 0;

    Dictionary<int, GameObject> objects = new Dictionary<int, GameObject>();

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void Start()
    {
        //quadRenderer = GetComponent<Renderer>();
        GameObject go = Managers.Resource.Instantiate("Object/MapObject", this.transform);
        objects.Add(objectCount, go);
    }

    float deltaTime = 0;
    private void Update()
    {
        deltaTime += Time.deltaTime;
        if (isPlaying)
        { 
            quadRenderer.material.mainTextureOffset = new Vector2(Time.time * speed / 10, 0);
            //quadRenderer.material.mainTextureOffset = Vector2.MoveTowards(quadRenderer.material.mainTextureOffset,
              //  quadRenderer.material.mainTextureOffset + new Vector2(1, 0), speed * deltaTime);

            if (deltaTime > cycleTime)
            {
                GameObject go = Managers.Resource.Instantiate("Object/MapObject", this.transform);
                go.GetComponent<MapObject>().SetSpeed(Speed);

                deltaTime = 0;
            }
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
        isPlaying = true;
        foreach(GameObject go in objects.Values)
        {
            go.GetComponent<MapObject>().SetSpeed(Speed);
        }
    }

}
