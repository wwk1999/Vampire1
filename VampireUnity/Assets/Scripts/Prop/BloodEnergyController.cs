using System;
using UnityEngine;

public class BloodEnergyController : MonoBehaviour
{
    public float speed = 5f; // 血能跟随的速度
    public bool isPickUp = false; // 是否被拾取

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, GameController.S.gamePlayer.transform.position);
        if(distance<1.0f)
        {
            isPickUp = true;
        }
        if (isPickUp)
        {
            FllowPlayer();
        }

        if (distance < 0.2f)
        {
            GlobalPlayerAttribute.BloodEnergy++; // 增加元灵数量
            StoreController.S.SaveStoreData();
            gameObject.SetActive(false);
            GameController.S.BloodEnergyQueue.Enqueue(gameObject);
        }
    }

    void FllowPlayer()
    {
        //血能跟随Player
        transform.position = Vector3.Lerp(transform.position, GameController.S.gamePlayer.transform.position, Time.deltaTime * speed);

    }
}
