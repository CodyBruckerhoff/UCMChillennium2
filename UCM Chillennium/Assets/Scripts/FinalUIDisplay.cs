using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalUIDisplay : MonoBehaviour
{

    [SerializeField] private Text[] texts;
    [SerializeField] private GameObject buttons;

    [SerializeField] private float timer = 3f;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        texts[1].text = "COLLECTION: " + scoreCalculation.score;
        texts[2].text = "HEATING: " + EndScoring.ovenScore;
        texts[3].text = "STIRRING: " + Score.potScore;
        texts[4].text = "GARNISH: " + TimeCheck.timeScore;
        texts[5].text = "TOTAL: " + scoreCalculation.totalscore;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && index < texts.Length)
        {
            texts[index].gameObject.active = true;
            index++;
            timer = 3f;
        }
        else if (timer <= 0 && index == texts.Length)
        {
            buttons.active = true;
        }
    }
}
