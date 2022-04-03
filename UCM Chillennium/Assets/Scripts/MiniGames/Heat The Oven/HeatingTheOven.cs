using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatingTheOven : MonoBehaviour
{
    [SerializeField] private Slider slider;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        slider.value += 0.001f;
    }
}
