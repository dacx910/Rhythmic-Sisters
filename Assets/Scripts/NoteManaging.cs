using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteManaging : MonoBehaviour
{
    public GameObject[] notes;
    int noteNum;
    static int maxScore;
    static double minScore;

    public string nextScene;

    static float speed;

    Rigidbody2D rb;

    void Start()
    {
        noteNum = 0;
        maxScore = 0;

        speed = Note.getSpeed();

        Debug.Log(speed);

        rb.velocity = new Vector2(0, -speed);
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        notes = GameObject.FindGameObjectsWithTag("Note");
        for (int i = 0; i < notes.Length; i++)
        {
            noteNum++;
        }


        maxScore = noteNum * 100;
        minScore = maxScore * .8f;
    }

    void Update()
    {
        
    }

    public static int getMaxScore()
    {
        return maxScore;
    }

    public static double getMinScore()
    {
        return minScore;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Test");
        if(col.gameObject.tag == "Activator")
        {   
            Debug.Log("ACTIVATOR");
            if (Activator.getScore() > minScore)
            {
                SceneManager.LoadScene(nextScene);   
            }
            else
            {
                SceneManager.LoadScene("LoseScreen");
            }
        }
    }
}
