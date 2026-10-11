using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    public Scrollbar scrollbar;
    public float loadingTime;
    private void Awake()
    {
        SetupLoadingBar();
    }
    void SetupLoadingBar()
    {
        scrollbar.size = 0;
    }
    private void Start()
    {
        StartCoroutine(StartCorotineDeplay());
    }
    public IEnumerator StartCorotineDeplay()
    {
        float timer = 0;
        while (timer < loadingTime)
        {
            timer += Time.deltaTime;
            scrollbar.size = timer / loadingTime;
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        GameStateManager.Instance.GameStateChange(GameStateInstance.homeState);

    }



    // Update is called once per frame
    void Update()
    {

    }
}
