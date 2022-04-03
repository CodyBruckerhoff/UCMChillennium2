using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text triesleft;

    // Update is called once per frame
    void Update()
    {
        int remaining = 5 - TimeCheck.iteration;
        triesleft.text = remaining.ToString();
    }
}
