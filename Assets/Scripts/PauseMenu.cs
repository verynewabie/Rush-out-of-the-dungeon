using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioSource music;
    public Toggle musicToggle;
    //public GameObject player;


    // Start is called before the first rame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MusicSwitch();
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0) 
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    private void MusicSwitch()
    {
        if (musicToggle.isOn == true)
        {
            music.enabled = true;
        }
        else { music.enabled = false; }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void Pause()
    {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }
    public void MainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");

    }

    public void QuitGame()
    {
        Application.Quit();

    }

    public static void SetGame(Save save)
    {
        SceneManager.LoadScene(save.scene+1);

              
            PlayerHealth.health = save.health;
            CoinUI.CurrentCionQuantity = save.coin;
            SickleUI.currentSickleQuantity = save.sickle;
            BombUI.currentBombQuantity = save.bomb;
        

        //string str = save.health.ToString();
        //string str2 = PlayerHealth.health.ToString();
       // Debug.Log("load成功"+str+""+str2);
       
    }

    
    public static void LoadDate()
    {
        string filePath = Application.dataPath + "/byJson.json";
        if (File.Exists(filePath))
        {
            StreamReader sr = new StreamReader(filePath);
            //将读取到的流赋值给jsonStr；
            string jsonStr = sr.ReadToEnd();
            Save save = JsonMapper.ToObject<Save>(jsonStr);
            SetGame(save);
        }

        else { Debug.Log("读取文档不存在"); }
    }



}
