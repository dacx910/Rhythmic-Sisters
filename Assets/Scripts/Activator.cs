using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public KeyCode key;
    bool active = false;
    GameObject note;
    SpriteRenderer sr;
    Color old;

    public bool createMode;
    public GameObject n;

    public static int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        old = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        active = false;
        if(createMode)
        {
            if(Input.GetKeyDown(key))
            {
                Instantiate(n, transform.position, Quaternion.identity);
            }
        }
        else
        {
            
            // if(Input.GetKeyDown(key))
            // {
            //     StartCoroutine(Pressed());
            //     active = true;
            //     Debug.Log("Key Down");
            // }
            // if(Input.GetKeyDown(key) && active == false)
            // {
            //     LowerScore(20);
            //     Debug.Log("Key Down & Active is False");
            // }
            // if(Input.GetKeyDown(key) && active)
            // {
            //     Destroy(note);
            //     AddScore();
            //     Debug.Log("Key Down & Active is True");
            // }

            if(Input.GetKeyDown(key))
            {
                StartCoroutine(Pressed()); //Starts the Pressed Coroutine, which changes the color of the activator to black for a short period of time.
            }
            else if(Input.GetKeyDown(key) && active == false)
            {
                LowerScore(20);
            }
            if(Input.GetKeyDown(key) && active == true)
            {
                AddScore();
                Destroy(note);
            }
            
            
            if(score <= 0)
            {
                score = 0;
            }
        } 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if(col.gameObject.tag == "Note")
        {
            note = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        active = false;
    }

    void AddScore()
    {
        score += 100;
    }
    
    public static void LowerScore(int lowScore)
    {
        score -= lowScore;
    }

    public static int getScore()
    {
        return score;
    }

    IEnumerator Pressed()
    {
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.color = old;
    }
}
