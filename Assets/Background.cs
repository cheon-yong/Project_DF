using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Renderer quadRenderer;
    void Start()
    {
        quadRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        //quadRenderer.material.mainTextureOffset = new Vector2(Time.time * 5.0f, 0);
    }
}
