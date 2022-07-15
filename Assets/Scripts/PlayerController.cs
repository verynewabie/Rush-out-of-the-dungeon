using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //1֡=1/12��
    [Tooltip("�ƶ��ٶ�")]
    public float runSpeed;
    [Tooltip("��Ծ�ٶ�")]
    public float jumpSpeed;
    [Tooltip("�������ٶ�")]
    public float doubleJumpSpeed;
    [Tooltip("����CD")]
    public float attackCd;
    [Tooltip("�ָ�Player��ʱ��")]
    public float restoreTime;
    [Tooltip("�����ӵ��ٶ�")]
    public float climbSpeed;
   public static bool playerIsTalk=false;

    private GameObject dialolgBox;
    private Text playerTalk;
    private Animator myAnime;
    private Rigidbody2D myRigidBody;
    private BoxCollider2D myFeet;
    private bool canDoubleJump = true;
    private int now;
    private bool onOneWayPlatform;
  

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnime = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
        dialolgBox = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(4).gameObject;
        playerTalk = dialolgBox.GetComponentInChildren<Text>();
    }

    void Update()
    {
        Run();
        CheckLadder();
        if (Input.GetButtonDown("Jump"))
        {
            
            if (CheckGrounded())
            {
                PlayerJump();
                now = 1;
            }
            else
            {
                if (canDoubleJump && now == 1 ||
                    myAnime.GetBool("IsFalling") && now == 0) 
                {
                    Vector2 jumpVel = new Vector2(0, doubleJumpSpeed);
                    myRigidBody.velocity = Vector2.up * jumpVel;
                    now = 2;
                    myAnime.SetBool("DoubleJump", true);
                }
            }
        }
        //ת��״̬
        SwitchStatus();
        OneWayPlatformCheck();
        if(GIrlWalk.isTalk)
        {
            Invoke("PlayerIsTalk", 1);
            if(Input.GetKeyDown(KeyCode.Z))
            {
                GIrlWalk.isTalk = false;
            }
        }
        
    }

    bool CheckGrounded()
    {
        onOneWayPlatform = myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
        return myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))||
            myFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform"))||
            myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"))||
            myFeet.IsTouchingLayers(LayerMask.GetMask("DestructibleLayer"))||
            myFeet.IsTouchingLayers(LayerMask.GetMask("Enemy"));
    }
    void PlayerJump()
    {
        Vector2 jumpVel = new Vector2(0, jumpSpeed);
        myRigidBody.velocity = Vector2.up * jumpVel;
        myAnime.SetBool("Jump", true);
    }
    void Run()
    {
        //�����˶�
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVel;
        float xSpeed = playerVel.x;
        if (xSpeed > 0.0f)
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
            myAnime.SetBool("Run", true);
        }
        else if (xSpeed < -0.0f) 
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);
            myAnime.SetBool("Run", true);
        }
        else
        {
            myAnime.SetBool("Run", false);
        }
    }
    void SwitchStatus()
    {
        myAnime.SetBool("Idle", false);
        if (myRigidBody.velocity.y < -0.01f)
        {
            myAnime.SetBool("IsFalling",true);
        }
        else
        {
            myAnime.SetBool("IsFalling", false);
        }
        if (myAnime.GetBool("Jump"))
        {
            if (myRigidBody.velocity.y < 0.01f)
            {
                myAnime.SetBool("Jump", false);
                myAnime.SetBool("Fall", true);
            }
        }
        else if (myAnime.GetBool("DoubleJump"))
        {
            if (myRigidBody.velocity.y < 0.01f)
            {
                myAnime.SetBool("DoubleJump", false);
                myAnime.SetBool("DoubleFall", true);
            }
        }
        else if (CheckGrounded())
        {
            myAnime.SetBool("Fall", false);
            myAnime.SetBool("Idle", true);
            myAnime.SetBool("DoubleFall", false);
            now = 0;
        }
    }

    void CheckLadder()
    {
        myFeet.IsTouchingLayers(LayerMask.GetMask("Ladder"));
    }
    void OneWayPlatformCheck()//ʵ�ֵ���ƽ̨��S����
    {
        if(onOneWayPlatform && Input.GetKey(KeyCode.S))
        {
            //������Ȼ�޸�����ҵ���ײ��,�����ǻ�����,��Ϊ��������ǿ���ǩ��ʶ���
            gameObject.layer = LayerMask.NameToLayer("OneWayPlatform");
            Invoke("RestorePlayer", restoreTime);
        }
    }
    void RestorePlayer()
    {
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
}

