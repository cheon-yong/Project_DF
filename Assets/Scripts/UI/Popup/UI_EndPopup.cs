    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_EndPopup : UI_Popup
{
    enum Texts
    {
        GameOverText,
        ScoreText,
    }


    enum Buttons
    {
        RetryButton,
        HomeButton,
    }

    
    public override void Init()
    {
        base.Init();

        Bind<Text>(typeof(Texts));
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.RetryButton).gameObject.BindEvent(OnClickRetryButton);
        GetButton((int)Buttons.HomeButton).gameObject.BindEvent(OnClickHomeButton);
    }

    public void SetScoreText(int score)
    {
        GetText((int)Texts.ScoreText).text = score.ToString() + "M";
    }

    void OnClickRetryButton(PointerEventData evt)
    {
        (Managers.Scene.CurrentScene as GameScene).State = Define.GameState.Ready;
        ClosePopupUI();
    }

    void OnClickHomeButton(PointerEventData evt)
    {
        (Managers.Scene.CurrentScene as GameScene).State = Define.GameState.Start;
        ClosePopupUI();
    }

}
