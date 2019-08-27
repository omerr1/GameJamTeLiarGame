using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private float interactDistance = 3f;

    [SerializeField] private Transform cursor;
    [SerializeField] private float resizeCursor;

    private bool isGrabbed = false;
    private Rigidbody grabbedObj;

    void Update()
    {
        CheckIfInteractable();

        //to remove any forces from our object while holding it
        if (isGrabbed) StopItem();
    }

    private void CheckIfInteractable()
    {
        
        RaycastHit hitInfo;

        //Will check if we looking at some object in interactDistance
        if (Physics.Raycast(transform.position,transform.forward,out hitInfo, interactDistance))
        {
            //Every object with we can interact with need to have InteractiveObj component
            InteractiveObj interactive = hitInfo.collider.gameObject.GetComponent<InteractiveObj>();

            if(interactive != null)
            {
                //Show to the player that he is looking at an interactive object
                if(cursor != null) cursor.localScale = new Vector3(resizeCursor + 1f, resizeCursor + 1f);

                //Check if we can grab it
                if (interactive.isGrabbable)
                {
                    
                    if (!isGrabbed && Input.GetKeyDown(interactKey))
                    {
                        PickUpItem(hitInfo.collider.gameObject.GetComponent<Rigidbody>());
                    }
                    else if (isGrabbed && Input.GetKeyUp(interactKey))
                    {
                        DropItem();
                    }
                }

                if(Input.GetKeyDown(interactKey)) interactive.Interac();

            }else if (isGrabbed)
            {
                //If we can't see the grabbable object(and we see another interactive object) but we still hold it we need to drop it
                DropItem();
            }

        }else if (isGrabbed)
        {
            //If we can't see the grabbable object(and we see the non-interactive object) but we still hold it we need to drop it
            DropItem();
        }
        else
        {
            //If we don't see any interactive objects 
            if (cursor != null) cursor.localScale = Vector3.one;
        }

    }

    private void PickUpItem(Rigidbody rb) {
        //Check if the game object has Rigidbody
        if (rb != null)
        {
            isGrabbed = true;
            grabbedObj = rb;
            StopItem(); 
            grabbedObj.useGravity = false; // to we can hold it
            grabbedObj.transform.SetParent(transform); // to follow out position
        }
    }
    private void DropItem() {
        isGrabbed = false;
        if(grabbedObj != null)
        {
            StopItem();
            //Set all vars back to normal
            grabbedObj.useGravity = true;
            grabbedObj.transform.parent = null; ;
        }
    }
    private void StopItem()
    {
        if (grabbedObj != null)
        {
            grabbedObj.velocity = Vector3.zero;
            grabbedObj.angularVelocity = Vector3.zero;
        }
    }
}
