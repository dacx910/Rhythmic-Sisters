using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump_height;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        body.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, jump_height);
    }
}
