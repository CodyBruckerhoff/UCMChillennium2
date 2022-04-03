using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        scoreCalculation.totalscore = 0;
        HeatTheOven.areaProgress = 0;
        TimeCheck.iteration = 0;
    }
}
