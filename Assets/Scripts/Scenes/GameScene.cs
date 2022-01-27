using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    UI_GameScene _sceneUI;
    [SerializeField]
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
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Screen.SetResolution(640, 480, false);

        _sceneUI = Managers.UI.ShowSceneUI<UI_GameScene>();

        State = Define.GameState.Start;
    }

    void StartGame()
    {
        Clear();
        _sceneUI.OnOffUI(false);
        Managers.UI.CloseAllPopupUI();
        _sceneUI.ShowReadyPopup();
    }

    void ReadyGame()
    {
        Clear();
        _sceneUI.OnOffUI(true);
        Managers.Map.CreateMap(1);
        character = Managers.Resource.Instantiate("Object/Character", this.transform).GetComponent<CharacterController>();
    }

    void EndGame()
    {
        _sceneUI.OnOffUI(false);
        _sceneUI.ShowEndPopup();
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
    }

    private void SetPlaying(bool isPlaying)
    {
        Managers.Map.currentMap.isPlaying = isPlaying;
        character.isPlaying = isPlaying;
    }

    public override void Clear()
    {
        Managers.Map.Clear();
        if (character != null)
            Managers.Resource.Destroy(character.gameObject);
    }
}
