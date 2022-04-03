using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoon : MonoBehaviour
{
    public Vector2 zero;
    private Vector2 previouspos;
    private bool setcenter = true;
    private void Start()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (setcenter)
        {
            previouspos = zero;
            setcenter = false;
        }
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(zero, mousepos);
        if(distance < 4.2)
        {
            previouspos = mousepos;
            if (Cursor.visible)
            {
                Cursor.visible = false;
            }
        }
        else
        {
            mousepos = previouspos;
            Cursor.visible = true;
        }
        transform.position = mousepos;
    }
}
