using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float Bounce = 20f;
    public bool Activated = true;
    SpriteRenderer sprite;
    BoxCollider2D collision;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        collision = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (Activated)
        {
            sprite.color = new Color(255, 255, 255, 255);
            collision.enabled = true;
        } else
        {
            sprite.color = new Color(255, 255, 255, 0);
            collision.enabled = false;
        }
    }
    public void ChangeStatus()
    {
        if (Activated)
        {
            enabled = false;
        } else
        {
            enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Activated)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Bounce, ForceMode2D.Impulse);
        }
    }
}
