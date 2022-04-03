using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIntroText : MonoBehaviour
{
    [SerializeField]private float Timer;

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            gameObject.active = false;
        }
    }
}
