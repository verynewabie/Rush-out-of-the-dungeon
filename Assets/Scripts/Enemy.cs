using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Tooltip("怪物生命值")]
    public int health;
    [Tooltip("怪物伤害")]
    public int damage;
    [Tooltip("受伤闪烁时间")]
    public float redTime;
    [Tooltip("活动范围的左下角")]
    public Transform leftDownPos;
    [Tooltip("活动范围的右上角")]
    public Transform rightUpPos;
    [Tooltip("移动速度")]
    public float speed;
    [Tooltip("受伤特效")]
    public GameObject bloodEffect;
    [Tooltip("相机动画")]
    public Animator cameraAnime;
    [Tooltip("追击玩家的范围")]
    public float radius;
    //怪物死亡，金币掉落
    public GameObject dropCoin;
    public static int count;

    protected Transform nowPos;
    private SpriteRenderer sr;
    private Color originColor;
    protected GameObject player;
    private PlayerHealth playerHealth;
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        originColor = sr.color;
        //transform.position = RandomPos();
        cameraAnime = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        count++;
    }

    protected void Update()
    {
        if (health <= 0)
        {
            Instantiate(dropCoin, transform.position, Quaternion.identity);
            count--;
            Destroy(gameObject);
        }
        
    }
    public void Hurt(int hurt,bool shake=true)
    {
        health -= hurt;
        FlashColor(redTime);
        if(shake) cameraAnime.SetTrigger("Shake");
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
    }

    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }
    void ResetColor()
    {
        sr.color = originColor;
    }

    public Vector2 RandomPos()
    {
        return (new Vector2
        (Random.Range(leftDownPos.position.x, rightUpPos.position.x),
        Random.Range(leftDownPos.position.y, rightUpPos.position.y)));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //注释里是判断是否是胶囊体
        if (other.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"
            )
        {
            playerHealth.DamagePlayer(damage);
        }
    }
}
