using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PP_Text : MonoBehaviour
{
    public string stringName;
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = Activator.getScore().ToString();   
    }
}
