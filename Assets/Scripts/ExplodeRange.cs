using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeRange : MonoBehaviour
{
    public int damage;
    public float destroyTime;

    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")
            && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            other.GetComponent<Enemy>().Hurt(damage);
        }
        if (other.CompareTag("Player")
           && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"
           )
        {
            playerHealth.DamagePlayer(damage);
        }
    }
}
