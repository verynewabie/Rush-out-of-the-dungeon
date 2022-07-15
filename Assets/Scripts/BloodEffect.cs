using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    [Tooltip("销毁的时间")]
    public float timeToDestroy;
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        
    }
}
