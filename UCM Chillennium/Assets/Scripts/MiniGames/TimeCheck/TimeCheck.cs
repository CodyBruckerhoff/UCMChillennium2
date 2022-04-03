using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCheck : MonoBehaviour
{
    //Audio sources
    public AudioSource randomSound;
    public AudioClip[] audioSources;
    private bool isPressed;
    private bool isIncreasing;
    public static int iteration;
    private bool isreset = false;
    public static int timeScore;
    private Slider slider;
    private RectTransform rectTransform;
    private BoxCollider2D knobCollider;
    [SerializeField]private CollisionCheck check;
    public GameObject[] sweetSpots;
    private GameObject successBar;
    private float sliderSpeed = .5f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        knobCollider = GameObject.Find("Handle").GetComponent<BoxCollider2D>();
        successBar = sweetSpots[Random.Range(0, sweetSpots.Length)];
        rectTransform = successBar.GetComponent<RectTransform>();
        successBar.SetActive(true);
        //rectTransform.transform.Translate(new Vector3(Random.Range(-.6f, .6f), 0, 0));
        rectTransform.localPosition = new Vector3(Random.Range(-126f, 126f), 0, 0);
        //Random.Range(-.8f, .8f), 0, 0, Space.World
        //rectTransform.localScale = new Vector3(Random.Range(0.2f, 1f), 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHit();
    }


    private IEnumerator SlideMove() 
    {
        if (isIncreasing)
        {
            slider.value += Time.deltaTime*sliderSpeed;
            if (slider.value == slider.maxValue)
            {
                isIncreasing = false;
            }
        }
        else
        {
            slider.value -= Time.deltaTime*sliderSpeed;
            if (slider.value == slider.minValue)
            {
                isIncreasing = true;
                yield return null;
            }
        }
    }

    private void PlayerHit() 
    {
        if (!isreset && iteration < 5) 
        {
            StartCoroutine(SlideMove());
            if (Input.GetMouseButtonDown(0))
            {
                sliderSpeed += .2f;
                Debug.Log(check.name);
                Debug.Log(iteration);
                //Play sound on score
                randomSound.clip = audioSources[0];
                randomSound.Play();
                StopCoroutine(SlideMove());
                isreset = true;
                if (check.getIsIn()) 
                {
                    scoreCalculation.totalscore += 30;
                    timeScore += 30;
                    
                }
                else
                {
                    //Play sound on score
                    randomSound.clip = audioSources[1];
                    randomSound.Play();
                }
                successBar.SetActive(false);

            }
        }
        else if (isreset) 
        {
            successBar = sweetSpots[Random.Range(0, sweetSpots.Length)];
            rectTransform = successBar.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(Random.Range(-126f, 126f), 0, 0);
            successBar.SetActive(true);
            check = successBar.GetComponent<CollisionCheck>();
            foreach (var i in sweetSpots) 
            {
                i.GetComponent<CollisionCheck>().setIsIn(false);
            }
            iteration += 1;
            isreset = false;
            
            slider.value = 0;
            //rectTransform.transform.Translate(new Vector3(Random.Range(-.6f, .6f), 0, 0));



            //rectTransform.localScale = new Vector3(Random.Range(0.2f, 1f), 1, 0);
        }
        else
        {
            SceneManager.LoadScene(5);
        }
        
    }
}
