using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    
    private bool isIn;
    // Start is called before the first frame update
    public bool getIsIn() 
    {
        return isIn;
    }
    public void setIsIn(bool value) 
    {
        isIn = value;
    }
    void Start()
    {
        isIn = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //print("Am In");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isIn = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isIn = false;
    }

}
