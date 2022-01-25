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

        // TODO : Charater and map load
        Managers.Map.CreateMap(1);
        character = Managers.Resource.Instantiate("Object/Character", this.transform).GetComponent<CharacterController>();
    }

    void UpdateState()
    {
        switch(_state)
        {
            case Define.GameState.Ready:
                break;
            case Define.GameState.Playing:
                SetSpeed();
                break;
            case Define.GameState.End:
                break;
        }
    }

    private void SetSpeed()
    {
        Managers.Map.currentMap.SetSpeed(Speed);
    }

    public override void Clear()
    {
        
    }
}
