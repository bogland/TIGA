using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Tiga.Util.Scene
{
    public class SceneLoader
    {
        public List<string> sceneList;

        public SceneLoader()
        {
            sceneList = new List<string>();
        }

        public void RegisterScenes(string [] sceneList)
        {
            foreach (var sceneName in sceneList)
                this.sceneList.Add(sceneName);
        }
        public void LoadScene(string sceneName)
        {
            if (!IsSceneExist(sceneName))
            {
                //씬이 없으면 벗어남
                return;
            }
            //string currentScene = SceneManager.GetActiveScene().name;
            //SceneManager.UnloadSceneAsync(currentScene);
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
  
    }
        private bool IsSceneExist(string sceneName)
        {
            bool isExist = false;
            foreach (var registedSceneName in sceneList)
            {
                if (registedSceneName == sceneName)
                {
                    isExist = true;
                    break;
                }
            }
            return isExist;
        }
    }
}
