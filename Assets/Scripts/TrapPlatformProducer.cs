using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatformProducer : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("间隔时间")]
    public float gapTime;
    [Tooltip("预制体")]
    public GameObject obj;
    private bool al;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.childCount == 0 && al == false)
        {
            al = true;
            Invoke("Make", gapTime);
        }
    }
    void Make()//陷阱平台的设置
    {
        Instantiate(obj,this.transform.position,Quaternion.identity, transform);
        al = false;
    }
}
