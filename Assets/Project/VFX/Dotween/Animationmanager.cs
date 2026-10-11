using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance;
    public PointEffect pointEffect;
    public MoveHomeEffect moveHomeEffect;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    //disactive effect
    public void DisActiveEffect()
    {
        pointEffect.gameObject.SetActive(false);
    }
    //disactive effect
    public void SetupGamePlay()
    {
        pointEffect.gameObject.SetActive(true);
        moveHomeEffect.gameObject.SetActive(false);
    }

    public void SetupHome()
    {
        pointEffect.gameObject.SetActive(false);
        moveHomeEffect.gameObject.SetActive(true);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //dudwa heets casc particle về ppool
    public void DespawnParticle()
    {

    }
}
