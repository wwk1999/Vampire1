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
    
    //Resource绿色套装
    public static Sprite GreenCloth;
    public static Sprite GreenCloak;
    public static Sprite GreenShoe;
    public static Sprite GreenHelmet;
    public static Sprite GreenRing;
    public static Sprite GreenNecklace;
    
    //Resource蓝色套装
    public static Sprite BlueCloth;
    public static Sprite BlueCloak;
    public static Sprite BlueShoe;
    public static Sprite BlueHelmet;
    public static Sprite BlueRing;
    public static Sprite BlueNecklace;
    
    // Resource树人套装
    public static Sprite TreeManCloth;
    public static Sprite TreeManCloak;
    public static Sprite TreeManShoe;
    public static Sprite TreeManHelmet;
    public static Sprite TreeManRing;
    public static Sprite TreeManNecklace;
    
    // Resource火山套装
    public static Sprite HuoShanCloth;
    public static Sprite HuoShanCloak;
    public static Sprite HuoShanShoe;
    public static Sprite HuoShanHelmet;
    public static Sprite HuoShanRing;
    public static Sprite HuoShanNecklace;
    
    // Resource沼泽套装
    public static Sprite ZhaoZeCloth;
    public static Sprite ZhaoZeCloak;
    public static Sprite ZhaoZeShoe;
    public static Sprite ZhaoZeHelmet;
    public static Sprite ZhaoZeRing;
    public static Sprite ZhaoZeNecklace;
    
    // Resource武器源石
    public static Sprite WhiteDivision;
    public static Sprite WhiteDuration;
    public static Sprite WhiteExplosion;
    public static Sprite WhiteExtremeSpeed;
    public static Sprite WhitePenetrate;
    public static Sprite WhiteScale;
    
    public static Sprite GreenDivision;
    public static Sprite GreenDuration;
    public static Sprite GreenExplosion;
    public static Sprite GreenExtremeSpeed;
    public static Sprite GreenPenetrate;
    public static Sprite GreenScale;
    
    public static Sprite BlueDivision;
    public static Sprite BlueDuration;
    public static Sprite BlueExplosion;
    public static Sprite BlueExtremeSpeed;
    public static Sprite BluePenetrate;
    public static Sprite BlueScale;
    
    public static Sprite PurpleDivision;
    public static Sprite PurpleDuration;
    public static Sprite PurpleExplosion;
    public static Sprite PurpleExtremeSpeed;
    public static Sprite PurplePenetrate;
    public static Sprite PurpleScale;
    
    public static Sprite OrangeDivision;
    public static Sprite OrangeDuration;
    public static Sprite OrangeExplosion;
    public static Sprite OrangeExtremeSpeed;
    public static Sprite OrangePenetrate;
    public static Sprite OrangeScale;
    
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
    
    //颜色背景
    public static Material WhiteMaterial;
    public static Material GreenMaterial;
    public static Material BlueMaterial;
    public static Material PurpleMaterial;
    public static Material OrangeMaterial;
    
    //武器
    public static Sprite OneWeapon;
    public static Sprite TwoWeapon;
    public static Sprite ThreeWeapon;
    public static Sprite FourWeapon;



    public static void Init()
    {
        //武器
        OneWeapon = Resources.Load<Sprite>("Sprite/Weapon/OneWeapon");
        TwoWeapon = Resources.Load<Sprite>("Sprite/Weapon/TwoWeapon");
        ThreeWeapon = Resources.Load<Sprite>("Sprite/Weapon/ThreeWeapon");
        FourWeapon = Resources.Load<Sprite>("Sprite/Weapon/FourWeapon");
        //颜色背景
        WhiteBg= Resources.Load<Sprite>("Sprite/ColorBg/EquipWhiteBG");
        GreenBg= Resources.Load<Sprite>("Sprite/ColorBg/EquipGreenBG");
        BlueBg= Resources.Load<Sprite>("Sprite/ColorBg/EquipBlueBG");
        PurpleBg= Resources.Load<Sprite>("Sprite/ColorBg/EquipPurpleBG");
        OrangeBg= Resources.Load<Sprite>("Sprite/ColorBg/EquipOrangeBG");
        
        WhiteMaterial= Resources.Load<Material>("Material/EquipOutline/WhiteEquipOutline");
        GreenMaterial= Resources.Load<Material>("Material/EquipOutline/GreenEquipOutline");
        BlueMaterial= Resources.Load<Material>("Material/EquipOutline/BlueEquipOutline");
        PurpleMaterial= Resources.Load<Material>("Material/EquipOutline/PurpleEquipOutline");
        OrangeMaterial= Resources.Load<Material>("Material/EquipOutline/OrangeEquipOutline");
        
        
        //新手套装
        PrimaryCloth= Resources.Load<Sprite>("Sprite/Equip/PrimaryCloth");
        PrimaryCloak = Resources.Load<Sprite>("Sprite/Equip/PrimaryCloak");
        PrimaryShoe = Resources.Load<Sprite>("Sprite/Equip/PrimaryShoe");
        PrimaryHelmet = Resources.Load<Sprite>("Sprite/Equip/PrimaryHelmet");
        PrimaryRing = Resources.Load<Sprite>("Sprite/Equip/PrimaryRing");
        PrimaryNecklace = Resources.Load<Sprite>("Sprite/Equip/PrimaryNecklace");
        
        //绿色套装
        GreenCloth= Resources.Load<Sprite>("Sprite/Equip/GreenCloth");
        GreenCloak = Resources.Load<Sprite>("Sprite/Equip/GreenCloak");
        GreenShoe = Resources.Load<Sprite>("Sprite/Equip/GreenShoe");
        GreenHelmet = Resources.Load<Sprite>("Sprite/Equip/GreenHelmet");
        GreenRing = Resources.Load<Sprite>("Sprite/Equip/GreenRing");
        GreenNecklace = Resources.Load<Sprite>("Sprite/Equip/GreenNecklace");
        
        //蓝色套装
        BlueCloth= Resources.Load<Sprite>("Sprite/Equip/BlueCloth");
        BlueCloak = Resources.Load<Sprite>("Sprite/Equip/BlueCloak");
        BlueShoe = Resources.Load<Sprite>("Sprite/Equip/BlueShoe");
        BlueHelmet = Resources.Load<Sprite>("Sprite/Equip/BlueHelmet");
        BlueRing = Resources.Load<Sprite>("Sprite/Equip/BlueRing");
        BlueNecklace = Resources.Load<Sprite>("Sprite/Equip/BlueNecklace");
        
        //树人套装
        TreeManCloth = Resources.Load<Sprite>("Sprite/Equip/TreeManCloth");
        TreeManCloak = Resources.Load<Sprite>("Sprite/Equip/TreeManCloak");
        TreeManShoe = Resources.Load<Sprite>("Sprite/Equip/TreeManShoe");
        TreeManHelmet = Resources.Load<Sprite>("Sprite/Equip/TreeManHelmet");
        TreeManRing = Resources.Load<Sprite>("Sprite/Equip/TreeManRing");
        TreeManNecklace = Resources.Load<Sprite>("Sprite/Equip/TreeManNecklace");
        
        //火山套装
        HuoShanCloth = Resources.Load<Sprite>("Sprite/Equip/HuoShanCloth");
        HuoShanCloak = Resources.Load<Sprite>("Sprite/Equip/HuoShanCloak");
        HuoShanShoe = Resources.Load<Sprite>("Sprite/Equip/HuoShanShoe");
        HuoShanHelmet = Resources.Load<Sprite>("Sprite/Equip/HuoShanHelmet");
        HuoShanRing = Resources.Load<Sprite>("Sprite/Equip/HuoShanRing");
        HuoShanNecklace = Resources.Load<Sprite>("Sprite/Equip/HuoShanNecklace");
        
        //沼泽套装
        ZhaoZeCloth= Resources.Load<Sprite>("Sprite/Equip/ZhaoZeCloth");
        ZhaoZeCloak = Resources.Load<Sprite>("Sprite/Equip/ZhaoZeCloak");
        ZhaoZeShoe = Resources.Load<Sprite>("Sprite/Equip/ZhaoZeShoe");
        ZhaoZeHelmet = Resources.Load<Sprite>("Sprite/Equip/ZhaoZeHelmet");
        ZhaoZeRing = Resources.Load<Sprite>("Sprite/Equip/ZhaoZeRing");
        ZhaoZeNecklace = Resources.Load<Sprite>("Sprite/Equip/ZhaoZeNecklace");
        
        //武器源石
        WhiteDivision = Resources.Load<Sprite>("Sprite/WeaponSourceStone/WhiteDivision");
        WhiteDuration = Resources.Load<Sprite>("Sprite/WeaponSourceStone/WhiteDuration");
        WhiteExplosion = Resources.Load<Sprite>("Sprite/WeaponSourceStone/WhiteExplosion");
        WhiteExtremeSpeed = Resources.Load<Sprite>("Sprite/WeaponSourceStone/WhiteExtremeSpeed");
        WhitePenetrate = Resources.Load<Sprite>("Sprite/WeaponSourceStone/WhitePenetrate");
        WhiteScale = Resources.Load<Sprite>("Sprite/WeaponSourceStone/WhiteScale");
        
        // GreenDivision = Resources.Load<Sprite>("Sprite/WeaponSourceStone/GreenDivision");
        // GreenDuration = Resources.Load<Sprite>("Sprite/WeaponSourceStone/GreenDuration");
        // GreenExplosion = Resources.Load<Sprite>("Sprite/WeaponSourceStone/GreenExplosion");
        // GreenExtremeSpeed = Resources.Load<Sprite>("Sprite/WeaponSourceStone/GreenExtremeSpeed");
        // GreenPenetrate = Resources.Load<Sprite>("Sprite/WeaponSourceStone/GreenPenetrate");
        // GreenScale = Resources.Load<Sprite>("Sprite/WeaponSourceStone/GreenScale");
        //
        // BlueDivision = Resources.Load<Sprite>("Sprite/WeaponSourceStone/BlueDivision");
        // BlueDuration = Resources.Load<Sprite>("Sprite/WeaponSourceStone/BlueDuration");
        // BlueExplosion = Resources.Load<Sprite>("Sprite/WeaponSourceStone/BlueExplosion");
        // BlueExtremeSpeed = Resources.Load<Sprite>("Sprite/WeaponSourceStone/BlueExtremeSpeed");
        // BluePenetrate = Resources.Load<Sprite>("Sprite/WeaponSourceStone/BluePenetrate");
        // BlueScale = Resources.Load<Sprite>("Sprite/WeaponSourceStone/BlueScale");
        //
        // PurpleDivision = Resources.Load<Sprite>("Sprite/WeaponSourceStone/PurpleDivision");
        // PurpleDuration = Resources.Load<Sprite>("Sprite/WeaponSourceStone/PurpleDuration");
        // PurpleExplosion = Resources.Load<Sprite>("Sprite/WeaponSourceStone/PurpleExplosion");
        // PurpleExtremeSpeed = Resources.Load<Sprite>("Sprite/WeaponSourceStone/PurpleExtremeSpeed");
        // PurplePenetrate = Resources.Load<Sprite>("Sprite/WeaponSourceStone/PurplePenetrate");
        // PurpleScale = Resources.Load<Sprite>("Sprite/WeaponSourceStone/PurpleScale");
        //
        // OrangeDivision = Resources.Load<Sprite>("Sprite/WeaponSourceStone/OrangeDivision");
        // OrangeDuration = Resources.Load<Sprite>("Sprite/WeaponSourceStone/OrangeDuration");
        // OrangeExplosion = Resources.Load<Sprite>("Sprite/WeaponSourceStone/OrangeExplosion");
        // OrangeExtremeSpeed = Resources.Load<Sprite>("Sprite/WeaponSourceStone/OrangeExtremeSpeed");
        // OrangePenetrate = Resources.Load<Sprite>("Sprite/WeaponSourceStone/OrangePenetrate");
        // OrangeScale = Resources.Load<Sprite>("Sprite/WeaponSourceStone/OrangeScale");
        
        
        
        //关卡界面怪物icon
        SnotIcon = Resources.Load<Sprite>("Sprite/LevelMonsterIcon/Snot");
        BatIcon = Resources.Load<Sprite>("Sprite/LevelMonsterIcon/Bat");
        Spidericon = Resources.Load<Sprite>("Sprite/LevelMonsterIcon/Spider");
        EliteBeeIcon = Resources.Load<Sprite>("Sprite/LevelMonsterIcon/EliteBee");
        BossTreeManIcon = Resources.Load<Sprite>("Sprite/LevelMonsterIcon/BossTreeMan");
    }

    public static Sprite GetEquipSprite(EquipTable equipTable)
    {
        switch (equipTable.suitid)
        {
            case 1:
                switch (equipTable.Quality)
                {
                    case 1:
                        switch (equipTable.equip_type_id)
                        {
                            case 1:
                                return PrimaryCloak;
                            case 2:
                                return PrimaryCloth;
                            case 3:
                                return PrimaryHelmet;
                            case 4:
                                return PrimaryNecklace;
                            case 5:
                                return PrimaryRing;
                            case 6:
                                return PrimaryShoe;
                        }
                        break;
                }
                break;
            case 2:
                switch (equipTable.equip_type_id)
                {
                    case 1:
                        return GreenCloak;
                    case 2:
                        return GreenCloth;
                    case 3:
                        return GreenHelmet;
                    case 4:
                        return GreenNecklace;
                    case 5:
                        return GreenRing;
                    case 6:
                        return GreenShoe;
                }
                break;
            
            case 3:
                switch (equipTable.equip_type_id)
                {
                    case 1:
                        return BlueCloak;
                    case 2:
                        return BlueCloth;
                    case 3:
                        return BlueHelmet;
                    case 4:
                        return BlueNecklace;
                    case 5:
                        return BlueRing;
                    case 6:
                        return BlueShoe;
                }
                break;
            case 101:
                switch (equipTable.equip_type_id)
                {
                    case 1:
                        return TreeManCloak;
                    case 2:
                        return TreeManCloth;
                    case 3:
                        return TreeManHelmet;
                    case 4:
                        return TreeManNecklace;
                    case 5:
                        return TreeManRing;
                    case 6:
                        return TreeManShoe;
                }
                break;
            case 102:
                switch (equipTable.equip_type_id)
                {
                    case 1:
                        return HuoShanCloak;
                    case 2:
                        return HuoShanCloth;
                    case 3:
                        return HuoShanHelmet;
                    case 4:
                        return HuoShanNecklace;
                    case 5:
                        return HuoShanRing;
                    case 6:
                        return HuoShanShoe;
                }
                break;
            
            case 103:
                switch (equipTable.equip_type_id)
                {
                    case 1:
                        return ZhaoZeCloak;
                    case 2:
                        return ZhaoZeCloth;
                    case 3:
                        return ZhaoZeHelmet;
                    case 4:
                        return ZhaoZeNecklace;
                    case 5:
                        return ZhaoZeRing;
                    case 6:
                        return ZhaoZeShoe;
                }
                break;
        }
        return null;
    }
}
