using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameOverLine : MonoBehaviour
{
    //tạo danh sách các quả vừa rơi xuống khu vực nguy hiểm
    [SerializeField] private Dictionary<Fruit, Coroutine> map = new Dictionary<Fruit, Coroutine>();
    public float duration = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Fruit>(out Fruit fruit))
        {
            if (!map.ContainsKey(fruit))
            {
                //khởi taopj corotine
                var corotine = StartCoroutine(TimeCorotine(fruit));
                //cho voà map
                map[fruit] = corotine;
            }


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //tắt corotine của fruit vừa rơi
        if (collision.TryGetComponent<Fruit>(out Fruit fruit))
        {
            if (map.ContainsKey(fruit))
            {
                //fruit duoc dua vao list

                //sau do bat dau startcorotine
                StopCoroutine(map[fruit]);

                //xoas khowir map
                map.Remove(fruit);
            }


        }
    }

    private IEnumerator TimeCorotine(Fruit fruit)
    {
        yield return new WaitForSeconds(duration);
        if (fruit != null && map.ContainsKey(fruit))
        {
            //neues thua , xuwr li
            // xoas corotine
            // chuyen ve statys loss
            Debug.Log("--------GAME OVER----------");
            ClearMap();
            //chuyeenr towis state mới
            GameStateManager.Instance.GameStateChange(GameStateInstance.gameOverState);

        }

    }

    private void ClearMap()
    {
        foreach (var x in map)
        {
            StopCoroutine(map[x.Key]);

        }
        map.Clear();
    }


}
