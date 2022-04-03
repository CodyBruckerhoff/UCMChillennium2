using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemDisplay : MonoBehaviour
{
    public Item item;
    public string nameText;
    public string descriptionText;
    public SpriteRenderer SpriteRenderer;
    public int points;

    //Floating values
    [SerializeField] private float timer = 0f;
    [SerializeField] private bool rising;
    private float direction = 1f;

    private void Start()
    {
        nameText = item.itemName;
        descriptionText = item.description;
        SpriteRenderer.sprite = item.sprite;
        points = item.Score;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 4)
        {
            rising = !rising;
            direction *= -1f;
            timer = 0;
        }
        if (rising)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.001f);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.001f);
        }

    }
}
