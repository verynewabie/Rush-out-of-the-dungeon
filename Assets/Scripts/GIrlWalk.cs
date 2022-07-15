using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GIrlWalk : MonoBehaviour
{
    public float radius;
    public float speed;

    public static bool isTalk = false;

    public Text words;
    private GameObject dialolgBox;
    private Text girlTalk;
    private Transform playerTransform;
    private Animator myAnime;
    private string girlWords = "������лл������ң������ոձ���ɱ������������ʵ�����ҵĸ��ס�������������������������������ʦ���Ὣ�Ҹ��׵��������Ტ���Ҹ��׵�����ӡ��ԭ���������������ڣ�������֮����ɱ�����˻ʣ��Ӷ������������ˣ�������ú�ȥ�δӰ�......";

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        dialolgBox = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(4).gameObject;
        girlTalk = dialolgBox.GetComponentInChildren<Text>();
        myAnime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.x > transform.position.x)
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Vector2.Distance(playerTransform.position, transform.position) < radius)
        {
            if (Vector2.Distance(playerTransform.position, transform.position) > 1f)
            { 
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
                myAnime.SetBool("Walk", true);
                dialolgBox.SetActive(false);
            }
            else
            {
                myAnime.SetBool("Walk", false);
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    if (dialolgBox.activeSelf)
                    {
                        dialolgBox.SetActive(false);
                    }
                    else
                    {
                        girlTalk.text = girlWords;
                        dialolgBox.SetActive(true);
                    }
                }
            }
        }
        else
        { 
            myAnime.SetBool("Walk", false);
        }
    }
}