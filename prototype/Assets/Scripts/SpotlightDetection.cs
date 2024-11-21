using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class SpotlightDetection : MonoBehaviour
{
    public Transform player;
    public Light spotlight;

    public AudioSource heartBeat;
    public AudioSource beeping;
    public Animator towerAnim;

    public Player playerHP;
    private float damageCooldown = 3f;
    private float lastDamageTime = 0f;
    private bool isDead;

    void Update()
    {
        if (IsPlayerInSpotlight())
        {
            //Debug.Log("Player is in the spotlight!");
            towerAnim.speed = 0f;

            if(!heartBeat.isPlaying && !beeping.isPlaying)
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

    bool IsPlayerInSpotlight()
    {
        // Get spotlight properties
        Vector3 lightPosition = spotlight.transform.position;
        Vector3 lightDirection = spotlight.transform.forward;
        float spotAngle = spotlight.spotAngle;
        float range = spotlight.range;

        // Get direction to player
        Vector3 toPlayer = player.position - lightPosition;
        float distanceToPlayer = toPlayer.magnitude;

        // Check if the player is within the range
        if (distanceToPlayer > range) return false;

        // Check if the player is within the spotlight's angle
        float angleToPlayer = Vector3.Angle(lightDirection, toPlayer);
        if (angleToPlayer > spotAngle / 2) return false;

        // Check for obstacles between the spotlight and the player
        if (Physics.Raycast(lightPosition, toPlayer.normalized, out RaycastHit hit, distanceToPlayer))
        {
            if (hit.transform != player) return false; // Something else is blocking the light
        }

        // Player is in the spotlight
        return true;
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
