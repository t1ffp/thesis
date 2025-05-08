using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpotlightDetect2 : MonoBehaviour
{
    public Transform player;
    public float viewDistance = 20f;
    public float damagePerSecond = 20f;
    public LayerMask obstructionMask;

    private Light spotLight;
    private bool playerInSight;

    public Animator spotlightAnim;
    //public Player playerHealth;

    public AudioSource heartBeat;
    public AudioSource beeping;

    void Start()
    {
        spotLight = GetComponent<Light>();
        spotlightAnim = GetComponentInParent<Animator>();
        //playerHealth = GetComponent<Player>();
    }

    void Update()
    {
        bool playerSpotted = false;

        Vector3 dirToPlayer = player.position - transform.position;
        float angleToPlayer = Vector3.Angle(transform.forward, dirToPlayer);

        if (dirToPlayer.magnitude <= viewDistance && angleToPlayer < spotLight.spotAngle / 2f)
        {
            Ray ray = new Ray(transform.position, dirToPlayer.normalized);
            if (Physics.Raycast(ray, out RaycastHit hit, viewDistance, ~obstructionMask))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    playerSpotted = true;
                    //Debug.Log("hit");
                    hit.collider.GetComponent<Player>()?.TakeDamage(damagePerSecond * Time.deltaTime);
                }
            }
        }

        if (playerSpotted)
        {
            //Debug.Log("in sight");
            spotlightAnim.enabled = false;
            //playerHealth.TakeDamage(damagePerSecond * Time.deltaTime);

            if (!heartBeat.isPlaying && !beeping.isPlaying)
            {
                heartBeat.Play();
                beeping.Play();
            }
        }
        else
        {
            spotlightAnim.enabled = true;
            heartBeat.Stop();
            beeping.Stop();
        }
    }

}
