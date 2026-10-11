using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeState : IGameState
{
    public bool checkGoFirst = true;
    public void EnterState()
    {
        //okee
        UIManager.Instance.SetMenu();
        AnimationManager.Instance.SetupHome();
        //chơi nhạc nền
        if (checkGoFirst)
        {
            AudioManager.Instance.PlayNhacNen();
            checkGoFirst = false;
        }


    }

    public void ExistSate()
    {
        //chuyenr voaf màn chơi game
        // UIManager.Instance.SetGamePlay();

    }
}
