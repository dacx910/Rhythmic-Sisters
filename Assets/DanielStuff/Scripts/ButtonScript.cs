using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey = KeyCode.E;
//    public UnityEvent interactAction;
    public Sprite Button;
    public Sprite ToggledButton;
    public GameObject Target;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                Target.GetComponent<JumpPad>().ChangeStatus();
                StartCoroutine(toggleButton(0.5f));
            }
        }
    }

    IEnumerator toggleButton(float seconds)
    {
        sr.sprite = ToggledButton;
        yield return new WaitForSeconds(seconds);
        sr.sprite = Button;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
