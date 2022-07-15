using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Tooltip("��������ֵ")]
    public int health;
    [Tooltip("�����˺�")]
    public int damage;
    [Tooltip("������˸ʱ��")]
    public float redTime;
    [Tooltip("���Χ�����½�")]
    public Transform leftDownPos;
    [Tooltip("���Χ�����Ͻ�")]
    public Transform rightUpPos;
    [Tooltip("�ƶ��ٶ�")]
    public float speed;
    [Tooltip("������Ч")]
    public GameObject bloodEffect;
    [Tooltip("�������")]
    public Animator cameraAnime;
    [Tooltip("׷����ҵķ�Χ")]
    public float radius;
    //������������ҵ���
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
        //ע�������ж��Ƿ��ǽ�����
        if (other.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"
            )
        {
            playerHealth.DamagePlayer(damage);
        }
    }
}
