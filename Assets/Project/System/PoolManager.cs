using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    public RectTransform poolCanvas;

    public Dictionary<GameObject, Queue<GameObject>> poolDict = new Dictionary<GameObject, Queue<GameObject>>();

    public Dictionary<GameObject, GameObject> parentDict = new Dictionary<GameObject, GameObject>();

    public Dictionary<GameObject, GameObject> instancePrefab = new Dictionary<GameObject, GameObject>();
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    //spawn fruit
    public GameObject Spawn(GameObject prefab, Vector2 position, Quaternion rotation)
    {
        //neu prefab chua co trong amp
        if (!poolDict.ContainsKey(prefab))
        {
            //đưa prefab vào map
            poolDict[prefab] = new Queue<GameObject>();

            //tao 1 game object để chứa các object của 1 preafb
            var obj = new GameObject();
            obj.name = prefab.name;

            // kiemr tra neues prefab có recttranfoem
            var rectrConponent = prefab.GetComponent<RectTransform>();

            //nếu có thif 
            if (rectrConponent != null)
            {

                obj.transform.SetParent(poolCanvas, false);
                obj.AddComponent<RectTransform>();
            }
            else
            {
                obj.transform.SetParent(transform, false);
            }
            //obj.transform.SetParent(transform, false);
            parentDict.Add(prefab, obj);

        }
        //kiêm tra xem nếu queue hết object thì add và queue
        GameObject gameobj = null;
        if (poolDict[prefab].Count == 0)
        {
            gameobj = Instantiate(prefab, parentDict[prefab].transform);
            instancePrefab.Add(gameobj, prefab);


        }

        //nếu mà đã có object sẵn có trong queue thif laasy ra
        else
        {
            gameobj = poolDict[prefab].Dequeue();
        }
        gameobj.SetActive(true);
        //set up vị trí của gameobject
        gameobj.transform.position = position;
        gameobj.transform.rotation = rotation;
        return gameobj;


    }

    //despawn fruit
    public void Despawn(GameObject obj)
    {
        //set object là false
        obj.SetActive(false);

        //tim prefab cua obj nay
        var prefab = instancePrefab[obj];

        //đưa vào queue
        poolDict[prefab].Enqueue(obj);

        //làm con của gameobject 
        //  obj.transform.SetParent(parentDict[prefab].transform, false);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
