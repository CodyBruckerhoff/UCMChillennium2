using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    //public TextMeshPro timerText;
    public Text timerText;
    public static Timer instance;
    [SerializeField] private scoreCalculation scoreCalculation;
    private bool callOnce = true;
    public AudioSource theme;

    [SerializeField] private string sceneName;


    private void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {

        timerText = GameObject.FindGameObjectWithTag("TimerText").GetComponent<Text>();
        if (timeRemaining > 3)
        {
            timeRemaining -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{00}", seconds);
        }
        else if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{00}", seconds);
            theme.volume -= .001f;
        }
        else if (timeRemaining <= 0 && callOnce)
        {
            scoreCalculation.CalculateScore(ItemCollection.instance.collection);
            sceneStorage.instance.LoadScene(sceneName);
            /*timerText.text = "0:00";
            callOnce = false;*/
        }
    }

}
