using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float spinSpeed = 1f;
    public float jumpForce = 1f;

    bool isGrounded = true;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                rb.AddForce(new Vector3(0, 1, 0) * jumpForce);
            }
        }
        float rotationVar = Input.GetAxis("Horizontal");
        float forward = Input.GetAxis("Vertical");

        Vector3 moveVector = forward * transform.forward;
        Vector3 dirVector = new Vector3(0, rotationVar, 0);

        transform.Rotate(dirVector * spinSpeed);
        transform.position = Vector3.Lerp(this.transform.position, this.transform.position + moveVector, Time.deltaTime * moveSpeed);






    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Entered");
        if (col.transform.tag == "Ground")
        {
            Debug.Log("Entered2");
            isGrounded = true;
        }
    }
}
