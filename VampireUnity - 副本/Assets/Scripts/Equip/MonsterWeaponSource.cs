using System;

namespace Equip
{
    public class MonsterWeaponSource
    {
        [NonSerialized]public WeaponSourceStoneQuality Quality;
        [NonSerialized]public WeaponSourceStoneType SourceStoneType;
        public int Probability;
        public MonsterWeaponSource(WeaponSourceStoneQuality quality, WeaponSourceStoneType sourceStoneType, int probability)
        {
            Quality = quality;
            SourceStoneType = sourceStoneType;
            Probability = probability;
        }
        
    }
}