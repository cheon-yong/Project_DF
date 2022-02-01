using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_PausePopup : UI_Popup
{
    enum Buttons
    {
        ContinueButton,
        RetryButton,
        HomeButton,
    }

    enum Texts
    {
        PauseText,
    }


    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        GetButton((int)Buttons.ContinueButton).gameObject.BindEvent(OnClickContinueButton);
        GetButton((int)Buttons.RetryButton).gameObject.BindEvent(OnClickRetryButton);
        GetButton((int)Buttons.HomeButton).gameObject.BindEvent(OnClickHomeButton);
    }

    void OnClickContinueButton(PointerEventData evt)
    {
        //Managers.Scene.CurrentScene.Clear();
        Close();
    }

    void OnClickRetryButton(PointerEventData evt)
    {
        //Managers.Sound.Mute(Define.Sound.Bgm);
        (Managers.Scene.CurrentScene as GameScene).State = Define.GameState.Ready;
        Close();
    }

    void OnClickHomeButton(PointerEventData evt)
    {
        //Managers.Sound.Mute(Define.Sound.Bgm);
        (Managers.Scene.CurrentScene as GameScene).State = Define.GameState.Start;
        Close();
    }

    void Close()
    {
        Time.timeScale = 1;
        ClosePopupUI();
    }
}
