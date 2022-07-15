using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : Enemy
{
    
    //private Vector2 targetPos;
    //private bool haveNewPos = false;
    
    new void Start()
    {
        base.Start();
        //haveNewPos = true;
        //targetPos = transform.position;
        //Invoke("ChangePos", stayTime);
    }

    new void Update()
    {
        base.Update();
        if (player != null)
        {
            if (Vector2.Distance(player.transform.position, transform.position) < radius)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
        
        //if (Mathf.Abs(transform.position.x - targetPos.x) < Mathf.Epsilon &&
        //    Mathf.Abs(transform.position.y - targetPos.y) < Mathf.Epsilon) 
        //{
        //    if(haveNewPos == false)
        //    {
        //        haveNewPos = true;
        //        Invoke("ChangePos", stayTime);
        //    }
        //}
        //else
        //{
        //    //向目标位置移动
        //    transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        //}
    }
    //void ChangePos()
    //{
    //    targetPos = RandomPos();
    //    Invoke("ChangeSt", Vector2.Distance(transform.position,targetPos) / speed);
    //}

    //void ChangeSt()
    //{
    //    haveNewPos = false;
    //}
}
