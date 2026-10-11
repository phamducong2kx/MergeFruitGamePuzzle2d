using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button playGame;
    public TextMeshProUGUI bestScore;
    // Start is called before the first frame update
    private void Awake()
    {

    }
    private void OnEnable()
    {
        SetupButton();
        SetupScore();
    }
    public void SetupButton()
    {
        playGame.onClick.AddListener(() =>
        {
            //chueyenr towsi sate gameplay
            GameStateManager.Instance.GameStateChange(GameStateInstance.gamplayState);
        });

    }

    public void SetupScore()
    {
        bestScore.text = SaveManager.LoadPoint().ToString();

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
