using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveTrigger : MonoBehaviour
{
    [SerializeField] bool enter;
    [SerializeField] Animator creatureAnimator;
    [SerializeField] AudioSource soundCreature;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().isInCave = enter;
            if (!enter)
            {
                creatureAnimator.SetTrigger("StartUp");
                soundCreature.Play();
            }
        }
    }
}
