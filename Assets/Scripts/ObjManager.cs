using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    public GameObject[] obj;
    void Start()
    {
        for(int i = 0; i < obj.Length; i++)
        {
            DontDestroyOnLoad(obj[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
