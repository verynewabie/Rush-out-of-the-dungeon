using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Tooltip("移动速度")]
    public float speed;
    [Tooltip("停留时间")]
    public float waitTime;
    [Tooltip("目标位置")]
    public Transform[] targetPos;
    private int i = 1;
    private Transform playerParent;
    private float time;
    void Start()
    {
        time = waitTime;
        playerParent = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,targetPos[i].position,speed*Time.deltaTime);
        if (Vector2.Distance(transform.position, targetPos[i].position) < 0.1f)
        {
            if (time < 0.0f)
            {
                i ^= 1;
                time = waitTime;
            }
            else
            {
                time -= Time.deltaTime;
            }
        } 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            other.gameObject.transform.parent = gameObject.transform;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            other.gameObject.transform.parent = playerParent;
        }
    }
}
