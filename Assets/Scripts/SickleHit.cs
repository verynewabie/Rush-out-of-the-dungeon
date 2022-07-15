using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleHit : MonoBehaviour
{
    public GameObject sickle;

    //private GameObject sickleUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)&&SickleUI.currentSickleQuantity>0)
        {
            SoundsManager.PlaySickle();
            Instantiate(sickle, transform.position, transform.rotation);
            
            SickleUI.currentSickleQuantity--;
        }
    }
   
}
