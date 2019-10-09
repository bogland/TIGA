using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiga.Util.Scene.LoadScene
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// 싱글톤 클래스를 생성하기 위해서
        /// public static GameManager Instance {get; private set;} 만들고
        /// 유니티에선 생성자 대신 private void Awake()로 Instance생성, 기존에 있던게 null이면 새로 생성
        /// DontDestroyOnLoad를 하면 씬이 바뀌어도 Object가 파괴되지 않음
        /// 만약 기존에 Instance가 존재하면 이미 만들어진 것이므로 해당 게임 오브젝트는 파괴한다.
        /// 버튼에 싱글톤으로 만든 클래스 메소드를 넣으면 파괴되어 missing뜸, 새로 클래스 만든어서 Wrapping 해야함 
        /// </summary>
        public static GameManager Instance { get; private set; }
        SceneLoader sceneLoader;
        // Use this for initialization
        public bool firstLoaded;
  
        private void Awake()
        {
            if (Instance==null)
            {
                Instance = this;
                sceneLoader = new SceneLoader();
                DontDestroyOnLoad(gameObject);
                //Debug.Log("GameManager :: 첫 메모리 로드");
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
        void Start()
        {
                //Debug.Log("첫 로드");
                string[] sceneNames = { "MainMenu", "Stage001" };
                sceneLoader.RegisterScenes(sceneNames);
                sceneLoader.LoadScene("MainMenu");

        }

        public void NewStage()
        {
            sceneLoader.LoadScene("Stage001");
        }
    }
}

