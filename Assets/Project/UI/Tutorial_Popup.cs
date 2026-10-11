using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Popup : MonoBehaviour
{

    public Button exist;
    private void Awake()
    {
        SetUpExist();
    }
    public void SetUpExist()
    {
        exist.onClick.AddListener(() =>
        {
            GameSystem.Instance.inputHandler.enabled = true;
            gameObject.SetActive(false);
            Time.timeScale = 1f;
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
