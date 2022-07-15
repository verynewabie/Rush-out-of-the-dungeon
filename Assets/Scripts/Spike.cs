using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [Tooltip("…À∫¶÷µ")]
    public int damage;
    private PlayerHealth playerHealth;
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&other.GetType().ToString()== "UnityEngine.CapsuleCollider2D")
        {
            playerHealth.DamagePlayer(damage);
        }
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().Hurt(other.GetComponent<Enemy>().health, false);
        }
    }

}
