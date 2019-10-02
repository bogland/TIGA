using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SceneKind
{
    public string _sceneName;

    public SceneKind(string sceneName)
    {
        _sceneName = sceneName;
    }
}

public class JsonManager : MonoBehaviour
{
    public static JsonManager _uniqueInstance;

    public List<SceneKind> SceneList = new List<SceneKind>();  // 현 진행상황인 씬 저장용 리스트.

    void Start()
    {
        _uniqueInstance = this;
    }

    public void ResetPlayerItem()
    {

    }

    /// <summary>
    /// 다음 스테이지로 넘어갈때마다 저장해주는 메소드.
    /// </summary>
    public void SaveScene(int stage)
    {
        Debug.Log("씬을 저장합니다.");
        Debug.Log("저장된 씬 : " + stage);
        
        SceneList.Clear();
        SceneList.Add(new SceneKind(stage.ToString()));
        JsonData SceneLoad = JsonMapper.ToJson(SceneList);

        //Debug.Log("Scene Load : " + SceneLoad.ToString());

        File.WriteAllText(Application.dataPath + "/ForImplementation/Data/Resources/SceneData.json", SceneLoad.ToString());
    }
}
