using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesConfig : MonoBehaviour
{
    //Resource新手套装
    public static Sprite PrimaryCloth;
    public static Sprite PrimaryCloak;
    public static Sprite PrimaryShoe;
    public static Sprite PrimaryHelmet;
    public static Sprite PrimaryRing;
    public static Sprite PrimaryNecklace;
    
    // Resource树人套装
    public static Sprite TreeManCloth;
    public static Sprite TreeManCloak;
    public static Sprite TreeManShoe;
    public static Sprite TreeManHelmet;
    public static Sprite TreeManRing;
    public static Sprite TreeManNecklace;
    
    // Resource武器源石
    public static Sprite Division;
    public static Sprite Duration;
    public static Sprite Explosion;
    public static Sprite ExtremeSpeed;
    public static Sprite Penetrate;
    public static Sprite Scale;
    
    //关卡界面怪物icon
    public static Sprite SnotIcon;
    public static Sprite BatIcon;
    public static Sprite Spidericon;
    public static Sprite EliteBeeIcon;
    public static Sprite BossTreeManIcon;
    
    //颜色背景
    public static Sprite WhiteBg;
    public static Sprite GreenBg;
    public static Sprite BlueBg;
    public static Sprite PurpleBg;
    public static Sprite OrangeBg;




    public static void Init()
    {
        //颜色背景
        WhiteBg= Resources.Load<Sprite>("Sprite/EquipWhiteBG");
        GreenBg= Resources.Load<Sprite>("Sprite/EquipGreenBG");
        BlueBg= Resources.Load<Sprite>("Sprite/EquipBlueBG");
        PurpleBg= Resources.Load<Sprite>("Sprite/EquipPurpleBG");
        OrangeBg= Resources.Load<Sprite>("Sprite/EquipOrangeBG");
        
        //新手套装
        PrimaryCloth= Resources.Load<Sprite>("Sprite/Equip/PrimaryCloth");
        PrimaryCloak = Resources.Load<Sprite>("Sprite/Equip/PrimaryCloak");
        PrimaryShoe = Resources.Load<Sprite>("Sprite/Equip/PrimaryShoe");
        PrimaryHelmet = Resources.Load<Sprite>("Sprite/Equip/PrimaryHelmet");
        PrimaryRing = Resources.Load<Sprite>("Sprite/Equip/PrimaryRing");
        PrimaryNecklace = Resources.Load<Sprite>("Sprite/Equip/PrimaryNecklace");
        
        //树人套装
        TreeManCloth = Resources.Load<Sprite>("Sprite/Equip/TreeManCloth");
        TreeManCloak = Resources.Load<Sprite>("Sprite/Equip/TreeManCloak");
        TreeManShoe = Resources.Load<Sprite>("Sprite/Equip/TreeManShoe");
        TreeManHelmet = Resources.Load<Sprite>("Sprite/Equip/TreeManHelmet");
        TreeManRing = Resources.Load<Sprite>("Sprite/Equip/TreeManRing");
        TreeManNecklace = Resources.Load<Sprite>("Sprite/Equip/TreeManNecklace");
        
        //武器源石
        Division = Resources.Load<Sprite>("Sprite/WeaponSourceStone/Division");
        Duration = Resources.Load<Sprite>("Sprite/WeaponSourceStone/Duration");
        Explosion = Resources.Load<Sprite>("Sprite/WeaponSourceStone/Explosion");
        ExtremeSpeed = Resources.Load<Sprite>("Sprite/WeaponSourceStone/ExtremeSpeed");
        Penetrate = Resources.Load<Sprite>("Sprite/WeaponSourceStone/Penetrate");
        Scale = Resources.Load<Sprite>("Sprite/WeaponSourceStone/Scale");
        
        //关卡界面怪物icon
        SnotIcon = Resources.Load<Sprite>("Sprite/LevelMonsterIcon/Snot");
        BatIcon = Resources.Load<Sprite>("Sprite/LevelMonsterIcon/Bat");
        Spidericon = Resources.Load<Sprite>("Sprite/LevelMonsterIcon/Spider");
        EliteBeeIcon = Resources.Load<Sprite>("Sprite/LevelMonsterIcon/EliteBee");
        BossTreeManIcon = Resources.Load<Sprite>("Sprite/LevelMonsterIcon/BossTreeMan");
    }
}
