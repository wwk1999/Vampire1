using System.Collections;
using System.Collections.Generic;
using Mysql;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightExitPanel : MonoBehaviour
{
    public Button ExitButton; // 退出按钮
    public Button ContinueButton; // 继续按钮
    // Start is called before the first frame update
    void Start()
    {
        ExitButton.onClick.AddListener(() =>
        {
            Debug.Log("退出游戏，保存数据");
            Time.timeScale = 1;
            GlobalPlayerAttribute.IsGame = false;
            PlayerInfoController.S.UpdatePlayerInfo( UserController.S.selfuserId,GlobalPlayerAttribute.Level, GlobalPlayerAttribute.Exp, GlobalPlayerAttribute.GameLevel, GlobalPlayerAttribute.BloodEnergy);
            EquipController.S.BatchInsertEquipsWithTransaction(BagController.S.EquipIdList);
            SceneManager.LoadScene("UIScene");
        });
        ContinueButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            Destroy(gameObject);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
