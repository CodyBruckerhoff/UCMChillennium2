using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    public static ItemCollection instance;
    public List<Item> collection = new List<Item>();

    [SerializeField] private AudioSource pickup;
    [SerializeField] private float speedTimer;
    [SerializeField] private bool countDown = false;
    [SerializeField] private Item tempItem;

    private float tempSpeed;

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
        if (countDown)
        {
            time();
        }
        else
        {
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Item")
        {
            ItemDisplay temp = collision.gameObject.GetComponent<ItemDisplay>();
            collection.Add(temp.item);
            Timer.instance.timeRemaining += temp.item.TimeAdded;
            pickup.Play();
            tempItem = temp.item;
            if (temp.item.speedIncrease != 1)
            {
                tempSpeed = CharacterMovement.instance.speed;
                countDown = true;
                MovementIncrease();
            }
            Timer.instance.timeRemaining += tempItem.TimeAdded;
            Destroy(collision.gameObject);
        }
    }

    private void MovementIncrease()
    {
        if (speedTimer > 0 && countDown)
        {
            countDown = true;
            CharacterMovement.instance.speed *= tempItem.speedIncrease;
        }
        else if (speedTimer < 0)
        {
            Debug.Log("Slow down");
            CharacterMovement.instance.speed =  tempSpeed;
        }
    }

    private void time()
    {
        if (speedTimer > 0 && countDown)
        {
            speedTimer -= Time.deltaTime;
        }
        else
        {
            MovementIncrease();
            countDown = false;
        }
    }
}
