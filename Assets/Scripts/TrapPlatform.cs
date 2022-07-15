using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    private Animator anime;
    private BoxCollider2D box;
    void Start()
    {
        anime = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") &&
           collision.GetType().ToString()== "UnityEngine.BoxCollider2D")
        {
            anime.SetTrigger("Collapse");
        }
    }
    void Disbale()
    {
        box.enabled = false;
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
