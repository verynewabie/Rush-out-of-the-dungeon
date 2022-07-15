using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Text healthText;
    public static int nowHealth;
    public static int maxHealth;
    private Image healthBar;
    void Start()
    {
        healthBar = GetComponent<Image>();
        healthText.text = nowHealth.ToString() + "/" + maxHealth.ToString();
    }

    void Update()
    {
        healthBar.fillAmount = (float)nowHealth / maxHealth;
        healthText.text = nowHealth.ToString() + "/" + maxHealth.ToString();
    }
}
