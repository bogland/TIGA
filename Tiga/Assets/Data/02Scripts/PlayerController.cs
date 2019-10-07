using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string name;
    public int age;
    public int level;
    public bool isDead;
    public string[] items;   

    public string[] ITEMS
    {
        get { return items; }
        set { items = value; }
    }
}

public class PlayerController : MonoBehaviour
{
    public static PlayerController _uniqueInstance;

    public PlayerData playerData;
    public List<PlayerData> PlayerState = new List<PlayerData>();

    void Start()
    {
        _uniqueInstance = this;  
        
        if(BaseSceneManager._uniqueInstance.CURSTATE == BaseSceneManager.eStageState.INGAME_01)
        {
            int count = 0;
            foreach(string item in playerData.ITEMS)
            {
                if(count > 3)
                {
                    playerData.items[count] = "빈칸";
                }
                count++;
            }
            SavePlayerDataToJson();
        }
    }

    [ContextMenu("To Json Data")]
    public void SavePlayerDataToJson()
    {
        string jsonData = JsonUtility.ToJson(playerData, true);
        string path = Path.Combine(Application.dataPath + "/GameResources/UserData/playerData.json");
        File.WriteAllText(path, jsonData);
    }
     
    [ContextMenu("From Json Data")]
    public void LoadPlayerDataFromJson()
    {
        string path = Path.Combine(Application.dataPath + "/GameResources/UserData/playerData.json");
        string jsonData = File.ReadAllText(path);

        Debug.Log("인벤토리 : " + jsonData);

        playerData = JsonUtility.FromJson<PlayerData>(jsonData);
    } 

    /// <summary>
    /// 큐브 획득 메소드.
    /// </summary>
    /// <returns></returns>
    public bool GetCube()
    {
        Debug.Log("큐브를 얻었습니다.");
        int count = 0;
        foreach(string item in playerData.ITEMS)
        {
            if(item == "빈칸")
            {
                playerData.items[count] = "큐브";
                return true;
            }
            count++;
        }
        return false;
    }
}
