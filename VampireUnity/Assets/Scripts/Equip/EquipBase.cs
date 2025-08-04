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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public EquipBase(string equipName,SuitType suitType,EquipTable equipAttribute)
    {
        this.equipName = equipName;
        this.suitType = suitType;
        this.EquipAttributes = equipAttribute;
    }
    void Start()
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
    }

    private void Update()
    {
        if(isPickUp)
            transform.position = Vector3.Lerp(transform.position, GameController.S.gamePlayer.transform.position, Time.deltaTime * speed);
    }
}
