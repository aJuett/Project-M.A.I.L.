using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static string JUMPLAYER = "Jump";

    public float speed;
    public float jumpHeight;
    public float jumpTime;
    bool hasJumped;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0);

        rb.AddForce(movement * speed);

        if (Input.GetButtonDown("Jump") && hasJumped == false)
        {
            hasJumped = true;
            rb.AddForce(Vector3.up * jumpHeight * 20);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(JUMPLAYER))
        {
            hasJumped = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
    }
}

