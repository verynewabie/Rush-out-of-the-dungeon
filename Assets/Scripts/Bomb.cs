using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explodeRange;
    public Vector2 startSpeed;
    public float delayExplodeTime;
    public float destroyBombTime;
    public float hitBoxTime;

    private Rigidbody2D rb2d;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb2d.velocity = transform.right * startSpeed.x + transform.up * startSpeed.y;

        Invoke("Explode", delayExplodeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Explode()
    {
        anim.SetTrigger("Explode");
        Invoke("PlayBomb",0.2f);
        
        Invoke("GetExplodeRange", hitBoxTime);
        Invoke("DestroyThisBomb", destroyBombTime);
    }

    void PlayBomb()
    {
        SoundsManager.PlayBomb();
    }
    void GetExplodeRange()
    {
        Instantiate(explodeRange, transform.position, Quaternion.identity);
    }
    void DestroyThisBomb()
    {
        Destroy(gameObject);
    }
}
