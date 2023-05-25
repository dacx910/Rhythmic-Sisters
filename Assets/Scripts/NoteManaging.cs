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

    static float speed = Note.getSpeed();

    Rigidbody2D rb;

    void Start()
    {
        noteNum = 0;
        maxScore = 0;

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

    public static int getMaxScore()
    {
        return maxScore;
    }

    public static double getMinScore()
    {
        return minScore;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Activator")
        {   
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
