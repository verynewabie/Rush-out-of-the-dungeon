using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XueBao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            
            if (PlayerHealth.health > 5) { PlayerHealth.health = 10; }
            else { PlayerHealth.health += 5; Debug.Log("¼Ó5µÎÑª"); }
            HealthBar.nowHealth = Mathf.Max(PlayerHealth.health, 0);
            SoundsManager.PlayPickCoin();
            Destroy(gameObject);
        }
    }
}
