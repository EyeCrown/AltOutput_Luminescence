using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    private AudioSource m_audioSource;
    [SerializeField] private AudioClip m_audioClip;
    [SerializeField] bool isLooping;
    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        if (m_audioClip != null )
            m_audioSource.clip = m_audioClip;
        if (isLooping)
            m_audioSource.loop = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_audioSource != null)
            m_audioSource.Play();
    }

}
