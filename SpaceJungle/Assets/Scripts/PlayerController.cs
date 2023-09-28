using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float rotationSpeed = 2.0f;
    bool canMove = false;

    // CANVAS
    [Header("Sas opening Info")]
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject topBorder;
    public int topBorderMax = 125;
    public float speedOpening = 0.5f;

    /// <summary>
    /// Open sas
    /// </summary>
    /// <returns></returns>
    IEnumerator sasCoroutine()
    {
        float dist = 0;
        while (dist < 0.22f)
        {
            topBorder.GetComponent<RectTransform>().position += new Vector3(0,
                 Time.deltaTime * speedOpening, 0);
            dist += Time.deltaTime * speedOpening;

            yield return null;
        };
        yield return new WaitForSeconds(.5f);
        while (dist < 0.45f)
        {
            topBorder.GetComponent<RectTransform>().position += new Vector3(0,
                 Time.deltaTime * speedOpening/2, 0);
            dist += Time.deltaTime * speedOpening/2;

            yield return null;
        };
        canMove = true;
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Init sas opening
        if (canvas == null)
            Debug.Log("error : no canvas for player");
        else
        {
            StartCoroutine(sasCoroutine());
            
        }
    }



    void Update()
    {
        if (canMove)
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

}