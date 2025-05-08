using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDamage : MonoBehaviour
{
    public AudioSource heartBeat;
    public AudioSource beeping;

    public GameObject lightTower;
    private Animator towerAnim;

    public Player playerHP;
    private float damageCooldown = 3f;
    private float lastDamageTime = 0f;
    private bool isDead;

    private bool detected = false;

    private void Awake()
    {
        towerAnim = lightTower.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            detected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            detected = false;
        }
    }

    private void Update()
    {
        if (detected)
        {
            if (!heartBeat.isPlaying && !beeping.isPlaying)
            {
                heartBeat.Play();
                beeping.Play();
            }

            DealDamage(20);
        }
        else
        {
            towerAnim.speed = 1f;
            heartBeat.Stop();
            beeping.Stop();
        }
    }

    public void DealDamage(int damage)
    {
        if (Time.time - lastDamageTime < damageCooldown) return;

        //Update the last damage time
        lastDamageTime = Time.time;

        if (isDead) return;

        playerHP.currentHealth -= damage;

        if (playerHP.currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        if (isDead) return;

        isDead = true;
    }
}
