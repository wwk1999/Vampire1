using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading1 : MonoBehaviour
{
    public Slider loadSlider;
    void Start()
    {
        GlobalPlayerAttribute.IsGame = true;
        var async = SceneManager.LoadSceneAsync("FightScene");
        async.allowSceneActivation = false; // 禁止自动场景激活，让你手动控制

        // 开启一个协程，用于每帧同步进度
        UITool.S.StartCoroutine(UpdateSliderProgress(async, loadSlider));

        // 当加载完成后，控制场景激活
        async.completed += (operation) =>
        {
            GameObject.Find("UIRoot").SetActive(false);
        };
    }
    
    private IEnumerator UpdateSliderProgress(AsyncOperation async, Slider loadSlider)
    {
        // 循环更新加载进度
        while (!async.isDone)
        {
            // 更新进度条，但要注意 `async.progress` 最大值只有 0.9（完成后会停在 0.9）
            loadSlider.value = Mathf.Clamp01(async.progress / 0.9f);

            // 当加载进度达到 0.9 时让场景激活
            if (async.progress >= 0.9f)
            {
                WindowController.S.GameLevelWindow.SetActive(false);
                //UITool.S.GetChildGameObject("GameLevel").SetActive(false);
                //UITool.S.GetChildGameObject("SceneLoading").SetActive(false);
                // 模拟一个短暂停顿，比如让进度条达到100%后稍作等待
                // yield return new WaitForSeconds(1f);
            
                // 激活场景
                async.allowSceneActivation = true;
            }

            yield return null; // 每帧等待
        }
    }

    
}
