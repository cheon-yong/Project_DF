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
        EndButton,
    }

    enum Texts
    {
        StartButtonText,
        BgmButtonText,
        EffectButtonText,
        EndButtonText,
    }


    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        GetButton((int)Buttons.StartButton).gameObject.BindEvent(OnClickStartButton);
        GetButton((int)Buttons.BgmButton).gameObject.BindEvent(OnClickBgmButton);
        GetButton((int)Buttons.EffectButton).gameObject.BindEvent(OnClickEffectButton);
        GetButton((int)Buttons.EndButton).gameObject.BindEvent(OnClickEndButton);
    }

    void OnClickStartButton(PointerEventData evt)
    {
        Managers.Scene.CurrentScene.Clear();
    }

    void OnClickBgmButton(PointerEventData evt)
    {
        //Managers.Sound.Mute(Define.Sound.Bgm);
    }

    void OnClickEffectButton(PointerEventData evt)
    {
        //Managers.Sound.Mute(Define.Sound.Bgm);
    }

    void OnClickEndButton(PointerEventData evt)
    {
        Application.Quit();
    }

}
