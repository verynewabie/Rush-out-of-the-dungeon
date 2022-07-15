using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("��ҵ�λ��")]
    public Transform target;
    [Tooltip("ѡ�����Բ�ֵ��ϵ��")]
    public float smoothing;
    [Tooltip("����ƶ������±߽�")]
    public Vector2 minPos;
    [Tooltip("����ƶ������ϱ߽�")]
    public Vector2 maxPos;
    void Start()
    {
        
    }

    void LateUpdate()//����������
    {
        if (target != null)//target����ҵ�transform
        {
            if (target.position != transform.position) 
            {
                Vector3 targetPos = target.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);//�������߽�
                targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
                //��ֵ
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }

    public void setCameraLimit(Vector2 mi,Vector2 ma)
    {
        minPos = mi;
        maxPos = ma;
    }
}
