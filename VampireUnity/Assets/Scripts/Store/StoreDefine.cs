using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreDefine : XSingleton<StoreDefine>
{
   
    public class StoreData
    {
        private EquipData _equipData=new EquipData();
        private PlayData _playData=new PlayData();
    }

    public class EquipData
    {
        private List<int> _equipId=new List<int>();
    }
    public class PlayData
    {
        private int _level;
        private int _exp;
        private int _bloodEnergy;
        private int _gameLevel;
    }
}
