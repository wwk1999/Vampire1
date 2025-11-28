using System;
using System.Collections;
using Equip;
using Mysql;
using UnityEngine;

public enum SuitType
{
    None,
    TreeMan,
    HuoShan
}
public class EquipBase : BagObjectBase
{
    [NonSerialized]public Rigidbody2D equipRb;
   [NonSerialized]public string equipName;//装备名字
   [NonSerialized]public EquipTable EquipAttributes; // 装备属性
    [NonSerialized]public float speed = 5f; // 装备跟随的速度
    [NonSerialized]public bool isPickUp = false; // 是否被拾取
    [NonSerialized]public SpriteRenderer SpriteRenderer;
    [NonSerialized]public SuitType suitType = SuitType.None; // 装备套装类型
    
    [NonSerialized]private Coroutine floatEffectCoroutine; // 添加协程引用

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public EquipBase(string equipName,SuitType suitType,EquipTable equipAttribute)
    {
        this.equipName = equipName;
        this.suitType = suitType;
        this.EquipAttributes = equipAttribute;
    }
    void OnEnable()
    {
        bagObjectType = BagObjectType.Equip;
        equipRb=GetComponent<Rigidbody2D>();
        equipRb.velocity = new Vector2(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(3f, 5f));

        StartCoroutine(StopVelocityAfterDelay(equipRb, 0.75f));
    }

    // Update is called once per frame
    private IEnumerator StopVelocityAfterDelay(Rigidbody2D rb, float delay)
    {
        yield return new WaitForSeconds(delay);
        if(rb == null)
            Debug.Log("rb为空");
        rb.velocity = Vector2.zero;
        //设置重力为0
        rb.gravityScale = 0;
        //开启协程通过transformer让装备上下浮动效果,lerp平滑过渡
        floatEffectCoroutine =StartCoroutine(FloatEffect());
        
    }
    
    private IEnumerator FloatEffect()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + new Vector3(0, 0.2f, 0);
        float duration = 0.8f; // 浮动持续时间

        while (true)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.PingPong(elapsedTime / duration, 1f);
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, GameController.S.gamePlayer.transform.position);
        if (distance < 1.0f)
        {
              isPickUp = true;
        }
        if (isPickUp)
        {
            transform.position = Vector3.Lerp(transform.position, GameController.S.gamePlayer.transform.position,
                Time.deltaTime * speed);
            if (floatEffectCoroutine != null)
            {
                StopCoroutine(floatEffectCoroutine);
                floatEffectCoroutine = null;
            }
        }

        if (distance < 0.2f)
        {
            Debug.Log("名字："+EquipAttributes.EquipName);
            //将这件装备的属性添加到数据库
            EquipIDData.S.SavaEquip(EquipAttributes);
            StoreController.S.SaveStoreData();
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowToast,EquipAttributes);
            

            //如果被拾取，销毁装备
            gameObject.SetActive(false);
            EnEquipQueue(EquipAttributes);
        }
    }


    public void EnEquipQueue(EquipTable equipAttributes)
    {
        switch (equipAttributes.equip_type_id)
        {
            case 1:
                switch (equipAttributes.suitid)
                {
                    case 1:
                        GameController.S.PrimaryCloakQueue.Enqueue(gameObject);
                        break;
                    case 2:
                        GameController.S.GreenCloakQueue.Enqueue(gameObject);
                        break;
                    case 3:
                        GameController.S.BlueCloakQueue.Enqueue(gameObject);
                        break;
                    case 101:
                        GameController.S.TreeManCloakQueue.Enqueue(gameObject);
                        break;
                    case 102:
                        GameController.S.HuoShanCloakQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
            case 2:
                switch (equipAttributes.suitid)
                {
                    case 1:
                        GameController.S.PrimaryClothQueue.Enqueue(gameObject);
                        break;
                    case 2:
                        GameController.S.GreenClothQueue.Enqueue(gameObject);
                        break;
                    case 3:
                        GameController.S.BlueClothQueue.Enqueue(gameObject);
                        break;
                    case 101:
                        GameController.S.TreeManClothQueue.Enqueue(gameObject);
                        break;
                    case 102:
                        GameController.S.HuoShanClothQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
            case 3:
                switch (equipAttributes.suitid)
                {
                    case 1:
                        GameController.S.PrimaryHelmetQueue.Enqueue(gameObject);
                        break;
                    case 2:
                        GameController.S.GreenHelmetQueue.Enqueue(gameObject);
                        break;
                    case 3:
                        GameController.S.BlueHelmetQueue.Enqueue(gameObject);
                        break;
                    case 101:
                        GameController.S.TreeManHelmetQueue.Enqueue(gameObject);
                        break;
                    case 102:
                        GameController.S.HuoShanHelmetQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
            case 4:
                switch (equipAttributes.suitid)
                {
                    case 1:
                        GameController.S.PrimaryNecklaceQueue.Enqueue(gameObject);
                        break;
                    case 2:
                        GameController.S.GreenNecklaceQueue.Enqueue(gameObject);
                        break;
                    case 3:
                        GameController.S.BlueNecklaceQueue.Enqueue(gameObject);
                        break;
                    case 101:
                        GameController.S.TreeManNecklaceQueue.Enqueue(gameObject);
                        break;
                    case 102:
                        GameController.S.HuoShanNecklaceQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
            case 5:
                switch (equipAttributes.suitid)
                {
                    case 1:
                        GameController.S.PrimaryRingQueue.Enqueue(gameObject);
                        break;
                    case 2:
                        GameController.S.GreenRingQueue.Enqueue(gameObject);
                        break;
                    case 3:
                        GameController.S.BlueRingQueue.Enqueue(gameObject);
                        break;
                    case 101:
                        GameController.S.TreeManRingQueue.Enqueue(gameObject);
                        break;
                    case 102:
                        GameController.S.HuoShanRingQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
            case 6:
                switch (equipAttributes.suitid)
                {
                    case 1:
                        GameController.S.PrimaryShoeQueue.Enqueue(gameObject);
                        break;
                    case 2:
                        GameController.S.GreenShoeQueue.Enqueue(gameObject);
                        break;
                    case 3:
                        GameController.S.BlueShoeQueue.Enqueue(gameObject);
                        break;
                    case 101:
                        GameController.S.TreeManShoeQueue.Enqueue(gameObject);
                        break;
                    case 102:
                        GameController.S.HuoShanShoeQueue.Enqueue(gameObject);
                        break;
                }
                break;
        }
    }
}
