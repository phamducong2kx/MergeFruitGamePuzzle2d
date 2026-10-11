using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public IGameState currentGameState;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        currentGameState = GameStateInstance.loadingState;
    }

    public void GameStateChange(IGameState newState)
    {
        currentGameState.ExistSate();
        //satte hienej tạo = state mới
        currentGameState = newState;
        //enter state mới
        currentGameState.EnterState();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("gamestat hie tasij la " + currentGameState);
    }
}
