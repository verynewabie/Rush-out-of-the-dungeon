using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public GameObject[] gos;
    public float delayTime;

    private bool canOpen;
    private bool isOpened;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (canOpen && !isOpened)
            {
                anim.SetTrigger("Opening");
                isOpened = true;
                Invoke("GenGift", delayTime);
            }
        }
    }

    void GenGift()
    {
        Vector3 pos = transform.position;
        Instantiate(gos[Random.Range(0, gos.Length)], pos, Quaternion.identity);
        
        Destroy(gameObject,3);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = false;
        }
    }
}
