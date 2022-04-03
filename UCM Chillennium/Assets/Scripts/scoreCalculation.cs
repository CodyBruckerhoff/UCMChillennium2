using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreCalculation : MonoBehaviour
{
    public static int totalscore;
    public static int score;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void CalculateScore(List<Item> collection)
    {
        comboCalculation(collection);
        for (int i = 0; i < collection.Count; i++)
        {
            totalscore += collection[i].Score;
            score += collection[i].Score;
        }
        Debug.Log(score);
    }

    static void comboCalculation(List<Item> collection)
    {
        for (int i = 0; i < collection.Count; i++)
        {
            for (int j = 1; j < collection.Count; j++)
            {
                if (collection[i].comboItem == collection[j])
                {
                    Debug.Log("You have a combo!");
                    totalscore += collection[i].Score * 2;
                    score += collection[i].Score * 2;
                    break;
                }
            }
        }
    }
}
