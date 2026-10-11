using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting_popup : MonoBehaviour
{
    public Button exist;
    public Button home;
    public Button retry;
    public Button sound;
    public Button music;
    public UnityEngine.UI.Image imageSound;
    public Sprite offSound;
    public Sprite onSound;
    private void Awake()
    {
        imageSound.sprite = onSound;
        SetUpExist();
        SetUpHome();
        SetUpRetry();
        SetUpSound();
        SetUpMusic();
    }
    //exist
    public void SetUpExist()
    {
        exist.onClick.AddListener(() =>
        {
            ExistPop();
        });
    }
    public void ExistPop()
    {
        GameSystem.Instance.inputHandler.enabled = true;
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    //home
    public void SetUpHome()
    {
        home.onClick.AddListener(() =>
        {
            //tro ve gamstate home
            ExistPop();
            // GameSystem.Instance.logicFruit.DespawnAllFruit();
            GameStateManager.Instance.GameStateChange(GameStateInstance.homeState);
        });
    }

    //retry
    public void SetUpRetry()
    {
        retry.onClick.AddListener(() =>
        {

            //tro ve gamstate home
            ExistPop();
            GameStateManager.Instance.GameStateChange(GameStateInstance.homeState);
            GameStateManager.Instance.GameStateChange(GameStateInstance.gamplayState);
        });
    }

    //retry
    public void SetUpSound()
    {
        sound.onClick.AddListener(() =>
        {
            if (imageSound.sprite == onSound)
            {
                AudioManager.Instance.SoundOff();
                imageSound.sprite = offSound;
                Debug.Log("da ta am thnah");

            }
            else if (imageSound.sprite == offSound)
            {
                AudioManager.Instance.SoundOn();
                imageSound.sprite = onSound;
                Debug.Log("da bat am thnah");
            }
        });
    }
    //retry
    public void SetUpMusic()
    {
        music.onClick.AddListener(() =>
        {

        });
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
