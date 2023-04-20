using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBar : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {   
        if(col.gameObject.tag == "Note")
        {
            Activator.LowerScore(50);
            Destroy(col.gameObject);
        }     
    }
}
