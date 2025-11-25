using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : XSingleton<PlayerData>
{
    public  int level=1;
    public int exp=0;
    public int bloodEnergy=0;
    public int gameLevel=1;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
