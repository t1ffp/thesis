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


        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Pickable"))
            {
                pickUpTxt.SetActive(true);
            }
            else
            {
                pickUpTxt.SetActive(false);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            TryPickup();
            pickUpTxt.SetActive(false);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Drop();
        }
    }

    private void TryPickup()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Pickable"))
            {
                Pickup(hit.collider.gameObject);
            }
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

        heldObject.transform.SetParent(holdParent);
        heldObject.GetComponent<Collider>().enabled = false;
        heldObject.transform.localPosition = Vector3.zero;
    }

    public void Drop()
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
