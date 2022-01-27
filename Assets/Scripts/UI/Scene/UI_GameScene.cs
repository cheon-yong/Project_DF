using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GameScene : UI_Scene
{
    public UI_ReadyPopup ReadyPopup { get; private set; }
    public UI_EndPopup EndPopup { get; private set; }
    public UI_PausePopup PausePopup { get; private set; }

    enum Texts
    {
        Score,
        ScoreText,
        Best,
        BestText,
    }

    enum Buttons
    {
        PauseButton,
    }

    public override void Init()
	{
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        GetButton((int)Buttons.PauseButton).gameObject.BindEvent(OnClickPauseButton);

        //ReadyPopup = Managers.UI.ShowPopupUI<UI_ReadyPopup>();
        //EndPopup = Managers.UI.ShowPopupUI<UI_EndPopup>();
    }
    public void OnOffUI(bool on)
    {
        foreach (Texts text in Enum.GetValues(typeof(Texts)))
        {
            Get<Text>((int)text).gameObject.SetActive(on);
        }
        foreach (Buttons btn in Enum.GetValues(typeof(Buttons)))
        {
            Get<Button>((int)btn).gameObject.SetActive(on);
        }
    }

    public void ShowEndPopup()
    {
        EndPopup = Managers.UI.ShowPopupUI<UI_EndPopup>();
    }

    public void ShowReadyPopup()
    {
        ReadyPopup = Managers.UI.ShowPopupUI<UI_ReadyPopup>();
    }

    void OnClickPauseButton(PointerEventData evt)
    {
        Time.timeScale = 0;
        PausePopup = Managers.UI.ShowPopupUI<UI_PausePopup>();
    }

}
