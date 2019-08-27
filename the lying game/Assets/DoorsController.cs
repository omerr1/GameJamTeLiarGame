using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsController : MonoBehaviour
{
    
    public bool isOpen { get; protected set; }

    private bool isMoving = false;
    [SerializeField] private float movementLength = 0.5f;
    [SerializeField] private float speed = .05f;
    [SerializeField] private Vector3 openDirection;

    private float tempLenght = 0;

    private Rigidbody rigidbody;

    private void Awake()
    {
        isOpen = false;
        rigidbody = GetComponent<Rigidbody>();
        openDirection.Normalize();
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            float dir = 0f;

            if (isOpen)
                dir = -1f;
            else
                dir = 1f;

            tempLenght += speed * dir * Time.deltaTime;

            transform.Translate(openDirection * speed * dir * Time.deltaTime, Space.World);
            

            if (Mathf.Abs(tempLenght) >= movementLength)
            {
                tempLenght = 0f;
                isMoving = false;
                isOpen = !isOpen;
            }
        }
    }

    public virtual void Open()
    {
        if (isOpen) return;

        isMoving = true;
        Debug.Log("Open");
    }

    public virtual void Close()
    {
        if (!isOpen) return;

        isMoving = true;

        Debug.Log("Close");
    }
}
