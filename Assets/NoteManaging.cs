using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManaging : MonoBehaviour
{
    public GameObject[] notes;
    int noteNum;
    static int maxScore;
    static double minScore;

    void Start()
    {
        noteNum = 0;
        maxScore = 0;
    }

    void Awake()
    {
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
}
