using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float jump_height = 10;
    private Animator anim;
    private Rigidbody2D body;

    private void Awake()
    {
        // References
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector3(horizontalInput * speed, body.velocity.y);

        // Texture flipper based on movement
        if (horizontalInput > 0.01f) {
            transform.localScale = Vector3.one;
        } else if (horizontalInput < -0.01f) {
            transform.localScale = new Vector3(-1,1,1);
        }

        if (Input.GetKey(KeyCode.Space)) {
            body.velocity = new Vector2(body.velocity.x, jump_height);
        }

        // Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
    }
}
