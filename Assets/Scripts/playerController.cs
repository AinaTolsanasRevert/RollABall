using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playerController : MonoBehaviour
{

    private Rigidbody rb;
    private int count;
    

    private float movementX;
    private float movementY;

    public float speed = 0;
    public TextMeshProUGUI countText;

    public GameObject winTextObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        //SetCountText();
    }
    void OnMove(InputValue movementValue)
    {
        // Function body
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
        {
    if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        //other.gameObject.SetActive(false);
        }

    void SetCountText()
        {
        countText.text = "Count:" + count.ToString();
    if (count >= 8)
        {
            winTextObject.SetActive(true); //gameObject.
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!!!";
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
        }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose";
        }
    }

    // Update is called once per frame
    //void Update()
    //{

    //}
}
