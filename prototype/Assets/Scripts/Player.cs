using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;

    //public HealthBar healthBar;

    public Collider playerCollider;
    public GameObject deadText;

    private bool isDead = false;

    public Image damageOverlay; 
    public float fadeSpeed = 5f;
    public Color overlayColor = new Color(1f, 0f, 0f, 0.5f);

    public float regenRate = 5f;
    public float regenDelay = 3f;
    private float timeSinceLastDamage = 0f;

    private void Start()
    {
        currentHealth = maxHealth;
        //healthBar.SetMaxhealth(maxHealth);
    }

    void Update()
    {
        //healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }

        UpdateDamageOverlay();

        timeSinceLastDamage += Time.deltaTime;

        if (currentHealth < maxHealth && timeSinceLastDamage >= regenDelay)
        {
            currentHealth += regenRate * Time.deltaTime;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        }
    }

    void UpdateDamageOverlay()
    {
        float healthPercent = (float)currentHealth / maxHealth;
        float targetAlpha = 1f - healthPercent; 

        Color currentColor = damageOverlay.color;
        Color targetColor = new Color(overlayColor.r, overlayColor.g, overlayColor.b, targetAlpha * overlayColor.a);
        damageOverlay.color = Color.Lerp(currentColor, targetColor, Time.deltaTime * fadeSpeed);
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;

        timeSinceLastDamage = 0f;
        currentHealth -= Mathf.RoundToInt(amount);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        //Debug.Log("Health: " + currentHealth);
    }


    private void Die()
    {
        isDead = true;
        playerCollider.enabled = false;
        deadText.SetActive(true);
        //Debug.Log("Player died.");
    }

}
