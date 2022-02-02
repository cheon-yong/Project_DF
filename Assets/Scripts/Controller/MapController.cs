using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField]
    Renderer quadRenderer;
    public bool isPlaying = false;
    float speed;

    GameScene gameScene;
    
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public void Refresh()
    {
        Speed = 0;
        quadRenderer.material.mainTextureOffset = new Vector2(0, 0);
    }


    private void Start()
    {
        if (gameScene == null)
        {
            gameScene = Managers.Scene.CurrentScene as GameScene;
        }
        gameScene.Score = 0;
    }

    private void Update()
    {
        if (isPlaying)
        {
            float score = Time.time * speed / 10 * Time.timeScale;
            gameScene.Score += score / 100;
            quadRenderer.material.mainTextureOffset = new Vector2(score, 0);
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

}
