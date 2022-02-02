using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public float percentage = 60.0f;
    public float cycleTime = 0.1f;

    UI_GameScene _sceneUI;

    GameObject triangle;
    CharacterController character;

    Define.GameState _state;
    public Define.GameState State
    {
        get { return _state; }
        set
        {
            _state = value;
            UpdateState();
        }
    }

    float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    float score;
    public float Score
    {
        get { return score; }
        set 
        { 
            score = value;
            _sceneUI.SetScoreText(score);
        }
    }

    bool isOverScreen = false;
    public bool IsOverScreen
    {
        get { return isOverScreen; }
        set
        {
            isOverScreen = value;
            _sceneUI.ShowTriangle(value);
        }
    }

    public float BgmFitch
    {
        get { return PlayerPrefs.GetFloat("bgm", 1.0f); }
        set 
        { 
            PlayerPrefs.SetFloat("bgm", value);
            Managers.Sound.Clear();
            Managers.Sound.Play("bgm", Define.Sound.Bgm, value);
        }
    }
    public float EffectFitch
    {
        get { return PlayerPrefs.GetFloat("effect", 1.0f); }
        set { PlayerPrefs.SetFloat("effect", value); }
    }

    float deltaTime = 0;
    private void Update()
    {
        if (State != Define.GameState.Playing)
            return;

        if (IsOverScreen)
            _sceneUI.SetHeightText((int)character.transform.position.y);

        deltaTime += Time.deltaTime;
        if (deltaTime > cycleTime)
        {
            Managers.Object.CreateObject(percentage);
            deltaTime = 0;
        }
    }


    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        //Screen.SetResolution(640, 480, false);

        _sceneUI = Managers.UI.ShowSceneUI<UI_GameScene>();

        Managers.Sound.Play("bgm", Define.Sound.Bgm, BgmFitch);

        State = Define.GameState.Start;
    }

    void StartGame()
    {
        Clear();
        _sceneUI.OnOffUI(false);
        Managers.UI.CloseAllPopupUI();
        Managers.Map.CreateMap(1);
        _sceneUI.ShowReadyPopup();
    }

    void ReadyGame()
    {
        _sceneUI.OnOffUI(true);
        _sceneUI.SetBestScore();
        Score = 0;
        Managers.Map.currentMap.Refresh();
        Managers.Object.Clear();
        Managers.Object.CreateObject(new Vector3(-7.5f, -3f, -1f));
        if (character != null)
            Managers.Resource.Destroy(character.gameObject);
        character = Managers.Resource.Instantiate("Object/Character", this.transform).GetComponent<CharacterController>();
        character.transform.localPosition = new Vector3(-7.5f, -3f);
    }

    void EndGame()
    {
        int bestScore = PlayerPrefs.GetInt("bestScore", 0);
        PlayerPrefs.SetInt("bestScore", Math.Max(bestScore, (int)score));
        _sceneUI.OnOffUI(false);
        _sceneUI.ShowEndPopup((int)score);
    }
    

    void UpdateState()
    {
        switch(_state)
        {
            case Define.GameState.Start:
                StartGame();
                break;
            case Define.GameState.Ready:
                ReadyGame();
                break;
            case Define.GameState.Playing:
                SetSpeed();
                SetPlaying(true);
                break;
            case Define.GameState.End:
                SetSpeed(0);
                SetPlaying(false);
                EndGame();
                break;
        }
    }

    private void SetSpeed(float speed)
    {
        this.speed = speed;
        SetSpeed();
    }

    private void SetSpeed()
    {
        Managers.Map.currentMap.SetSpeed(Speed);
        Managers.Object.Speed = Speed;
    }

    private void SetPlaying(bool isPlaying)
    {
        Managers.Map.currentMap.isPlaying = isPlaying;
        character.isPlaying = isPlaying;
    }

    public void ShowTriangle()
    {

    }

    public override void Clear()
    {
        Managers.Map.Clear();
        Managers.Object.Clear();
        if (character != null)
            Managers.Resource.Destroy(character.gameObject);
    }
}
