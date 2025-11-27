using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class PlayerData : XSingleton<PlayerData>
{
    public  int level=1;
    public int exp=0;
    public int bloodEnergy=0;
    public int maxGameLevel=1;
    
    public int clothid;
    public int cloakid;
    public int helmetid;
    public int ringid;
    public int shoeid;
    public int necklaceid;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void SaveWearEquip(int equipType, int equipid)
    {
        switch (equipType)
        {
            case 1:
                cloakid = equipid;
                break;
            case 2:
                clothid = equipid;
                break;
            case 3:
                helmetid = equipid;
                break;
            case 4:
                necklaceid = equipid;
                break;
            case 5:
                ringid = equipid;
                break;
            case 6:
                shoeid = equipid;
                break;
        }
    }
}
