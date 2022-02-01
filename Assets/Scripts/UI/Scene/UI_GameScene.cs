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
        HeightText,
    }

    enum Buttons
    {
        PauseButton,
    }

    enum Images
    {
        Triangle,
    }

    public override void Init()
	{
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));

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

    public void SetBestScore()
    {
        GetText((int)Texts.BestText).text = PlayerPrefs.GetInt("bestScore", 0).ToString() + "M";
    }

    public void SetScoreText(float score)
    {
        GetText((int)Texts.ScoreText).text = ((int)score).ToString() + "M";
    }

    public void ShowEndPopup(int score)
    {
        ShowEndPopup();
        EndPopup.SetScoreText(score);
    }

    public void ShowTriangle(bool isOn)
    {
        GetImage((int)Images.Triangle).gameObject.SetActive(isOn);
    }

    public void SetHeightText(int height)
    {
        GetText((int)Texts.HeightText).text = height.ToString() + "M";
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
