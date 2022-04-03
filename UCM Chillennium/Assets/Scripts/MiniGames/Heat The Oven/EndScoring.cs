using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScoring : MonoBehaviour
{
    public Timer timerForScene;
    public static int ovenScore = 0;
    private bool canScore = true;

    private void Update()
    {
        if(timerForScene.timeRemaining < 1 && canScore == true)
        {
            ovenScore = Mathf.RoundToInt(HeatTheOven.areaProgress * 100);
            scoreCalculation.totalscore += ovenScore;
            Debug.Log(ovenScore);
            canScore = false;
        }
    }
}
