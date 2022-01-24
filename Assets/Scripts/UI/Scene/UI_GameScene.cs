using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameScene : UI_Scene
{
    public UI_ReadyPopup ReadyPopup { get; private set; }

    public override void Init()
	{
        base.Init();

        //ReadyPopup = Managers.UI.ShowPopupUI<UI_ReadyPopup>();

    }

}
