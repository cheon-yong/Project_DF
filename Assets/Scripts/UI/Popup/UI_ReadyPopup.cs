    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ReadyPopup : UI_Popup
{
    enum Buttons
    {
        StartButton,
        BgmButton,
        EffectButton,
    }

    enum Images
    {
        TitleImage,
    }


    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));

        GetButton((int)Buttons.StartButton).gameObject.BindEvent(OnClickStartButton);
        GetButton((int)Buttons.BgmButton).gameObject.BindEvent(OnClickBgmButton);
        GetButton((int)Buttons.EffectButton).gameObject.BindEvent(OnClickEffectButton);
    }

    void OnClickStartButton(PointerEventData evt)
    {
        Managers.Scene.CurrentScene.Clear();
        (Managers.Scene.CurrentScene as GameScene).State = Define.GameState.Ready;
        ClosePopupUI();
    }

    void OnClickBgmButton(PointerEventData evt)
    {
        //Managers.Sound.Mute(Define.Sound.Bgm);
    }

    void OnClickEffectButton(PointerEventData evt)
    {
        //Managers.Sound.Mute(Define.Sound.Bgm);
    }

}
