using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPickup : MonoBehaviour
{
    public float pickupRange = 2.0f;
    public Transform holdParent;
    private GameObject heldObject;
    public GameObject pickUpTxt;


    private void Start()
    {
        pickUpTxt.SetActive(false);
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        //Debug.DrawRay(ray.origin, ray.direction * pickupRange, Color.red, 1.0f);

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            // Check if the object is pickable (tag or component check)
            if (hit.collider.CompareTag("Pickable"))
            {
                pickUpTxt.SetActive(true);
            }
            else
            {
                pickUpTxt.SetActive(false);
            }
        }

        if (Input.GetMouseButtonDown(0)) // Mouse button pressed
        {
            TryPickup();
            pickUpTxt.SetActive(false);
        }
        else if (Input.GetMouseButtonUp(0)) // Mouse button released
        {
            Drop();
        }
    }

    private void TryPickup()
    {
        // Create a ray from the player's position in the direction they are facing
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        //Debug.DrawRay(ray.origin, ray.direction * pickupRange, Color.red, 1.0f);

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            // Check if the object is pickable (tag or component check)
            if (hit.collider.CompareTag("Pickable"))
            {
                Pickup(hit.collider.gameObject);
            }
        }
        else
        {
            //Debug.Log("No object detected within range.");
        }
    }

    private void Pickup(GameObject obj)
    {
        heldObject = obj;
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = true;
        }

        heldObject.transform.SetParent(holdParent); // Parent it to the hold object
        heldObject.GetComponent<Collider>().enabled = false; // Disable collider to avoid physics issues
        heldObject.transform.localPosition = Vector3.zero; // Reset position to center of parent
        heldObject.transform.localRotation = Quaternion.identity; // Reset rotation
    }

    private void Drop()
    {
        if (heldObject != null)
        {
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.isKinematic = false;
            }

            heldObject.transform.SetParent(null); // Unparent the object
            heldObject.GetComponent<Collider>().enabled = true; // Re-enable the collider
            heldObject = null; // Clear the held object reference
        }
    }
}
