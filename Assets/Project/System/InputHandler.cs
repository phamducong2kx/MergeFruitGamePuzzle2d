using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    private Camera _camera;

    [Header("Element")]


    [Header("Setting")]
    // [SerializeField] private Transform spawnY;
    [SerializeField] private LineRenderer lineRenderer;
    private Vector3 worldPoint;
    private Vector3 mouseWordPoint;
    [SerializeField] public Fruit instanceFruit;
    public float duration = 1.5f;
    public float timeRemaing;
    public bool isClickUp = false;
    public bool clickButton = false;



    private void Awake()
    {
        _camera = Camera.main;
        timeRemaing = duration + 1;
    }
    private void OnEnable()
    {
        HideLine();
        instanceFruit = GameSystem.Instance.logicFruit.fruitCurrent;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (GameSystem.Instance.logicFruit.fruitCurrent == null || clickButton == true) return;



        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {

            HandlePositionMouse(GameSystem.Instance.logicFruit.fruitCurrent.radius);
            //  Debug.Log("co nhan su kien nhan co man hinh khong");
            DisplayLine();
            GameSystem.Instance.logicFruit.fruitCurrent.SetPosition(worldPoint);

            if (isClickUp == false)
            {
                AudioManager.Instance.PlayClickSound();
                isClickUp = true;
            }

        }

        else if (Input.GetMouseButtonUp(0))
        {
            isClickUp = false;
            HideLine();
            AudioManager.Instance.PlayDropSound();
            GameSystem.Instance.logicFruit.fruitCurrent.SetupBodyDynamic();
            GameSystem.Instance.logicFruit.fruitCurrent = null;
            GameSystem.Instance.logicFruit.isCounting = true;




        }
    }



    //? them radius cua 1 fruit ?
    private void HandlePositionMouse(float radius)
    {
        mouseWordPoint = Input.mousePosition;
        worldPoint = _camera.ScreenToWorldPoint(mouseWordPoint);

        worldPoint.y = GameSystem.Instance.logicFruit.spawnY.transform.position.y;
        if (worldPoint.x <= UIManager.Instance.menu.leftWall.position.x + radius)
        {
            // worldPoint.x = UIManager.Instance.menu.radiusLeftLimit.transform.position.x;
            worldPoint.x = UIManager.Instance.menu.leftWall.position.x + radius;
        }
        else if (worldPoint.x >= UIManager.Instance.menu.rightWall.position.x - radius)
        {
            // worldPoint.x = UIManager.Instance.menu.radiusRightLimit.transform.position.x;
            worldPoint.x = UIManager.Instance.menu.rightWall.position.x - radius;
        }

    }

    //hiển thị line
    private void DisplayLine()
    {
        lineRenderer.enabled = true;
        lineRenderer.transform.position = new Vector3(worldPoint.x, GameSystem.Instance.logicFruit.spawnY.position.y, 0);

    }
    private void HideLine()
    {
        lineRenderer.enabled = false;
    }



}
