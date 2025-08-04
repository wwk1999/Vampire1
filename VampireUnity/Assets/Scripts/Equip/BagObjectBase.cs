using System;
using UnityEngine;
public enum BagObjectType
{
    None,
    WeaponSourceStone,
    Equip
}
public class BagObjectBase : MonoBehaviour
{
   [NonSerialized]public BagObjectType bagObjectType;
}
