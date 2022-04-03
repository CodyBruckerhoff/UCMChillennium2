using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Food")]
public class Item : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite sprite;

    public Item comboItem;
    public float TimeAdded;
    public int Score;
    public float speedIncrease = 1;
}
