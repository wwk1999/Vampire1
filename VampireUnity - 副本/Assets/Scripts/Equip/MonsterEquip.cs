namespace Equip
{
    //怪物掉落装备的基本属性
    public class MonsterEquip
    {
        public string Name;
        public int Probability;

        public MonsterEquip(string name, int probability)
        {
            Name = name;
            Probability = probability;
        }
    }
}