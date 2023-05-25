using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExitButton : MonoBehaviour
{
    public void QuitGame()
    {
        // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
