using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointEffect : MonoBehaviour
{
    public TextMeshProUGUI pointAniamtionPrefab;
    public List<TextMeshProUGUI> list;

    public void GetPointEffect(Vector3 position, int score)
    {
        //khoi tao đói tượng từ prefab
        var x = PoolManager.Instance.Spawn(pointAniamtionPrefab.gameObject, position, Quaternion.identity);
        var scoreText = x.GetComponent<TextMeshProUGUI>();
        list.Add(scoreText);
        scoreText.text = $"+{score}";
        scoreText.transform.DOMoveY(position.y + 1.5f, 0.6f);
        scoreText.transform.DOScale(1.2f, 1f).OnComplete(() =>
        {
            Debug.Log("đã hiển thị point  efect");
            //  scoreText.transform.DOScale(1f, 4f);
            scoreText.transform.DOKill();
            PoolManager.Instance.Despawn(x);
        });
    }

    private void OnDisable()
    {
        Debug.Log("co chay vo disable khong vay ae");
        foreach (var x in list)
        {
            x.transform.DOKill();
            PoolManager.Instance.Despawn(x.gameObject);
        }
        list.Clear();
    }

    void Start()
    {

    }


    void Update()
    {

    }
}
