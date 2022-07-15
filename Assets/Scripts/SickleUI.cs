using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SickleUI : MonoBehaviour
{
    
    public Text sickleQuantity;

    public static int currentSickleQuantity=6;
   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sickleQuantity.text = currentSickleQuantity.ToString();

    }
}
