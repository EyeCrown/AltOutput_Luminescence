using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    float timer = 0.0f;
    bool flagSound;

    void Start()
    {
        flagSound = false;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!flagSound)
            timer += Time.deltaTime;
        if (timer >= 10.0f)
        {
            m_AudioSource.Play();
            timer = 0.0f;
            flagSound = true;
        }
    }
}
