using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("���Ѫ��")]
    public static int health=10;
    [Tooltip("�޵�ʱ��")]
    public float timeNoHurt;
    [Tooltip("������˸����")]
    public int blinkTimes;
    [Tooltip("������˸���")]
    public float blinkGap;
    [Tooltip("�����������ٵ�ʱ��")]
    public float dieTime;
    private Renderer myRenderer;
    private Animator anime;
    private CapsuleCollider2D capsule;
    private ScreenFlash sf;
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        anime = GetComponent<Animator>();
        HealthBar.nowHealth = health;
        HealthBar.maxHealth = 10;
        capsule = GetComponent<CapsuleCollider2D>();
        sf = GetComponent<ScreenFlash>();
       
    }

    void Update()
    {

    }

    public void DamagePlayer(int damage)
    {
        sf.FlashScreen();
        if (capsule.enabled == false) return;
        capsule.enabled = false;
        health -= damage;
        SoundsManager.PlayHurt();
        HealthBar.nowHealth = Mathf.Max(health, 0);
        if (health <= 0)
        {
            anime.SetTrigger("Die");
            Invoke("Die", dieTime);
            Destroy(gameObject,dieTime);
            return ;
        }
        Invoke("ChangeDamageSt", timeNoHurt);
        int tmp = blinkTimes;
        while (tmp != 0) 
        {
            Invoke("SwitchSt", blinkGap);
            tmp--;
        }
    }

    void ChangeDamageSt()
    {
        capsule.enabled = true;
    }

    void SwitchSt()
    {
        myRenderer.enabled = false;
        Invoke("SwitchSt2", blinkGap);
    }
    void SwitchSt2()
    {
        myRenderer.enabled = true;
    }
    void Die()
    {
        Enemy.count = 0;
        Destroy(this.gameObject);
        SceneManager.LoadScene(8);
    }
}
