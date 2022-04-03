using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionLoadScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.active = false;
            sceneStorage.instance.LoadScene(sceneName);
        }
    }
}
