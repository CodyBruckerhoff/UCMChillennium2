using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnInvis : MonoBehaviour
{
    public GameObject soupPieces;
    public GameObject splashes;
    public SpriteRenderer[] renderers;
    public SpriteRenderer[] renderersplash;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        renderers = soupPieces.GetComponentsInChildren<SpriteRenderer>();
        foreach(var i in renderers)
        {
            i.color = new Color(1,1,1,1);
        }
        renderersplash = splashes.GetComponentsInChildren<SpriteRenderer>();
        foreach (var i in renderersplash)
        {
            i.color = new Color(1, 1, 1, 1);
        }
        
    }
}
