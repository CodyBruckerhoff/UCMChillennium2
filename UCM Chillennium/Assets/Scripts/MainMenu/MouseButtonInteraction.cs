using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseButtonInteraction : MonoBehaviour
{
    [SerializeField] private GameObject graphic;
    public bool isStart;
    void OnMouseOver()
    {
        graphic.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {
            if (isStart)
            {
                SceneManager.LoadScene(1, LoadSceneMode.Single);
                scoreCalculation.totalscore = 0;
            }
            else
            {
                Application.Quit();
            }
        }
    }

    private void OnMouseExit()
    {
        graphic.SetActive(false);
    }
}
