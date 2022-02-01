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

        SetButtonsIcon();
    }

    void OnClickStartButton(PointerEventData evt)
    {
        (Managers.Scene.CurrentScene as GameScene).State = Define.GameState.Ready;
        ClosePopupUI();
    }

    void SetButtonsIcon()
    {
        SetBgmIcon();
        SetEffectIcon();
    }

    public void SetBgmIcon()
    {
        if ((Managers.Scene.CurrentScene as GameScene).BgmFitch == 1)
            GetButton((int)Buttons.BgmButton).image.sprite = Managers.Resource.Load<Sprite>("Textures/icon_music_on");
        else
            GetButton((int)Buttons.BgmButton).image.sprite = Managers.Resource.Load<Sprite>("Textures/icon_music_off");
    } 
    
    public void SetEffectIcon()
    {
        if ((Managers.Scene.CurrentScene as GameScene).EffectFitch == 1)
            GetButton((int)Buttons.EffectButton).image.sprite = Managers.Resource.Load<Sprite>("Textures/icon_sound_on");
        else
            GetButton((int)Buttons.EffectButton).image.sprite = Managers.Resource.Load<Sprite>("Textures/icon_sound_off");
    }


    void OnClickBgmButton(PointerEventData evt)
    {
        float fitch = (Managers.Scene.CurrentScene as GameScene).BgmFitch;
        if (fitch == 1)
            (Managers.Scene.CurrentScene as GameScene).BgmFitch = 0;
        else
            (Managers.Scene.CurrentScene as GameScene).BgmFitch = 1;
        SetBgmIcon();
    }

    void OnClickEffectButton(PointerEventData evt)
    {
        float fitch = (Managers.Scene.CurrentScene as GameScene).EffectFitch;
        if (fitch == 1)
            (Managers.Scene.CurrentScene as GameScene).EffectFitch = 0;
        else
            (Managers.Scene.CurrentScene as GameScene).EffectFitch = 1;
        SetEffectIcon();
    }

}
