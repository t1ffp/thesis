using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    public GameObject lightningOne;
    public GameObject lightningTwo;
    public GameObject lightningThree;

    public GameObject audioOne;
    public GameObject audioTwo;
    public GameObject audioThree;

    // Start is called before the first frame update
    void Start()
    {
        lightningOne.SetActive(false);
        lightningTwo.SetActive(false);
        lightningThree.SetActive(false);

        audioOne.SetActive(false);
        audioTwo.SetActive(false);
        audioThree.SetActive(false);

        Invoke("CallLightning", 10.5f);
    }

    void CallLightning()
    {
        int r = Random.Range(0, 3);

        if (r == 0)
        {
            lightningOne.SetActive(true);
            Invoke("EndLightning", 0.125f);
            Invoke("CallThunder", 0.395f);
        }
        else if (r == 1)
        {
            lightningTwo.SetActive(true);
            Invoke("EndLightning", 0.105f);
            Invoke("CallThunder", 0.175f);
        }
        else
        {
            lightningThree.SetActive(true);
            Invoke("EndLightning", 0.75f);
            CallThunder();
        }

    }

    void EndLightning()
    {
        lightningOne.SetActive(false);
        lightningTwo.SetActive(false);
        lightningThree.SetActive(false);

        float rand = Random.Range(20.5f, 80.2f);
        Invoke("CallLightning", rand);
    }

    void CallThunder()
    {
        int r = Random.Range(0, 3);

        if (r == 0)
        {
            audioOne.SetActive(true);
            Invoke("EndThunder", 20f);
        }
        else if (r == 1)
        {
            audioTwo.SetActive(true);
            Invoke("EndThunder", 20f);
        }
        else
        {
            audioThree.SetActive(true);
            Invoke("EndThunder", 20f);
        }

    }

    void EndThunder()
    {
        audioOne.SetActive(false);
        audioTwo.SetActive(false);
        audioThree.SetActive(false);
    }
}
