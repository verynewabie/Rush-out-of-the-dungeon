using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         PlayerHealth.health = 10;
        CoinUI.CurrentCionQuantity = 0;
        SickleUI.currentSickleQuantity = 6;
        BombUI.currentBombQuantity = 6;
    }

    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void HelpGame()
    {
        SceneManager.LoadScene(7);
    }
    public void LoadGame() {
        PauseMenu.LoadDate();
    
    
    }
}
