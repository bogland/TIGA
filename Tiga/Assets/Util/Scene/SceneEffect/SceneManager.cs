using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiga.Util.Scene.SceneEffect
{
    public class SceneManager : MonoBehaviour
    {
        public CanvasGroup TransitionPanel;
        // Use this for initialization
        void Start()
        {
            SceneEffector sceneEffector = new SceneEffector(TransitionPanel);
            StartCoroutine(sceneEffector.FadeOut());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
