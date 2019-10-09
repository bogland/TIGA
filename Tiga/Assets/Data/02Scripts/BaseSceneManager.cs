using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseSceneManager : MonoBehaviour
{
    public static BaseSceneManager _uniqueInstance;
    public enum eLoadingState
    {
        NONE,
        START,
        LOADING,
        UNLOADING,
        END,
    }

    public enum eStageState
    {
        NONE,
        INGAME_01,
        INGAME_02,
        INGAME_03,
        LOBBY,
    }

    eLoadingState _curLoadState;
    eStageState _curState;

    public eStageState CURSTATE
    {
        get { return _curState; }
        set { _curState = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _uniqueInstance = this;
        SceneManager.LoadSceneAsync("LobbyScene", LoadSceneMode.Additive);
        _curState = eStageState.LOBBY;
    }

    public IEnumerator LoadingScene(string[] loadName, string[] unloadName)
    {
        AsyncOperation AO;

        int amount;

        if (unloadName == null)
            amount = 0;
        else
            amount = unloadName.Length;

        _curLoadState = eLoadingState.UNLOADING;
        for(int i = 0; i < amount; i++)
        {
            AO = SceneManager.UnloadSceneAsync(unloadName[i]);
            while(!AO.isDone)
            {
                yield return null;
            }
            yield return new WaitForSeconds(1);
        }

        _curLoadState = eLoadingState.LOADING;
        // Load 실행.
        if (loadName == null)
        {
            amount = 0;
        }
        else
        {
            amount = loadName.Length;
        }
        for (int i = 0; i < amount; i++)
        {
            AO = SceneManager.LoadSceneAsync(loadName[i], LoadSceneMode.Additive);
            while (!AO.isDone)
            {
                yield return null;
            }
            yield return new WaitForSeconds(1);
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(loadName[amount - 1]));

        _curLoadState = eLoadingState.END;
    }

    /// <summary>
    /// 로비 => 게임 으로 전환되는 메소드.
    /// </summary>
    /// <param name="stage"></param>
    public void SceneMoveAtLobby(eStageState stage)
    {
        _curState = stage;

        string[] unloadStage = new string[1];
        unloadStage[0] = "LobbyScene";

        string[] loadStage = new string[2];
        loadStage[0] = "InGameScene";
        loadStage[1] = "Stage" + (int)stage;

        //Debug.Log(_curState.ToString());
        //Debug.Log(unloadStage[0].ToString());
        //Debug.Log(loadStage[0].ToString());
        StartCoroutine(LoadingScene(loadStage, unloadStage));
    }

    /// <summary>
    /// 게임 => 로비 로 전환되는 메소드.
    /// </summary>
    public void SceneMoveAtGame(eStageState stage)
    {
        //_curState = stage;
        string[] unloadStage;
        string[] loadStage;

        if(stage == eStageState.LOBBY)
        {
            unloadStage = new string[2];
            loadStage = new string[1];
            unloadStage[0] = "InGameScene";
            unloadStage[1] = "Stage" + (int)_curState;
            loadStage[0] = "LobbyScene";

            Debug.Log(_curState.ToString());
            Debug.Log(unloadStage[0].ToString());
            Debug.Log(loadStage[0].ToString());
        }
        else
        {
            unloadStage = new string[1];
            loadStage = new string[1];
            unloadStage[0] = "Stage" + (int)stage;
            loadStage[0] = "Stage" + (int)_curState;

            Debug.Log(_curState.ToString());
            Debug.Log(unloadStage[0].ToString());
            Debug.Log(loadStage[0].ToString());
        }

        StartCoroutine(LoadingScene(loadStage, unloadStage));
    }
    
}
