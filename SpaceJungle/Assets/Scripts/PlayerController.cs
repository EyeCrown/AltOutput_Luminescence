using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float rotationSpeed = 2.0f;

    // Camera
    [SerializeField] private Camera cam;
    private float rotAroundX, rotAroundY;
    private float minRotationX = -10.0f;
    private float maxRotationX = 15.0f;
    //private float minRotationY;
    //private float maxRotationY;
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

        cam = transform.GetChild(0).GetComponent<Camera>();
        rotAroundX = transform.eulerAngles.x;
        rotAroundY = transform.eulerAngles.y;

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
            // Get player's movements 
            Vector3 movements = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")*(-1)).normalized;
            
            rotAroundX += Input.GetAxis("VerticalCamera") * rotationSpeed; // rotate around x-axis
            rotAroundY += Input.GetAxis("HorizontalCamera") * rotationSpeed; // rotate around y-axis

            rotAroundX = Mathf.Clamp(rotAroundX, minRotationX, maxRotationX);
            //rotAroundY = Mathf.Clamp(rotAroundY, minRotationY, maxRotationY);

            transform.Translate(playerSpeed * Time.deltaTime * movements);

            transform.rotation = Quaternion.Euler(0, rotAroundY, 0); 
            cam.transform.rotation = Quaternion.Euler(-rotAroundX, rotAroundY, 0); 
            
        }
    }

}