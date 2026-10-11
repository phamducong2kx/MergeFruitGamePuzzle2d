using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Fruit : MonoBehaviour
{
    [SerializeField] public TypeFruit typeFruit;
    [SerializeField] public int score;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D colider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool isMerge = false;
    private bool isCollider = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        colider = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        score = GameSystem.Instance.logicFruit.GetPointByType(typeFruit);
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {


    }



    public void SetupBodyKinematic()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
    public void SetupBodyDynamic()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    public void SetPosition(Vector3 position)
    {

        rb.MovePosition(position);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Fruit>(out Fruit fruit))
        {
            //  isCollider = true;
            //fruit.isCollider = true;
            //if 2 thawnfg cungf id ->
            if (fruit.typeFruit.Equals(typeFruit) && transform.position.y >= fruit.transform.position.y)
            {
                Debug.Log("suw kien dc kich hoat");
                //kicsh hoatj event
                EventManager.InvokeMergeFruit(this, fruit);
            }

        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
