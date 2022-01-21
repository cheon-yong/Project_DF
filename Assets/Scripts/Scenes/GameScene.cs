using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    UI_GameScene _sceneUI;

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

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Screen.SetResolution(640, 480, false);

        _sceneUI = Managers.UI.ShowSceneUI<UI_GameScene>();

        // TODO : Charater and map load

    }

    void UpdateState()
    {
        switch(_state)
        {
            case Define.GameState.Ready:
                break;
            case Define.GameState.Playing:
                break;
            case Define.GameState.End:
                break;
        }
    }

    public override void Clear()
    {
        
    }
}
