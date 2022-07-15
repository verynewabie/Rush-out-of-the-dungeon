using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BombUI : MonoBehaviour
{

    public Text bombQuantity;

    public static int currentBombQuantity=6;
    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        bombQuantity.text = currentBombQuantity.ToString();
    }
}
