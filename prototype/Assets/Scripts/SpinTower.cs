using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinTower : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 15 * Time.deltaTime, 0);
    }
}
