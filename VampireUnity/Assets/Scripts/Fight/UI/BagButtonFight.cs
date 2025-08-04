using UnityEngine;
using UnityEngine.UI;

public class BagButtonFight : MonoBehaviour
{
    public Button bagButtonFight;
    void Start()
    {
        bagButtonFight.onClick.AddListener(() =>
        {
            BagController.S.ShowBag();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
