using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{
        bool flag = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !flag)
        {
            collision.gameObject.GetComponent<PlayerController>().StartCoroutine(collision.gameObject.GetComponent<PlayerController>().sasCoroutineEnd());
            flag = true;
        }

    }
}
