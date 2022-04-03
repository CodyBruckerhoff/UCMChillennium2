using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{

    public void pressQuit() 
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
