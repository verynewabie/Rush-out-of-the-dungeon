using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject sickle;
    public GameObject xuebao;
    public GameObject bomb;
    public Text dialogText;
    public string signText;
    private bool isPlayerAttached;
    void Start()
    {
        dialogBox = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(4).gameObject;
        dialogText = dialogBox.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerAttached && !dialogBox.activeSelf)
        {

            signText = "�٣�С���ӣ������������ˣ�Ҫ����������벻���ҵĵ��ߣ�ը��5��һ������X���򣬻�����5��һ������M����Ѫ��10��һ������Z����";
            dialogText.text = signText;
            dialogBox.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && dialogBox.activeSelf && isPlayerAttached)
        {
            dialogBox.SetActive(false);
            Debug.Log(dialogBox.activeSelf);
        }
        if (isPlayerAttached && Input.GetKeyDown(KeyCode.X))
        {
            if (CoinUI.CurrentCionQuantity >= 5)
            {
                Instantiate(bomb,this.transform.position,Quaternion.identity);
                CoinUI.CurrentCionQuantity -= 5;
            }
            else
            {
                dialogBox.SetActive(false);
                signText = "ûǮ�͹���,��⵰!";
                dialogText.text = signText;
                dialogBox.SetActive(true);
            }
        }
        if (isPlayerAttached && Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("����");
            if (CoinUI.CurrentCionQuantity >= 5)
            {
               
                Instantiate(sickle, this.transform.position, Quaternion.identity);
                CoinUI.CurrentCionQuantity -= 5;
            }
            else
            {
                dialogBox.SetActive(false);
                signText = "ûǮ�͹���,��⵰!";
                dialogText.text = signText;
                dialogBox.SetActive(true);
            }
        }

        if (isPlayerAttached && Input.GetKeyDown(KeyCode.Z))
        {
            if (CoinUI.CurrentCionQuantity >= 10)
            {
                Instantiate(xuebao, this.transform.position, Quaternion.identity);
                CoinUI.CurrentCionQuantity -= 10;
            }
            else
            {
                dialogBox.SetActive(false);
                signText = "ûǮ�͹���,��⵰!";
                dialogText.text = signText;
                dialogBox.SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerAttached = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerAttached = false;
            dialogBox.SetActive(false);
        }
    }
}
