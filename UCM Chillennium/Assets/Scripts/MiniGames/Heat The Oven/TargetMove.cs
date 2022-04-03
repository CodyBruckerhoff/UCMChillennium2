using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetMove : MonoBehaviour
{
    //Audio sources
    public AudioSource randomSound;
    public AudioClip[] audioSources;

    [SerializeField] private HeatTheOven script;
    private void OnTriggerStay2D(Collider2D collision)
    {
        script.isScoring = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        script.isScoring = false;
        //Play sound on score
        randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomSound.Play();
    }
}
