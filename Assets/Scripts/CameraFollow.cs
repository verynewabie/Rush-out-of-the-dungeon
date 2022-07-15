using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("玩家的位置")]
    public Transform target;
    [Tooltip("选择线性插值的系数")]
    public float smoothing;
    [Tooltip("相机移动的左下边界")]
    public Vector2 minPos;
    [Tooltip("相机移动的右上边界")]
    public Vector2 maxPos;
    void Start()
    {
        
    }

    void LateUpdate()//相机跟随玩家
    {
        if (target != null)//target是玩家的transform
        {
            if (target.position != transform.position) 
            {
                Vector3 targetPos = target.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);//不超过边界
                targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
                //插值
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
