namespace Equip
{
    //怪物掉落装备的基本属性
    public class MonsterEquip
    {

        public PlayerEquipConfig.EquipType EquipType;
        public PlayerEquipConfig.EquipLevel EquipLevel;
        public int Probability;

        public MonsterEquip(PlayerEquipConfig.EquipType equipType, PlayerEquipConfig.EquipLevel equipLevel, int probability)
        {
            EquipType = equipType;
            EquipLevel = equipLevel;
            Probability = probability;
        }
    }
}