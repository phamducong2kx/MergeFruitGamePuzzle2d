using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHomeEffect : MonoBehaviour
{
    //hàm di chuyển lên xuông
    //danh sách các fruit iamge
    public List<SpriteRenderer> litSpriteFruit = new List<SpriteRenderer>();

    private void Awake()
    {
        SetUpPóitionFruitBegin();
    }
    //set up vi tri cho cac fruit
    public void SetUpPóitionFruitBegin()
    {
        //camera
        Camera cam = Camera.main;
        //timf kiếm vị trí viewport và convert sang tạo đọ thế giới
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, cam.nearClipPlane));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, cam.nearClipPlane));
        foreach (var x in litSpriteFruit)
        {
            if (x.transform.position.x <= leftEdge.x)
            {
                x.transform.position = new Vector3(leftEdge.x + Random.Range(1f, 2f), x.transform.position.y, 0);
            }
            else if (x.transform.position.x >= rightEdge.x)
            {
                x.transform.position = new Vector3(rightEdge.x - Random.Range(1f, 2f), x.transform.position.y, 0);
            }
        }


    }
    public void AnimationFruitHome()
    {
        foreach (var x in litSpriteFruit)
        {
            x.gameObject.SetActive(true);
            x.transform.DOMoveY(x.transform.position.y + 0.2f, 4f)
                  .SetLoops(-1, LoopType.Yoyo)
                  .SetLink(x.gameObject, LinkBehaviour.KillOnDisable);

        }
    }
    private void OnEnable()
    {
        AnimationFruitHome();
    }
    private void OnDisable()
    {
        foreach (var x in litSpriteFruit)
        {
            x.gameObject.SetActive(false);
            // x.transform.DOKill();
        }

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
