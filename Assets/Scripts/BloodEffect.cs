using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    [Tooltip("���ٵ�ʱ��")]
    public float timeToDestroy;
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        
    }
}
