using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public Collider playerCollider;
    public GameObject deadText;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxhealth(maxHealth);
    }

    void Update()
    {
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            playerCollider.enabled = false;

            deadText.SetActive(true);

        }
    }

}
