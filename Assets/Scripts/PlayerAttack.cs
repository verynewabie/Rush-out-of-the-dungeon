using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Tooltip("ÉËº¦")]
    public int damage;
    [Tooltip("¸¸½Úµã")]
    public Transform father;
    [Tooltip("¹¥»÷CD")]
    public float attackCd;
    private float startTime = 4f / 12f;
    private float endTime = 5f / 12f;
    private Animator anime;
    private PolygonCollider2D coll;
    private bool isAttacking = false;
    void Start()
    {
        anime = father.gameObject.GetComponent<Animator>();
        coll = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if (Input.GetButton("Attack") && !isAttacking ) 
        {
            isAttacking = true;
            anime.SetTrigger("Attack");
            Invoke("PlayAttack",0.25f);
            Invoke("AttackRec", attackCd);
            Invoke("startAttack",startTime);
            Invoke("endAttack", endTime);
        }
    }
    void startAttack()
    {
        coll.enabled = true;
    }
    void endAttack()
    {
        coll.enabled = false;
    }
    void AttackRec ()
    {
        isAttacking = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Enemy")
            &&other.GetType().ToString()== "UnityEngine.BoxCollider2D")
        {
            other.GetComponent<Enemy>().Hurt(damage);
        }
    }

    void PlayAttack()
    {
        SoundsManager.PlayAttack();
    }
}
