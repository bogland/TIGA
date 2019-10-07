using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneEffector
{
    public CanvasGroup panel;
    // Use this for initialization
    public float durationTime = 5f;

    public SceneEffector(CanvasGroup panel)
    {
        this.panel = panel;
    }

    public void setTime(float durationTime)
    {
        this.durationTime = durationTime;
    }
    public IEnumerator FadeOut()
    {
        float time = 0;
        while (panel.alpha > 0f)
        {
            time += Time.deltaTime / durationTime;
            panel.alpha = Mathf.Lerp(1, 0, time);
            yield return null;
        }
    }

    public IEnumerator FadeIn()
    {
        float time = 0;
        while (panel.alpha < 1f)
        {
            time += Time.deltaTime / durationTime;
            panel.alpha = Mathf.Lerp(0, 1, time);
            yield return null;
        }
    }

}
