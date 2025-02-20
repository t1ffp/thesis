using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectTrigger : MonoBehaviour
{
    public Transform targetPosition;
    public Vector3 targetRotation;

    public MonoBehaviour pickUp;

    public float moveDuration = 3f;

    private bool isMoving = false;
    private float timeElapsed = 0f;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private GameObject objectToMove;
    private Rigidbody rb;

    public AudioSource placedSuccess;
    public AudioClip yaySound;

    //public string objectTag;

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Pickable"))
        {
            
            objectToMove = other.gameObject;
            rb = objectToMove.GetComponent<Rigidbody>();

            initialPosition = objectToMove.transform.position;
            initialRotation = objectToMove.transform.rotation;

            isMoving = true;
            timeElapsed = 0f;

            if(placedSuccess != null && yaySound != null)
            {
                placedSuccess.PlayOneShot(yaySound);
            }
        }
    }

    private void Update()
    {

        if (isMoving && objectToMove != null)
        {
            pickUp.GetComponent<ObjPickup>().Drop();

            timeElapsed += Time.deltaTime;

            float t = timeElapsed / moveDuration;
            t = Mathf.Clamp01(t);

            objectToMove.transform.position = Vector3.Lerp(initialPosition, targetPosition.position, t);
            objectToMove.transform.rotation = Quaternion.Slerp(initialRotation, Quaternion.Euler(targetRotation), t);


            if (t >= 1f)
            {
                
                objectToMove.tag = "Placed";

                if (rb != null)
                {
                    rb.isKinematic = true;
                }

                isMoving = false;
            }
        }
    }
}
