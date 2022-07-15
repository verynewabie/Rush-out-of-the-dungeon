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

            signText = "嘿，小伙子，我是囚笼商人，要打败蝙蝠王离不开我的道具，炸弹5块一个，按X购买，回旋镖5块一个，按M购买，血包10块一个，按Z购买";
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
                signText = "没钱就滚啊,穷光蛋!";
                dialogText.text = signText;
                dialogBox.SetActive(true);
            }
        }
        if (isPlayerAttached && Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("正常");
            if (CoinUI.CurrentCionQuantity >= 5)
            {
               
                Instantiate(sickle, this.transform.position, Quaternion.identity);
                CoinUI.CurrentCionQuantity -= 5;
            }
            else
            {
                dialogBox.SetActive(false);
                signText = "没钱就滚啊,穷光蛋!";
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
                signText = "没钱就滚啊,穷光蛋!";
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
