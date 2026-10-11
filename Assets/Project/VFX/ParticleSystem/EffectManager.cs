using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance;

    public ParticleSystem particleMerge;



    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    //chay parrticle merrge

    public void PlayParticleMerge(Vector3 position)
    {
        //sinh particle taij vị trí
        var obj = PoolManager.Instance.Spawn(particleMerge.gameObject, position, Quaternion.identity);
        //chay
        //sau đó chạy corotine
        StartCoroutine(DesdpawnCorotine(1, obj));

    }


    IEnumerator DesdpawnCorotine(float delay, GameObject obj)
    {
        yield return new WaitForSeconds(delay);
        PoolManager.Instance.Despawn(obj);

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
