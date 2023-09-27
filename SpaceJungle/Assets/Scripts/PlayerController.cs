using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float rotationSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    

    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * move * playerSpeed * Time.deltaTime);

        if (rotation != 0.0f)
        {
            //gameObject.transform.forward = move;
            transform.Rotate(Vector3.up, rotation * rotationSpeed);
        }        
    }

}
