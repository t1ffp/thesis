using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightMouse : MonoBehaviour
{
    public Camera sideCamera;
    public float spotlightHeight = 10f;
    public LayerMask groundMask;

    void Update()
    {
        Ray ray = sideCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundMask))
        {
            Vector3 target = hit.point;

            // Place spotlight directly above the hit point
            Vector3 spotlightPos = new Vector3(target.x, spotlightHeight, target.z);
            transform.position = spotlightPos;

            // Make spotlight look straight down
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}
