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
