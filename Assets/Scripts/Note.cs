using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    [SerializeField] float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Col1")
        {
            sr.color = new Color(255, 0, 0);
        }
        else if(col.gameObject.tag == "Col2")
        {
            sr.color = new Color(0, 255, 0);
        }
        else if(col.gameObject.tag == "Col3")
        {
            sr.color = new Color(0, 0, 255);
        }
        else if(col.gameObject.tag == "Col4")
        {
            sr.color = new Color(255, 0, 255);
        }
        else
        {
            Debug.Log("Something broke");
        }
    }
}
