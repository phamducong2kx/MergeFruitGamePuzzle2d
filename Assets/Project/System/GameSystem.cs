using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static GameSystem Instance;

    public LogicFruit logicFruit;

    public InputHandler inputHandler;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SetPlayGame()
    {
        inputHandler.gameObject.SetActive(true);
        // logicFruit.LoadFruitPrefabRandom();
    }
    public void SetOutGame()
    {
        inputHandler.gameObject.SetActive(false);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
