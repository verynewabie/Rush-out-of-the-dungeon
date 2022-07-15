using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnake : Enemy
{
    // Start is called before the first frame update
    private Animator myAnime;
    private Rigidbody2D myRigid;
    new void Start()
    {
        base.Start();
        myAnime = GetComponent<Animator>();
        myRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (player != null)
        {
            if (Vector2.Distance(player.transform.position, transform.position) < radius)
            {
                myAnime.SetBool("Run", true);
                if (player.transform.position.x > transform.position.x)
                {
                    myRigid.velocity = new Vector2(speed, myRigid.velocity.y);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (player.transform.position.x < transform.position.x)
                {
                    myRigid.velocity = new Vector2(-speed, myRigid.velocity.y);
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
            }
            else
            {
                myAnime.SetBool("Run", false);
            }
        }
        else
        {
            myAnime.SetBool("Run", false);
        }
    }
}
