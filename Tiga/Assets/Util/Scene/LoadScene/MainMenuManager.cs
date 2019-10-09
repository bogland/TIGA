using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tiga.Util.Scene.LoadScene
{
    public class MainMenuManager : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            var button = GameObject.Find("NextStageButton").GetComponent<Button>();
            button.onClick.AddListener(MyMethod);
        }

        // Update is called once per frame
        public void MyMethod()
        {
            GameManager.Instance.NewStage();
        }
    }

}
