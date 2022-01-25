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

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    

    private void Start()
    {
        //quadRenderer = GetComponent<Renderer>();
    }

    float deltaTime = 0;
    private void Update()
    {
        deltaTime += Time.deltaTime;
        if (isPlaying)
        { 
            quadRenderer.material.mainTextureOffset = new Vector2(Time.time * 5.0f, 0);

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

    }

}
