using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField]
    Renderer quadRenderer;

    int mapNumber;
    float speed;

    private void Start()
    {
        quadRenderer = GetComponent<Renderer>();
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

}
