// The following are namespaces
// using is the keyword to import namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// custom namespace import
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    // doesn't have to be public since this 
    // will not be accessed from the inspector
    private Rigidbody rb;
    private int totalPickUps = 10;
    private int count;
    private float movementX;
    private float movementY; 

    // Start is called before the first frame updatejj
    void Start()
    {
        // Update (runs before rendering a frame)
        // FixedUpdate (runs before physics calculations)
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); 

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= totalPickUps)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);         
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }
}
