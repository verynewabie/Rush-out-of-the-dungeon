using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
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
            dialogText.text = signText;
            dialogBox.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && dialogBox.activeSelf && isPlayerAttached) 
        {
            dialogBox.SetActive(false);
            Debug.Log("shixiao");
            Debug.Log(dialogBox.activeSelf);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"
            )
        {
            isPlayerAttached = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"
            )
        {
            isPlayerAttached = false;
            dialogBox.SetActive(false);
        }
    }
}
