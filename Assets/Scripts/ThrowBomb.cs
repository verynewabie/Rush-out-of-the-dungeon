using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
    public GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && BombUI.currentBombQuantity > 0) 
        {
            BombUI.currentBombQuantity -= 1;
            Instantiate(bomb, transform.position, transform.rotation);
        }
    }
}
