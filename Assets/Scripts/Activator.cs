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
        if(createMode)
        {
            if(Input.GetKeyDown(key))
            {
                Instantiate(n, transform.position, Quaternion.identity);
            }

            
        }
        else
        {
            if(Input.GetKeyDown(key)) // When an activation key is pressed, the activator will change its color to black for 0.05 seconds.
            {
                StartCoroutine(Pressed());
            }
            
            //Active is set to true when a note hits an activator.

            if(Input.GetKeyDown(key) && active) // If the given key is down and a note is in the activator's collision box, AddScore() and Destroy the note.
            {
                Destroy(note);
                AddScore();
                active = false;
            }
            else if(Input.GetKeyDown(key) && !active) // If the given key is down and a note is not in an activator's collison box, 20 points will be deducted.
            {
                LowerScore(20);
            }
            
            
            if(score <= 0) //Used to wrap the code to zero if it hits or goes under 0.
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
