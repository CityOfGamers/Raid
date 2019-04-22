using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplay : StateMachineBehaviour
{
    public enum uiDisplayCam { PlayerSettings, JoinGame, CreateGame, Options, Quit, Raider};

    public uiDisplayCam cam;



    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        switch (cam)
        {
            case uiDisplayCam.PlayerSettings:
                break;
            case uiDisplayCam.JoinGame:
                break;
            case uiDisplayCam.CreateGame:
                break;
            case uiDisplayCam.Options:
                break;
            case uiDisplayCam.Quit:
                break;
            case uiDisplayCam.Raider:
                break;
            default:
                break;
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        switch (cam)
        {
            case uiDisplayCam.PlayerSettings:
                break;
            case uiDisplayCam.JoinGame:
                break;
            case uiDisplayCam.CreateGame:
                break;
            case uiDisplayCam.Options:
                break;
            case uiDisplayCam.Quit:
                break;
            case uiDisplayCam.Raider:
                break;
            default:
                break;
        }
    }
}
