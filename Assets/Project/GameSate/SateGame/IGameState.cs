using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameState
{
    //voaf state
    public void EnterState();

    //ra state
    public void ExistSate();




}

public static class GameStateInstance
{
    public static readonly IGameState homeState = new HomeState();
    public static readonly IGameState gamplayState = new GameplaySate();
    public static readonly IGameState gameOverState = new GameOverState();
    public static readonly IGameState loadingState = new LoadingState();
}
