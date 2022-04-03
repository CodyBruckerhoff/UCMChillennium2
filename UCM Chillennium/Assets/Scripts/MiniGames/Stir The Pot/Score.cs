using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject liquid;
    public static float speedup = 0;
    public static bool addScore = false;
    public static int potScore = 0;
    //Audio sources
    public AudioSource randomSound;
    public AudioClip[] audioSources;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "spoon" && addScore == true)
        {
            scoreCalculation.totalscore += 2;
            potScore += 2;
            addScore = false;
            speedup += .03f;

            //Play sound on score
            randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
            randomSound.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        liquid.transform.Rotate(0, 0, 25 * Time.deltaTime + speedup);
        if(speedup >= 0)
        {
            speedup -= .00001f;
        }
    }
}
