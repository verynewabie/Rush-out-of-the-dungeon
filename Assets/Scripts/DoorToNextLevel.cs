using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class DoorToNextLevel : MonoBehaviour
{
    private bool isDoor;
    private int now;
    void Start()
    {
        now = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("现在活跃的是" + now);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("现在有" + Enemy.count);
        if (Input.GetKeyDown(KeyCode.R) && isDoor && Enemy.count == 0) 
        {

            SceneManager.LoadScene(now + 1);
            SaveData();
        }

    }
    public void SaveData()
    {
        Save save = CreatSaveGO();
        string filePath = Application.dataPath + "/byJson.json";
        //将save对象转换为Json格式的字符串
        string saveJsonStr = JsonMapper.ToJson(save);
        //将字符串写入到文件中
        //先创建一个StreamMriter
        StreamWriter sw = new StreamWriter(filePath);
        sw.Write(saveJsonStr);
        //关闭SM
        sw.Close();
        Debug.Log("成功保存");

    }
    private Save CreatSaveGO()
    {
        Save save = new Save();
        save.health = PlayerHealth.health;
        //string str = save.health.ToString();
        //Debug.Log("creat" + str);
        save.coin = CoinUI.CurrentCionQuantity;
        save.sickle = SickleUI.currentSickleQuantity;
        save.bomb = BombUI.currentBombQuantity;
        save.scene = SceneManager.GetActiveScene().buildIndex;
        return save;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isDoor = true;
        }   
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isDoor = false;
    }
}
