using System;
using UnityEngine;

public class BloodEnergyController : MonoBehaviour
{
    public float speed = 5f; // 血能跟随的速度
    public bool isPickUp = false; // 是否被拾取
    private void OnTriggerEnter2D(Collider2D other)
    {
//        Debug.Log("other.gameObject.name");
        if (other.CompareTag("PickUp"))
        {
            isPickUp= true;
        }else if (other.CompareTag("Player"))
        {
            GlobalPlayerAttribute.BloodEnergy++; // 增加元灵数量
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isPickUp)
        {
            FllowPlayer();
        }
    }

    void FllowPlayer()
    {
        //血能跟随Player
        transform.position = Vector3.Lerp(transform.position, GameController.S.gamePlayer.transform.position, Time.deltaTime * speed);

    }
}
