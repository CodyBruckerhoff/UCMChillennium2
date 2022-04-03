using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour
{
    public bool shouldAdd;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "spoon")
        {
            Score.addScore = shouldAdd;
        }
    }
}
