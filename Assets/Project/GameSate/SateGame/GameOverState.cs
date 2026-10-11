using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverState : IGameState
{

    public void EnterState()
    {
        //kicsh hoatj ui
        UIManager.Instance.SetGamOver();

    }

    public void ExistSate()
    {
        //hủy hết các corotine , dotween: cái này đã làm khi gọi sự kiện game over
        //Đưa tất cả các object về lại pool:gọi trong logic system
        //đóng ui
        UIManager.Instance.gameOver.gameObject.SetActive(false);

        //đóng system
        // GameSystem.Instance.logicFruit.DespawnAllFruit();
    }
}
