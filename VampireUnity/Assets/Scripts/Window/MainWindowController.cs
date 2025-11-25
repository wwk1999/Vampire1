using Mysql;
using UnityEngine;

public class MainWindowController : MonoBehaviour
{
    void Start()
    {
        StoreController.S.LoadStoreData();
        WindowController.S.InitPanel();
        ResourcesConfig.Init();
        WindowController.S.MainWindow.SetActive(true);
        LevelInfoConfig.init();
        AudioController.S.BGAudioSource.Play(); 
        LevelInfoConfig.InitGameLevel();
        WeaponSourceConfig.InitWeaponSourceConfig();
    }

    // Update is called once per frame
    public void InitPanel()
    {
        
    }
}
