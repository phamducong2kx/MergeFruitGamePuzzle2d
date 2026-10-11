using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GamePlay : MonoBehaviour
{

    [SerializeField] public UnityEngine.UI.Image imageFruit;
    public TextMeshProUGUI bestPoint;
    public TextMeshProUGUI currentPoint;
    public Button tutorial;
    public Button setting;
    private void Awake()
    {
        currentPoint.text = "0";
        SetupTutorialButton();
        SetupSettingButton();
    }

    public void UpdetCoint()
    {
        bestPoint.text = SaveManager.LoadPoint().ToString();
    }
    public void SetupBegin()
    {
        bestPoint.text = SaveManager.LoadPoint().ToString();
        currentPoint.text = "0";
    }
    //diem hien tai
    public int GetCurrentPoint()
    {
        return int.Parse(currentPoint.text);
    }
    public void AddPoint(int point)
    {
        var x = GetCurrentPoint() + point;
        currentPoint.text = x.ToString();
    }
    public void SetupImageHintFruit(Fruit a)
    {
        var image = a.GetComponentInChildren<SpriteRenderer>();
        imageFruit.sprite = image.sprite;
        //  imageHintFruit.
    }
    public void SetupTutorialButton()
    {
        tutorial.onClick.AddListener(() =>
        {
            GameSystem.Instance.inputHandler.enabled = false;
            UIManager.Instance.popup_tutor.gameObject.SetActive(true);
            Time.timeScale = 0;
        });
    }

    public void SetupSettingButton()
    {
        setting.onClick.AddListener(() =>
        {
            GameSystem.Instance.inputHandler.enabled = false;
            UIManager.Instance.popup_setting.gameObject.SetActive(true);
            Time.timeScale = 0;
        });
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
