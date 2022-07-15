using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static AudioSource audioSrc;
    public static AudioClip pickCoin;
    public static AudioClip throwCoin;
    public static AudioClip attack;
    public static AudioClip bomb;
    public static AudioClip sickle;
    public static AudioClip hurt;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        pickCoin =Resources.Load<AudioClip>("PickCoin");
        throwCoin = Resources.Load<AudioClip>("ThrowCoin");
        attack = Resources.Load<AudioClip>("Attack");
        bomb = Resources.Load<AudioClip>("Bomb");
        sickle = Resources.Load<AudioClip>("Sickle");
        hurt = Resources.Load<AudioClip>("Hurt");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlayPickCoin() {
        audioSrc.PlayOneShot(pickCoin);

    }
    public static void PlayThrowCoin() {
        audioSrc.PlayOneShot(throwCoin);
    }

    public static void PlayAttack()
    {
        audioSrc.PlayOneShot(attack);
    }

    public static void PlayBomb()
    {
        audioSrc.PlayOneShot(bomb);
    }

    public static void PlaySickle()
    {
        audioSrc.PlayOneShot(sickle);
    }

    public static void PlayHurt()
    {
        audioSrc.PlayOneShot(hurt);
    }
}
