using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollIndexCallback2 : MonoBehaviour
{
    public Button imageButton;
    public LayoutElement element;
    public static float[] randomWidths = new float[3] { 100, 150, 50 };
    void ScrollCellIndex(int idx)
    {
        imageButton.onClick.AddListener(() =>
        {
            WindowController.S.Message.transform.Find("MessageItem").position = new Vector2(imageButton.transform.position.x+113, imageButton.transform.position.y+53);
            switch (LevelInfoConfig.CurrentGameLevel)
            {
                case 1:
                    WindowController.S.Message.transform.Find("MessageItem/messagetext").GetComponent<Text>().text =
                        LevelInfoConfig.LevelInfoItem1.DiaoLuoNameList[idx];
                    break;
                case 2:
                    WindowController.S.Message.transform.Find("MessageItem/messagetext").GetComponent<Text>().text =
                        LevelInfoConfig.LevelInfoItem2.DiaoLuoNameList[idx];        
                    break;
                case 3:
                    WindowController.S.Message.transform.Find("MessageItem/messagetext").GetComponent<Text>().text =
                        LevelInfoConfig.LevelInfoItem3.DiaoLuoNameList[idx];      
                    break;
            }
            WindowController.S.Message.SetActive(true);
        });
        switch ( LevelInfoConfig.CurrentGameLevel)
        {
            case 1:
                imageButton.image.sprite = LevelInfoConfig.LevelInfoItem1.DiaoLuoIconList[idx];
                break;
            case 2:
                imageButton.image.sprite= LevelInfoConfig.LevelInfoItem2.DiaoLuoIconList[idx];
                break;
            case 3:
                imageButton.image.sprite = LevelInfoConfig.LevelInfoItem3.DiaoLuoIconList[idx];
                break;
        }

        string name = "Cell " + idx.ToString();
        
        element.preferredWidth = 52;
        gameObject.name = name;
    }
}
