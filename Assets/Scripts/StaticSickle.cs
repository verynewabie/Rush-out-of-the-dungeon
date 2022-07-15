using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSickle : MonoBehaviour
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
            && other.GetType().ToString()== "UnityEngine.PolygonCollider2D")
        {
            SickleUI.currentSickleQuantity += 1;
            SoundsManager.PlayPickCoin();
            Destroy(gameObject);
        }
    }
}
