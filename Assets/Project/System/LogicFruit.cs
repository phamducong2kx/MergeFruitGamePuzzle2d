using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LogicFruit : MonoBehaviour
{
    //danh scahs cacs prefab
    public List<Fruit> listFruit = new List<Fruit>();
    public Transform spawnY;
    public FruitData fruitDatabase;


    //1 cais list đư hết fruit vòa danh sách đẻ quản lí despawn khi kết thúc màn chơi
    public List<Fruit> listFruitManager = new List<Fruit>();


    private void Awake()
    {
        timeRemaning = duration + 1;
    }
    private void OnEnable()
    {
        EventManager.OnMergeFruit += HandleMerge;

    }



    private void OnDisable()
    {
        EventManager.OnMergeFruit -= HandleMerge;
    }

    //ham danbg ki su kien
    private void HandleMerge(Fruit fruit1, Fruit fruit2)
    {
        GameSystem.Instance.logicFruit.MergeFruit(fruit1, fruit2);
        //âm thanh ?
        //hiueej ứng ?
    }

    public Fruit fruitPrefab;
    public Fruit fruitCurrent;

    public int indexRandom;
    public float duration;
    public float timeRemaning;
    //load prefab random;
    public bool isCounting = false;

    public void Update()
    {

        //neeus thả chuột ra thì bắt đàu sự kiện
        if (!isCounting) return;
        if (timeRemaning < duration)
        {
            timeRemaning += Time.deltaTime;
        }
        else
        {
            if (fruitPrefab == null)
            {
                indexRandom = UnityEngine.Random.Range(0, 4);
                //prefab radom
                fruitPrefab = listFruit[indexRandom];
            }

            var gameobj = PoolManager.Instance.Spawn(fruitPrefab.gameObject, spawnY.position, Quaternion.identity);
            fruitCurrent = gameobj.GetComponentInChildren<Fruit>();
            AddFruitToList(fruitCurrent);

            fruitCurrent.SetupBodyKinematic();
            indexRandom = UnityEngine.Random.Range(0, 4);
            fruitPrefab = listFruit[indexRandom];

            //thay ảnh fruit image hint
            UIManager.Instance.gamePlay.SetupImageHintFruit(fruitPrefab);
            isCounting = false;
            timeRemaning = 0f;
        }
    }


    //merge fruit a ra fruit khac
    public void MergeFruit(Fruit a, Fruit b)
    {
        //timf kieems type
        var typeAfter = GetTypeAfterMerge(a.typeFruit);

        //lay vi tri de sinh ra 
        var tbX = (a.transform.position.x + b.transform.position.x) / 2;
        var tbY = (a.transform.position.y + b.transform.position.y) / 2;
        var spawnPosition = new Vector3(tbX, tbY, 0);

        //dua 2 game objct kia ve pool
        PoolManager.Instance.Despawn(a.gameObject);
        PoolManager.Instance.Despawn(b.gameObject);

        //spawn quả mới
        var fruit = PoolManager.Instance.Spawn(GetFruitById(typeAfter).gameObject, spawnPosition, Quaternion.identity);
        AddFruitToList(fruit.GetComponent<Fruit>());

        //spawn particle
        EffectManager.Instance.PlayParticleMerge(spawnPosition);

        //spawn dotrtwwen
        AnimationManager.Instance.pointEffect.GetPointEffect(spawnPosition, a.score);



        //ccộng điểm vào ui
        UIManager.Instance.gamePlay.AddPoint(a.score);
        //so sánh điểm hiện tại với điểm cao nhất
        SaveManager.AddPoint(UIManager.Instance.gamePlay.GetCurrentPoint());
        //cập nhật lại ui điểm
        UIManager.Instance.gamePlay.UpdetCoint();
        // return fruit.GetComponent<Fruit>();
        AudioManager.Instance.PlayMergeSound();
    }

    //timf kiếm fruit theo type
    public Fruit GetFruitById(TypeFruit type)
    {
        return listFruit.FirstOrDefault(x => x.typeFruit.Equals(type));
    }


    //timf kiếm point theo type
    public int GetPointByType(TypeFruit type)
    {
        return fruitDatabase.listFruits.FirstOrDefault(x => x.typeOrigin.Equals(type)).point;
    }



    //tim kiem id mới sau khi merge
    public TypeFruit GetTypeAfterMerge(TypeFruit oldType)
    {
        var find = fruitDatabase.listFruits.FirstOrDefault(x => x.typeOrigin.Equals(oldType));
        return find.typeAfterMerge;
    }

    //thêm 1 fruit vòa danh sách
    public void AddFruitToList(Fruit a)
    {
        listFruitManager.Add(a);
    }

    //Đưa tát cả các quả vào lại pool
    public void DespawnAllFruit()
    {
        //todo
        foreach (var x in listFruitManager)
        {
            if (x.gameObject.activeSelf == true)
                PoolManager.Instance.Despawn(x.gameObject);
        }
        listFruitManager.Clear();
        fruitPrefab = null;
    }

    void Start()
    {

    }



#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.yellow;
        Gizmos.DrawLine(new Vector3(-50, spawnY.position.y, 0), new Vector3(50, spawnY.position.y, 0));
    }
#endif
}
