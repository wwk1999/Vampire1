using System.Collections.Generic;

namespace Equip
{
    public class FightEquipAttribute
    {
        public EquipQuality EquipQuality;
        public Dictionary<EquipAttribute,int> Attributes = new Dictionary<EquipAttribute,int>();
        
    }
}