using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatformProducer : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("���ʱ��")]
    public float gapTime;
    [Tooltip("Ԥ����")]
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
    void Make()//����ƽ̨������
    {
        Instantiate(obj,this.transform.position,Quaternion.identity, transform);
        al = false;
    }
}
