using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySate : IGameState
{
    public void EnterState()
    {
        //kich hoat sýtem
        GameSystem.Instance.SetPlayGame();
        //
        AnimationManager.Instance.SetupGamePlay();
        //kích hoạt UI
        UIManager.Instance.SetGamePlay();
        UIManager.Instance.gamePlay.SetupBegin();
        //iscouting trong logicfruit = true
        GameSystem.Instance.logicFruit.isCounting = true;

    }

    public void ExistSate()
    {
        //disalbe system
        GameSystem.Instance.SetOutGame();
        //disable effetc
        AnimationManager.Instance.DisActiveEffect();

        GameSystem.Instance.logicFruit.DespawnAllFruit();
    }


}
