using Mysql;
using UnityEngine;

public class MainWindowController : MonoBehaviour
{
    void Start()
    {
        // 初始化主线程调度器
        Tool.UnityMainThreadDispatcher.Instance();
        
        //PanelManager.S.PushPanel(new MainWindow());
        WindowController.S.InitPanel();
        ResourcesConfig.Init();
        WindowController.S.MainWindow.SetActive(true);
        LevelInfoConfig.init();
        AudioController.S.BGAudioSource.Play(); 
        LevelInfoConfig.InitGameLevel();
    }

    // Update is called once per frame
    public void InitPanel()
    {
        
    }
}
