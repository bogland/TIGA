using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class LobbyManagerObj : MonoBehaviour
{
    /// <summary>
    /// 게임 새로시작 버튼.
    /// </summary>
    public void NewStartBtn()
    {
        JsonManager._uniqueInstance.SaveScene(1);
        BaseSceneManager._uniqueInstance.SceneMoveAtLobby
            (BaseSceneManager._uniqueInstance.CURSTATE = BaseSceneManager.eStageState.INGAME_01);
    }

    /// <summary>
    /// 로비에서 Load버튼을 누르면 게임 이어하기.
    /// </summary>
    public void LoadBtn()
    {
        Debug.Log("저장된 씬부터 시작됩니다.");

        string JsonString = File.ReadAllText(Application.dataPath + "/ForImplementation/Data/Resources/SceneData.json");
        JsonData name = JsonMapper.ToObject(JsonString);
        string TmpName = name[0]["_sceneName"].ToString();

        Debug.Log("TMPNAME : " + TmpName.ToString());
        //Debug.Log("Json String : " + JsonString);

        BaseSceneManager._uniqueInstance.SceneMoveAtLobby((BaseSceneManager.eStageState)int.Parse(TmpName));     
     }

}
