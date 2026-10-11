using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [Header("Elements")]
    public Menu menu;
    public GamePlay gamePlay;
    public GameOver gameOver;
    public Tutorial_Popup popup_tutor;
    public Setting_popup popup_setting;
    public Loading loadingUi;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    public void SetMenu()
    {
        menu.gameObject.SetActive(true);
        gamePlay.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
    }
    public void SetGamePlay()
    {
        menu.gameObject.SetActive(false);
        gamePlay.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }
    public void SetGamOver()
    {
        menu.gameObject.SetActive(false);
        gamePlay.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
