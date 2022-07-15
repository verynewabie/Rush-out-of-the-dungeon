using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBat : Enemy
{
    // Start is called before the first frame update
    bool isBirthing;
    public GameObject bat;
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
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
        if (!isBirthing && health != 100)
        {
            isBirthing = true;
            Invoke("Birth",5f);
        }
    }
    void Birth()
    {
        Instantiate(bat, this.transform.position, Quaternion.identity);
        Invoke("Birth", 5f);
    }
}
