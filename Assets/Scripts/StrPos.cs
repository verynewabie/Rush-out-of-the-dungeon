using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrPos : MonoBehaviour
{
    GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
