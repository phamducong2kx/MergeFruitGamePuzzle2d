using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public Button home;
    public Button nextGame;
    // public Button 
    void Start()
    {
        SetupHome();
        SetupNextGame();
    }

    public void SetupHome()
    {
        home.onClick.AddListener(() =>
        {
            //  Debug.Log("trở về homeesate");
            GameStateManager.Instance.GameStateChange(GameStateInstance.homeState);
        });
    }
    public void SetupNextGame()
    {
        nextGame.onClick.AddListener(() =>
        {
            GameStateManager.Instance.GameStateChange(GameStateInstance.gamplayState);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
