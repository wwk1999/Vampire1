using System;
using System.Collections.Generic;
using Gloabl;
using Mysql;
using MySqlConnector;
using Tool;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BagController : XSingleton<BagController>
{
    [NonSerialized]public bool IsInit = false;
    [NonSerialized] public Dictionary<string, Sprite>EquipidSpriteConfig = new Dictionary<string, Sprite>(); //装备的Sprite配置
    [NonSerialized] public Dictionary<int, Sprite> EquipidSprite = new Dictionary<int, Sprite>(); //背包里所有的装备的Sprite
    [NonSerialized] public Dictionary<int, EquipTable> EquipidTable = new Dictionary<int, EquipTable>(); //背包里所有的装备的属性
    [NonSerialized] public List<TableBase> EquipIdList = new List<TableBase>();//翻页
    
    [NonSerialized] public Dictionary<int, EquipTable> WhiteEquipidTable = new Dictionary<int, EquipTable>(); //背包里所有的白色装备
    [NonSerialized] public Dictionary<int, EquipTable> GreenEquipidTable = new Dictionary<int, EquipTable>(); //背包里所有的绿色装备
    [NonSerialized] public Dictionary<int, EquipTable> BlueEquipidTable = new Dictionary<int, EquipTable>(); //背包里所有的蓝色色装备
    [NonSerialized] public Dictionary<int, EquipTable> PurpleEquipidTable = new Dictionary<int, EquipTable>(); //背包里所有的紫色色装备
    [NonSerialized] public Dictionary<int, EquipTable> OrangeEquipidTable = new Dictionary<int, EquipTable>(); //背包里所有的橙色装备
    
    //源石相关
    [NonSerialized] public Dictionary<int, Sprite> SourceStoneSpriteConfig = new Dictionary<int, Sprite>(); //源石的Sprite，int是源石类型
    [NonSerialized]public Dictionary<int,SourceStoneTable>SourceStoneTable = new Dictionary<int,SourceStoneTable>();//int时equipid
    
    [NonSerialized] public Dictionary<int, SourceStoneTable> WhiteWeaponSourceStoneTable = new Dictionary<int, SourceStoneTable>(); //背包里所有的白色源石
    [NonSerialized] public Dictionary<int, SourceStoneTable> GreenWeaponSourceStoneTable = new Dictionary<int, SourceStoneTable>(); //背包里所有的绿色源石
    [NonSerialized] public Dictionary<int, SourceStoneTable> BlueWeaponSourceStoneTable = new Dictionary<int, SourceStoneTable>(); //背包里所有的蓝色源石
    [NonSerialized] public Dictionary<int, SourceStoneTable> PurpleWeaponSourceStoneTable = new Dictionary<int, SourceStoneTable>(); //背包里所有的紫色源石
    [NonSerialized] public Dictionary<int, SourceStoneTable> OrangeWeaponSourceStoneTable = new Dictionary<int, SourceStoneTable>(); //背包里所有的橙色源石
    
    
    
    [NonSerialized] public Dictionary<string,int> MaxEquipid = new Dictionary<string,int>();//存储最大的装备ID

    

    // //数据库里的装备，暂时获取所有装备，后面要换成获取自己userid的装备
    // [NonSerialized] public Dictionary<int, EquipTable> MysqlEquipDic = new Dictionary<int, EquipTable>();
    [NonSerialized] public GameObject bagGrid; //背包格子
    [NonSerialized] public GameObject bag; //背包
    [NonSerialized] public GameObject MaskLayer; //蒙层
    [NonSerialized] public bool IsShowPlayerPanel = true;
    [NonSerialized] public GameObject PlayerPanel; //玩家面板
    [NonSerialized] public GameObject AttributePanel; //属性面板
    public GameObject playerCloth; //玩家面板的衣服
    public GameObject playerCloak; //玩家面板的披风
    public GameObject playerRing;
    public GameObject playerNecklace;
    public GameObject playerShoe;
    public GameObject playerHelmet;
    [NonSerialized] private bool IsInstallCloth = false; //是否穿了衣服
    [NonSerialized] private bool IsInstallCloak = false;
    [NonSerialized] private bool IsInstallRing = false;
    [NonSerialized] private bool IsInstallNecklace = false;
    [NonSerialized] private bool IsInstallShoe = false;
    [NonSerialized] private bool IsInstallHelmet = false;
    [NonSerialized] public  int PageNum = 1;//第几页   
    
    
    //装备颜色背景的sprite
    public Sprite whiteBg;
    public Sprite greenBg;
    public Sprite blueBg;
    public Sprite purpleBg;
    public Sprite orangeBg;

    
    //player穿的装备的属性
    [NonSerialized] public EquipTable PlayerClothAttribute=new EquipTable();
    [NonSerialized] public EquipTable PlayerCloakAttribute=new EquipTable();
    [NonSerialized] public EquipTable PlayerRingAttribute=new EquipTable();
    [NonSerialized] public EquipTable PlayerNecklaceAttribute=new EquipTable();
    [NonSerialized] public EquipTable PlayerShoeAttribute=new EquipTable();
    [NonSerialized] public EquipTable PlayerHelmetAttribute=new EquipTable();
    




    protected override void Awake()
    {
        Debug.Log("BagController Awake方法被调用");
        InitBag();
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 场景加载后重新初始化UI
       // InitBag();
    }

    public void InitBag()
    {
        Debug.Log("开始执行InitBag方法");
        
        // 加载装备背景图
        Debug.Log("正在加载装备背景图");
        whiteBg = Resources.Load<Sprite>("Sprite/EquipWhiteBG");
        greenBg = Resources.Load<Sprite>("Sprite/EquipGreenBG");
        blueBg = Resources.Load<Sprite>("Sprite/EquipBlueBG");
        purpleBg = Resources.Load<Sprite>("Sprite/EquipPurpleBG");
        orangeBg = Resources.Load<Sprite>("Sprite/EquipOrangeBG");
        
        // 检查装备背景图是否加载成功
        if (whiteBg == null || greenBg == null || blueBg == null || purpleBg == null || orangeBg == null)
        {
            Debug.LogError($"InitBag出错: 装备背景图加载失败，whiteBg: {whiteBg != null}, greenBg: {greenBg != null}, blueBg: {blueBg != null}, purpleBg: {purpleBg != null}, orangeBg: {orangeBg != null}");
        }

        // 查找UIRoot
        Debug.Log("正在查找UIRoot对象");
        GameObject uiRoot = GameObject.Find("UIRoot");
        if (uiRoot == null)
        {
            Debug.LogError("InitBag出错: 找不到UIRoot对象");
            return;
        }
        
        Debug.Log("找到UIRoot对象");

        // 加载背包预制体
        Debug.Log("正在加载背包预制体");
        GameObject bagPrefab = Resources.Load("Prefabs/Window/Bag") as GameObject;
        if (bagPrefab == null)
        {
            Debug.LogError("InitBag出错: 无法加载背包预制体");
            return;
        }
        
        // 销毁旧的背包UI
        if (bag != null)
        {
            Debug.Log("销毁旧的背包UI");
            Destroy(bag.gameObject);
        }
        
        // 实例化新的背包UI
        Debug.Log("实例化新的背包UI");
        try
        {
            bag = Instantiate(bagPrefab);
            bag.gameObject.SetActive(false);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"InitBag出错: 实例化背包UI失败: {e.Message}\n{e.StackTrace}");
            return;
        }
        
        // 加载背包格子预制体
        Debug.Log("加载背包格子预制体");
        bagGrid = Resources.Load("Prefabs/Equip/BagGrid") as GameObject;
        if (bagGrid == null)
        {
            Debug.LogError("InitBag出错: 无法加载背包格子预制体");
        }
        
        // 查找背包内的组件
        Debug.Log("查找背包内的组件");
        try
        {
            PlayerPanel = bag.transform.Find("BagPanel").Find("PlayerPanel").gameObject;
            if (PlayerPanel == null)
            {
                Debug.LogError("InitBag出错: 找不到PlayerPanel");
            }
            
            AttributePanel = bag.transform.Find("BagPanel").Find("AttributePanel").gameObject;
            if (AttributePanel == null)
            {
                Debug.LogError("InitBag出错: 找不到AttributePanel");
            }
            
            playerCloth = bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Cloth").gameObject;
            playerCloak = bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Cloak").gameObject;
            playerRing = bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Ring").gameObject;
            playerNecklace = bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Necklace").gameObject;
            playerShoe = bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Shoe").gameObject;
            playerHelmet = bag.transform.Find("BagPanel").Find("PlayerPanel").Find("Helmet").gameObject;
            
            if (playerCloth == null || playerCloak == null || playerRing == null || 
                playerNecklace == null || playerShoe == null || playerHelmet == null)
            {
                Debug.LogError($"InitBag出错: 装备槽对象缺失，playerCloth: {playerCloth != null}, playerCloak: {playerCloak != null}, playerRing: {playerRing != null}, playerNecklace: {playerNecklace != null}, playerShoe: {playerShoe != null}, playerHelmet: {playerHelmet != null}");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"InitBag出错: 查找背包组件时发生异常: {e.Message}\n{e.StackTrace}");
        }
        
        // 初始化装备图标配置
        Debug.Log("初始化装备图标配置");
        try
        {
            InitEquipidSpriteConfig();
        }
        catch (System.Exception e)
        {
            Debug.LogError($"InitBag出错: 初始化装备图标配置失败: {e.Message}\n{e.StackTrace}");
        }
        
        // 初始化源石图标配置
        Debug.Log("初始化源石图标配置");
        try
        {
            InitSourceStoneSpriteConfig();
        }
        catch (System.Exception e)
        {
            Debug.LogError($"InitBag出错: 初始化源石图标配置失败: {e.Message}\n{e.StackTrace}");
        }
        
        // 检查装备数据是否已初始化
        Debug.Log("检查装备数据");
        if (EquipIdList == null)
        {
            Debug.LogWarning("InitBag警告: EquipIdList为null，初始化为空列表");
            EquipIdList = new List<TableBase>();
        }
        
        if (EquipidSprite == null)
        {
            Debug.LogWarning("InitBag警告: EquipidSprite为null，初始化为空字典");
            EquipidSprite = new Dictionary<int, Sprite>();
        }
        
        if (EquipidTable == null)
        {
            Debug.LogWarning("InitBag警告: EquipidTable为null，初始化为空字典");
            EquipidTable = new Dictionary<int, EquipTable>();
        }
        
        Debug.Log($"InitBag完成，EquipIdList中有 {EquipIdList.Count} 件装备，EquipidSprite中有 {EquipidSprite.Count} 个图标，EquipidTable中有 {EquipidTable.Count} 个装备属性");
    }


    // public void UpdateMaxEquipId()
    // {
    //      GlobalMaxEquipId.MaxWhiteClothId= EquipController.S.MaxClothID(1);
    //      GlobalMaxEquipId.MaxGreenClothId= EquipController.S.MaxClothID(2);
    //      GlobalMaxEquipId.MaxBlueClothId= EquipController.S.MaxClothID(3);
    //      GlobalMaxEquipId.MaxPurpleClothId= EquipController.S.MaxClothID(4);
    //      GlobalMaxEquipId.MaxOrangeClothId= EquipController.S.MaxClothID(5);
    //
    // }


    public void InitEquipidSpriteConfig()
    {
        if (!EquipidSpriteConfig.ContainsKey("PrimaryCloth"))
        {
            EquipidSpriteConfig.Add("PrimaryCloth", Resources.Load<Sprite>("Sprite/Equip/PrimaryCloth"));
        }
        if (!EquipidSpriteConfig.ContainsKey("PrimaryCloak"))
        {
            EquipidSpriteConfig.Add("PrimaryCloak", Resources.Load<Sprite>("Sprite/Equip/PrimaryCloak"));
        }
        if (!EquipidSpriteConfig.ContainsKey("PrimaryRing"))
        {
            EquipidSpriteConfig.Add("PrimaryRing", Resources.Load<Sprite>("Sprite/Equip/PrimaryRing"));
        }
        if (!EquipidSpriteConfig.ContainsKey("PrimaryNecklace"))
        {
            EquipidSpriteConfig.Add("PrimaryNecklace", Resources.Load<Sprite>("Sprite/Equip/PrimaryNecklace"));
        }
        if (!EquipidSpriteConfig.ContainsKey("PrimaryShoe"))
        {
            EquipidSpriteConfig.Add("PrimaryShoe", Resources.Load<Sprite>("Sprite/Equip/PrimaryShoe"));
        }
        if (!EquipidSpriteConfig.ContainsKey("PrimaryHelmet"))
        {
            EquipidSpriteConfig.Add("PrimaryHelmet", Resources.Load<Sprite>("Sprite/Equip/PrimaryHelmet"));
        }
        
        if (!EquipidSpriteConfig.ContainsKey("TreeManCloth"))
        {
            EquipidSpriteConfig.Add("TreeManCloth", Resources.Load<Sprite>("Sprite/Equip/TreeManCloth"));
        }
        if (!EquipidSpriteConfig.ContainsKey("TreeManCloak"))
        {
            EquipidSpriteConfig.Add("TreeManCloak", Resources.Load<Sprite>("Sprite/Equip/TreeManCloak"));
        }
        if (!EquipidSpriteConfig.ContainsKey("TreeManRing"))
        {
            EquipidSpriteConfig.Add("TreeManRing", Resources.Load<Sprite>("Sprite/Equip/TreeManRing"));
        }
        if (!EquipidSpriteConfig.ContainsKey("TreeManNecklace"))
        {
            EquipidSpriteConfig.Add("TreeManNecklace", Resources.Load<Sprite>("Sprite/Equip/TreeManNecklace"));
        }
        if (!EquipidSpriteConfig.ContainsKey("TreeManShoe"))
        {
            EquipidSpriteConfig.Add("TreeManShoe", Resources.Load<Sprite>("Sprite/Equip/TreeManShoe"));
        }
        if (!EquipidSpriteConfig.ContainsKey("TreeManHelmet"))
        {
            EquipidSpriteConfig.Add("TreeManHelmet", Resources.Load<Sprite>("Sprite/Equip/TreeManHelmet"));
        }
        
        // EquipidSpriteConfig.Add("PrimaryCloak", Resources.Load<Sprite>("Sprite/Equip/PrimaryCloak"));
        // EquipidSpriteConfig.Add("PrimaryRing", Resources.Load<Sprite>("Sprite/Equip/PrimaryRing"));
        // EquipidSpriteConfig.Add("PrimaryNecklace", Resources.Load<Sprite>("Sprite/Equip/PrimaryNecklace"));
        // EquipidSpriteConfig.Add("PrimaryShoe", Resources.Load<Sprite>("Sprite/Equip/PrimaryShoe"));
        // EquipidSpriteConfig.Add("PrimaryHelmet", Resources.Load<Sprite>("Sprite/Equip/PrimaryHelmet"));
        // EquipidSpriteConfig.Add("TreeManCloth", Resources.Load<Sprite>("Sprite/Equip/TreeManCloth"));
        // EquipidSpriteConfig.Add("TreeManCloak", Resources.Load<Sprite>("Sprite/Equip/TreeManCloak"));
        // EquipidSpriteConfig.Add("TreeManRing", Resources.Load<Sprite>("Sprite/Equip/TreeManRing"));
        // EquipidSpriteConfig.Add("TreeManNecklace", Resources.Load<Sprite>("Sprite/Equip/TreeManNecklace"));
        // EquipidSpriteConfig.Add("TreeManShoe", Resources.Load<Sprite>("Sprite/Equip/TreeManShoe"));
        // EquipidSpriteConfig.Add("TreeManHelmet", Resources.Load<Sprite>("Sprite/Equip/TreeManHelmet"));
    }
    
    
    public void InitSourceStoneSpriteConfig()
    {
        if (!SourceStoneSpriteConfig.ContainsKey(1))
        {
            SourceStoneSpriteConfig.Add(1, Resources.Load<Sprite>("Sprite/WeaponSourceStone/Penetrate"));
        }
        if (!SourceStoneSpriteConfig.ContainsKey(2))
        {
            SourceStoneSpriteConfig.Add(2, Resources.Load<Sprite>("Sprite/WeaponSourceStone/Division"));
        }
        if (!SourceStoneSpriteConfig.ContainsKey(3))
        {
            SourceStoneSpriteConfig.Add(3, Resources.Load<Sprite>("Sprite/WeaponSourceStone/ExtremeSpeed"));
        }
        if (!SourceStoneSpriteConfig.ContainsKey(4))
        {
            SourceStoneSpriteConfig.Add(4, Resources.Load<Sprite>("Sprite/WeaponSourceStone/Explosion"));
        }
        if (!SourceStoneSpriteConfig.ContainsKey(5))
        {
            SourceStoneSpriteConfig.Add(5, Resources.Load<Sprite>("Sprite/WeaponSourceStone/Scale"));
        }
        if (!SourceStoneSpriteConfig.ContainsKey(6))
        {
            SourceStoneSpriteConfig.Add(6, Resources.Load<Sprite>("Sprite/WeaponSourceStone/Duration"));
        }
        // SourceStoneSpriteConfig.Add(2, Resources.Load<Sprite>("Sprite/WeaponSourceStone/Division"));
        // SourceStoneSpriteConfig.Add(3, Resources.Load<Sprite>("Sprite/WeaponSourceStone/ExtremeSpeed"));
        // SourceStoneSpriteConfig.Add(4, Resources.Load<Sprite>("Sprite/WeaponSourceStone/Explosion"));
        // SourceStoneSpriteConfig.Add(5, Resources.Load<Sprite>("Sprite/WeaponSourceStone/Scale"));
        // SourceStoneSpriteConfig.Add(6, Resources.Load<Sprite>("Sprite/WeaponSourceStone/Duration"));
    }
    

    /// <summary>
    /// 出售所有白色装备
    /// </summary>
    public void SellAllWhite()
    {
        // 检查 WhiteEquipidTable 是否为空
        if (WhiteEquipidTable.Count == 0)
        {
            Debug.LogWarning("No white equips to delete.");
            return;
        }
    
        // 保存当前需要处理的装备ID以避免并发修改问题
        List<int> equipIdsToRemove = new List<int>(WhiteEquipidTable.Keys);
        
        // 同步处理Unity部分：清除内存中的数据
        foreach (var equipId in equipIdsToRemove)
        {
            if (WhiteEquipidTable.TryGetValue(equipId, out var equipData))
            {
                EquipidTable.Remove(equipId); // 删除 EquipidTable 中的记录
                EquipIdList.Remove(equipData); // 删除 EquipIdList 中的记录
                EquipidSprite.Remove(equipId); // 删除 EquipidSprite 中的记录
            }
        }
        
        WhiteEquipidTable.Clear(); // 清空白色装备表
        Debug.Log("已从内存中移除白色装备。");
        
        // 启动异步任务处理MySQL操作
        System.Threading.Tasks.Task.Run(() => DeleteWhiteEquipsFromDatabase(equipIdsToRemove));
    }
    
    // 异步处理MySQL部分
    private void DeleteWhiteEquipsFromDatabase(List<int> equipIds)
    {
        if (equipIds.Count == 0) return;
        
        MySqlTransaction transaction = null;
        try
        {
            // 后台线程执行MySQL操作
            transaction = ConnectMysql.Connection.BeginTransaction();
            
            string sql = "DELETE FROM equip WHERE equipid IN (" + string.Join(", ", equipIds) + ")";
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection, transaction);
            
            int rowsAffected = command.ExecuteNonQuery();
            transaction.Commit();
            
            // 使用主线程安全的方式记录日志
            Tool.UnityMainThreadDispatcher.Instance().Enqueue(() => {
                Debug.Log($"{rowsAffected} white equips removed from database.");
                Debug.Log("Transaction committed successfully.");
            });
        }
        catch (MySqlConnector.MySqlException ex)
        {
            if (transaction != null)
                transaction.Rollback();
                
            // 使用主线程安全的方式记录错误
            Tool.UnityMainThreadDispatcher.Instance().Enqueue(() => {
                Debug.LogError($"Error deleting white equips: {ex.Message}. Transaction rolled back.");
            });
        }
    }

    
    
    /// <summary>
    /// 出售所有绿色装备
    /// </summary>
    public void SellAllGreen()
    {
        // 检查 GreenEquipidTable 是否为空
        if (GreenEquipidTable.Count == 0)
        {
            Debug.LogWarning("No Green equips to delete.");
            return;
        }
    
        // 保存当前需要处理的装备ID以避免并发修改问题
        List<int> equipIdsToRemove = new List<int>(GreenEquipidTable.Keys);
        
        // 同步处理Unity部分：清除内存中的数据
        foreach (var equipId in equipIdsToRemove)
        {
            if (GreenEquipidTable.TryGetValue(equipId, out var equipData))
            {
                EquipidTable.Remove(equipId); // 删除 EquipidTable 中的记录
                EquipIdList.Remove(equipData); // 删除 EquipIdList 中的记录
                EquipidSprite.Remove(equipId); // 删除 EquipidSprite 中的记录
            }
        }
        
        GreenEquipidTable.Clear(); // 清空绿色装备表
        Debug.Log("已从内存中移除绿色装备。");
        
        // 启动异步任务处理MySQL操作
        System.Threading.Tasks.Task.Run(() => DeleteGreenEquipsFromDatabase(equipIdsToRemove));
    }
    
    // 异步处理MySQL部分
    private void DeleteGreenEquipsFromDatabase(List<int> equipIds)
    {
        if (equipIds.Count == 0) return;
        
        MySqlTransaction transaction = null;
        try
        {
            // 后台线程执行MySQL操作
            transaction = ConnectMysql.Connection.BeginTransaction();
            
            string sql = "DELETE FROM equip WHERE equipid IN (" + string.Join(", ", equipIds) + ")";
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection, transaction);
            
            int rowsAffected = command.ExecuteNonQuery();
            transaction.Commit();
            
            // 使用主线程安全的方式记录日志
            Tool.UnityMainThreadDispatcher.Instance().Enqueue(() => {
                Debug.Log($"{rowsAffected} green equips removed from database.");
                Debug.Log("Transaction committed successfully.");
            });
        }
        catch (MySqlConnector.MySqlException ex)
        {
            if (transaction != null)
                transaction.Rollback();
                
            // 使用主线程安全的方式记录错误
            Tool.UnityMainThreadDispatcher.Instance().Enqueue(() => {
                Debug.LogError($"Error deleting green equips: {ex.Message}. Transaction rolled back.");
            });
        }
    }

    
    
    /// <summary>
    /// 出售所有蓝色装备
    /// </summary>
    public void SellAllBlue()
    {
        // 检查 BlueEquipidTable 是否为空
        if (BlueEquipidTable.Count == 0)
        {
            Debug.LogWarning("No blue equips to delete.");
            return;
        }
    
        // 保存当前需要处理的装备ID以避免并发修改问题
        List<int> equipIdsToRemove = new List<int>(BlueEquipidTable.Keys);
        
        // 同步处理Unity部分：清除内存中的数据
        foreach (var equipId in equipIdsToRemove)
        {
            if (BlueEquipidTable.TryGetValue(equipId, out var equipData))
            {
                EquipidTable.Remove(equipId); // 删除 EquipidTable 中的记录
                EquipIdList.Remove(equipData); // 删除 EquipIdList 中的记录
                EquipidSprite.Remove(equipId); // 删除 EquipidSprite 中的记录
            }
        }
        
        BlueEquipidTable.Clear(); // 清空蓝色装备表
        Debug.Log("已从内存中移除蓝色装备。");
        
        // 启动异步任务处理MySQL操作
        System.Threading.Tasks.Task.Run(() => DeleteBlueEquipsFromDatabase(equipIdsToRemove));
    }
    
    // 异步处理MySQL部分
    private void DeleteBlueEquipsFromDatabase(List<int> equipIds)
    {
        if (equipIds.Count == 0) return;
        
        MySqlTransaction transaction = null;
        try
        {
            // 后台线程执行MySQL操作
            transaction = ConnectMysql.Connection.BeginTransaction();
            
            string sql = "DELETE FROM equip WHERE equipid IN (" + string.Join(", ", equipIds) + ")";
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection, transaction);
            
            int rowsAffected = command.ExecuteNonQuery();
            transaction.Commit();
            
            // 使用主线程安全的方式记录日志
            Tool.UnityMainThreadDispatcher.Instance().Enqueue(() => {
                Debug.Log($"{rowsAffected} blue equips removed from database.");
                Debug.Log("Transaction committed successfully.");
            });
        }
        catch (MySqlConnector.MySqlException ex)
        {
            if (transaction != null)
                transaction.Rollback();
                
            // 使用主线程安全的方式记录错误
            Tool.UnityMainThreadDispatcher.Instance().Enqueue(() => {
                Debug.LogError($"Error deleting blue equips: {ex.Message}. Transaction rolled back.");
            });
        }
    }

    
    
    /// <summary>
    /// 装备排序
    /// </summary>
    public void EquipSort()
    {
        EquipidTable.Clear();
        EquipIdList.Clear();
        
        GameObject equipContent = bag.transform.Find("BagPanel/EquipPanel/BagScrollView/Viewport/EquipContent").gameObject;
        foreach (Transform child in equipContent.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var equip in OrangeEquipidTable)
        {
            GameObject bagGridins = Instantiate(bagGrid, equipContent.transform); //背包格子
            bagGridins.transform.Find("BagGridImage").GetComponent<Button>().image.sprite = EquipidSprite[equip.Key];
            //bagGrid.transform.Find("BagGridImage").GetComponent<Button>().image.sprite = EquipidSprite[equip.Key];
            bagGridins.GetComponent<BagGrid>().EquipId = equip.Key;
            bagGridins.GetComponent<BagGrid>().equipAttributeImage = EquipidSprite[equip.Key];
            bagGridins.transform.Find("EquipGridBG").GetComponent<Image>().sprite=orangeBg;
            EquipidTable.Add(equip.Key,equip.Value);
            EquipIdList.Add(equip.Value);
        }
        
        foreach (var equip in PurpleEquipidTable)
        {
            GameObject bagGridins = Instantiate(bagGrid, equipContent.transform); //背包格子
            bagGridins.transform.Find("BagGridImage").GetComponent<Button>().image.sprite = EquipidSprite[equip.Key];
            //bagGrid.transform.Find("BagGridImage").GetComponent<Button>().image.sprite = EquipidSprite[equip.Key];
            bagGridins.GetComponent<BagGrid>().EquipId = equip.Key;
            bagGridins.GetComponent<BagGrid>().equipAttributeImage = EquipidSprite[equip.Key];
            bagGridins.transform.Find("EquipGridBG").GetComponent<Image>().sprite=purpleBg;
            EquipidTable.Add(equip.Key,equip.Value);
            EquipIdList.Add(equip.Value);

        }
        
        foreach (var equip in BlueEquipidTable)
        {
            GameObject bagGridins = Instantiate(bagGrid, equipContent.transform); //背包格子
            bagGridins.transform.Find("BagGridImage").GetComponent<Button>().image.sprite = EquipidSprite[equip.Key];
           // bagGrid.transform.Find("BagGridImage").GetComponent<Button>().image.sprite = EquipidSprite[equip.Key];
            bagGridins.GetComponent<BagGrid>().EquipId = equip.Key;
            bagGridins.GetComponent<BagGrid>().equipAttributeImage = EquipidSprite[equip.Key];
            bagGridins.transform.Find("EquipGridBG").GetComponent<Image>().sprite=blueBg;
            EquipidTable.Add(equip.Key,equip.Value);
            EquipIdList.Add(equip.Value);
        }
        
        foreach (var equip in GreenEquipidTable)
        {
            GameObject bagGridins = Instantiate(bagGrid, equipContent.transform); //背包格子
            bagGridins.transform.Find("BagGridImage").GetComponent<Button>().image.sprite = EquipidSprite[equip.Key];
            //bagGrid.transform.Find("BagGridImage").GetComponent<Button>().image.sprite = EquipidSprite[equip.Key];
            bagGridins.GetComponent<BagGrid>().EquipId = equip.Key;
            bagGridins.GetComponent<BagGrid>().equipAttributeImage = EquipidSprite[equip.Key];
            bagGridins.transform.Find("EquipGridBG").GetComponent<Image>().sprite=greenBg;
            EquipidTable.Add(equip.Key,equip.Value);
            EquipIdList.Add(equip.Value);
        }
        
        foreach (var equip in WhiteEquipidTable)
        {
            GameObject bagGridins = Instantiate(bagGrid, equipContent.transform); //背包格子
            bagGridins.transform.Find("BagGridImage").GetComponent<Button>().image.sprite = EquipidSprite[equip.Key];
            //bagGrid.transform.Find("BagGridImage").GetComponent<Button>().image.sprite = EquipidSprite[equip.Key];
            bagGridins.GetComponent<BagGrid>().EquipId = equip.Key;
            bagGridins.GetComponent<BagGrid>().equipAttributeImage = EquipidSprite[equip.Key];
            bagGridins.transform.Find("EquipGridBG").GetComponent<Image>().sprite=whiteBg;
            EquipidTable.Add(equip.Key,equip.Value);
            EquipIdList.Add(equip.Value);
        }
    }
    
    /// <summary>
    /// 显示玩家面板
    /// </summary>
    public void ShowPlayerPanel()
    {
        IsShowPlayerPanel = true;
        PlayerPanel.gameObject.SetActive(true);
        AttributePanel.gameObject.SetActive(false);
    }

    /// <summary>
    /// 显示属性面板
    /// </summary>
    public void ShowAttributePanel()
    {
        IsShowPlayerPanel = false;
        PlayerPanel.gameObject.SetActive(false);
        AttributePanel.gameObject.SetActive(true);
    }

    /// <summary>
    /// 生成蒙层
    /// </summary>
    public void CreateMaskLayer()
    {
        Debug.Log("开始创建MaskLayer");
        
        // 先检查是否已有蒙层，如果有就先销毁
        if (MaskLayer != null)
        {
            Debug.LogWarning("CreateMaskLayer警告: 已存在MaskLayer，先销毁旧的");
            DestroyMaskLayer();
        }
        
        GameObject maskLayerPrefab = Resources.Load<GameObject>("Prefabs/Equip/MaskLayer");
        if (maskLayerPrefab == null)
        {
            Debug.LogError("CreateMaskLayer出错: 找不到MaskLayer预制体");
            return;
        }
        
        try
        {
            MaskLayer = Instantiate(maskLayerPrefab, transform);
            Debug.Log("MaskLayer创建成功");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"CreateMaskLayer出错: 实例化MaskLayer失败: {e.Message}");
        }
    }

    /// <summary>
    /// 销毁蒙层
    /// </summary>
    public void DestroyMaskLayer()
    {
        Debug.Log("开始销毁MaskLayer");
        
        if (MaskLayer == null)
        {
            Debug.LogWarning("DestroyMaskLayer警告: MaskLayer已经是null");
            return;
        }
        
        Destroy(MaskLayer);
        MaskLayer = null;  // 重要：确保引用被清除
        
        Debug.Log("MaskLayer已销毁并置为null");
    }


    /// <summary>
    /// 显示背包的装备
    /// </summary>
    public void ShowEquip()
    {
        Debug.Log("开始执行ShowEquip方法");
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        // 检查bag是否为空
        if (bag == null)
        {
            Debug.LogError("ShowEquip出错: bag对象为null");
            return;
        }
        Debug.Log("bbbbbbbbbbbbbbbbbbb");

        
        // // 检查bag父对象
        // if (bag.transform.parent == null)
        // {
        //     Debug.LogError("ShowEquip出错: bag.transform.parent为null");
        //     return;
        // }
        
        //Debug.Log("bag对象正常，激活父对象");
        bag.transform.gameObject.SetActive(true);
        Debug.Log("ccccccccccccccccccccccccccc");

        
        // // 查找SceneLoading对象并设置为不可见
        // Transform sceneLoadingTransform = bag.transform.transform.Find("SceneLoading");
        // Debug.Log("ddddddddddddddddddddddddddddddd");
        //
        // if (sceneLoadingTransform == null)
        // {
        //     Debug.LogWarning("ShowEquip警告: 找不到SceneLoading对象");
        // }
        // else
        // {
        //     Debug.Log("找到SceneLoading对象，设置为不可见");
        //     sceneLoadingTransform.gameObject.SetActive(false);
        // }
        // Debug.Log("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");

        // 查找装备内容面板
        Transform equipContentTransform = bag.transform.Find("BagPanel/EquipPanel/BagScrollView/Viewport/EquipContent");
        Debug.Log("fffffffffffffffffffffffffffffffffffffff");

        if (equipContentTransform == null)
        {
            Debug.LogError("ShowEquip出错: 找不到装备内容面板路径 BagPanel/EquipPanel/BagScrollView/Viewport/EquipContent");
            return;
        }
        Debug.Log("gggggggggggggggggggggggggggg");

        
        Debug.Log("找到装备内容面板");
        GameObject equipContent = equipContentTransform.gameObject;
        
        // 清空装备内容面板
        Debug.Log($"开始清空装备内容面板，子物体数量: {equipContent.transform.childCount}");
        foreach (Transform child in equipContent.transform)
        {
            Destroy(child.gameObject);
        }
        
        // 检查装备列表是否为空
        if (EquipIdList == null)
        {
            Debug.LogError("ShowEquip出错: EquipIdList为null");
            return;
        }
        Debug.Log("1111111111111");

        
        Debug.Log($"EquipIdList包含 {EquipIdList.Count} 件装备，开始显示装备，当前页码: {PageNum}");
        
        // 检查背包格子预制体是否为空
        if (bagGrid == null)
        {
            Debug.LogError("ShowEquip出错: bagGrid预制体为null");
            return;
        }

        // 计算显示的装备范围
        int startIndex = (PageNum - 1) * 20;
        int endIndex = Mathf.Min(PageNum * 20, EquipIdList.Count);
        Debug.Log($"开始显示装备，范围: {startIndex} - {endIndex-1}");
        
        for (int i = startIndex; i < endIndex; i++)
        {
            try
            {
                // 检查当前索引的装备是否为空
                if (EquipIdList[i] == null)
                {
                    Debug.LogError($"ShowEquip出错: EquipIdList[{i}]为null");
                    continue;
                }
                
                Debug.Log($"处理索引 {i} 的装备，ID: {EquipIdList[i].Equipid}, 类型: {EquipIdList[i].TableType}");
                
                // 实例化背包格子
                GameObject bagGridins = Instantiate(bagGrid, equipContent.transform);
                
                if (EquipIdList[i].TableType == TableType.SourceStoneTable) // 源石
                {
                    Debug.Log($"索引 {i} 是源石类型");
                    SourceStoneTable sourceStoneTable = (SourceStoneTable)EquipIdList[i];
                    
                    // 检查源石配置
                    if (SourceStoneSpriteConfig == null)
                    {
                        Debug.LogError($"ShowEquip出错: SourceStoneSpriteConfig为null");
                        continue;
                    }
                    
                    // 检查源石类型是否存在
                    if (!SourceStoneSpriteConfig.ContainsKey(sourceStoneTable.SourceStoneType))
                    {
                        Debug.LogError($"ShowEquip出错: 找不到源石类型 {sourceStoneTable.SourceStoneType} 的图标配置");
                        continue;
                    }
                    
                    // 检查BagGridImage是否存在
                    Transform bagGridImageTransform = bagGridins.transform.Find("BagGridImage");
                    if (bagGridImageTransform == null)
                    {
                        Debug.LogError($"ShowEquip出错: 找不到BagGridImage");
                        continue;
                    }
                    
                    Button bagGridButton = bagGridImageTransform.GetComponent<Button>();
                    if (bagGridButton == null)
                    {
                        Debug.LogError($"ShowEquip出错: BagGridImage上没有Button组件");
                        continue;
                    }
                    
                    Debug.Log($"设置源石图标，类型: {sourceStoneTable.SourceStoneType}");
                    bagGridButton.image.sprite = SourceStoneSpriteConfig[sourceStoneTable.SourceStoneType];
                    
                    // 检查BagGrid组件
                    BagGrid bagGridComponent = bagGridins.GetComponent<BagGrid>();
                    if (bagGridComponent == null)
                    {
                        Debug.LogError($"ShowEquip出错: 背包格子上没有BagGrid组件");
                        continue;
                    }
                    
                    bagGridComponent.equipAttributeImage = SourceStoneSpriteConfig[sourceStoneTable.SourceStoneType];
                    bagGridComponent.EquipType = EquipType.SourceStone;
                    
                    // 设置数量
                    Transform countTransform = bagGridins.transform.Find("Count");
                    if (countTransform == null)
                    {
                        Debug.LogError($"ShowEquip出错: 找不到Count文本");
                        continue;
                    }
                    
                    Text countText = countTransform.GetComponent<Text>();
                    if (countText == null)
                    {
                        Debug.LogError($"ShowEquip出错: Count上没有Text组件");
                        continue;
                    }
                    
                    countText.text = sourceStoneTable.Count.ToString();
                    
                } else if (EquipIdList[i].TableType == TableType.EquipTable) // 装备
                {
                    Debug.Log($"索引 {i} 是装备类型, 装备ID: {EquipIdList[i].Equipid}");
                    
                    // 检查装备图标配置
                    if (EquipidSprite == null)
                    {
                        Debug.LogError($"ShowEquip出错: EquipidSprite为null");
                        continue;
                    }
                    
                    // 检查装备ID是否存在
                    if (!EquipidSprite.ContainsKey(EquipIdList[i].Equipid))
                    {
                        Debug.LogError($"ShowEquip出错: 找不到装备ID {EquipIdList[i].Equipid} 的图标配置");
                        continue;
                    }
                    
                    // 设置装备图标
                    Transform bagGridImageTransform = bagGridins.transform.Find("BagGridImage");
                    if (bagGridImageTransform == null)
                    {
                        Debug.LogError($"ShowEquip出错: 找不到BagGridImage");
                        continue;
                    }
                    
                    Button bagGridButton = bagGridImageTransform.GetComponent<Button>();
                    if (bagGridButton == null)
                    {
                        Debug.LogError($"ShowEquip出错: BagGridImage上没有Button组件");
                        continue;
                    }
                    
                    bagGridButton.image.sprite = EquipidSprite[EquipIdList[i].Equipid];
                    
                    // 设置装备属性图标
                    BagGrid bagGridComponent = bagGridins.GetComponent<BagGrid>();
                    if (bagGridComponent == null)
                    {
                        Debug.LogError($"ShowEquip出错: 背包格子上没有BagGrid组件");
                        continue;
                    }
                    
                    bagGridComponent.equipAttributeImage = EquipidSprite[EquipIdList[i].Equipid];
                    bagGridComponent.EquipType = EquipType.Equip;
                    
                    // 隐藏数量显示
                    Transform countTransform = bagGridins.transform.Find("Count");
                    if (countTransform == null)
                    {
                        Debug.LogError($"ShowEquip出错: 找不到Count文本");
                        continue;
                    }
                    
                    countTransform.gameObject.SetActive(false);
                }
                
                // 设置装备ID
                BagGrid bagGridComponent2 = bagGridins.GetComponent<BagGrid>();
                if (bagGridComponent2 == null)
                {
                    Debug.LogError($"ShowEquip出错: 背包格子上没有BagGrid组件");
                    continue;
                }
                
                bagGridComponent2.EquipId = EquipIdList[i].Equipid;
                TableBase bagGridinsequiptable = EquipIdList[i];
                
                // 设置装备背景颜色
                Transform equipGridBGTransform = bagGridins.transform.Find("EquipGridBG");
                if (equipGridBGTransform == null)
                {
                    Debug.LogError($"ShowEquip出错: 找不到EquipGridBG");
                    continue;
                }
                
                Image equipGridBGImage = equipGridBGTransform.GetComponent<Image>();
                if (equipGridBGImage == null)
                {
                    Debug.LogError($"ShowEquip出错: EquipGridBG上没有Image组件");
                    continue;
                }
                
                Debug.Log($"设置装备 {EquipIdList[i].Equipid} 的背景，品质: {bagGridinsequiptable.Quality}");
                
                // 检查背景图是否为空
                if (whiteBg == null || greenBg == null || blueBg == null || purpleBg == null || orangeBg == null)
                {
                    Debug.LogError($"ShowEquip出错: 装备背景图为null，whiteBg: {whiteBg != null}, greenBg: {greenBg != null}, blueBg: {blueBg != null}, purpleBg: {purpleBg != null}, orangeBg: {orangeBg != null}");
                    continue;
                }
                
                switch (bagGridinsequiptable.Quality)
                {
                    case 1:
                        equipGridBGImage.sprite = whiteBg;
                        break;
                    case 2:
                        equipGridBGImage.sprite = greenBg;
                        break;
                    case 3:
                        equipGridBGImage.sprite = blueBg;
                        break;
                    case 4:
                        equipGridBGImage.sprite = purpleBg;
                        break;
                    case 5:
                        equipGridBGImage.sprite = orangeBg;
                        break;
                    default:
                        Debug.LogWarning($"ShowEquip警告: 装备 {EquipIdList[i].Equipid} 的品质异常: {bagGridinsequiptable.Quality}");
                        break;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError($"ShowEquip异常: 处理索引 {i} 的装备时出错: {e.Message}\n{e.StackTrace}");
            }
        }
        
        Debug.Log("ShowEquip方法执行完成");
    }

    /// <summary>
    /// 打开背包面板
    /// </summary>
    public void ShowBag()
    {
        Debug.Log("开始执行ShowBag方法");
        
        // 检查背包对象是否为空
        if (bag == null)
        {
            Debug.LogError("ShowBag出错: bag对象为null，尝试重新初始化背包");
            InitBag();
            
            // 再次检查背包对象
            if (bag == null)
            {
                Debug.LogError("ShowBag出错: 重新初始化背包后bag仍为null，无法显示背包");
                return;
            }
        }
        
        // 检查装备列表是否为空
        if (EquipIdList == null)
        {
            Debug.LogWarning("ShowBag警告: EquipIdList为null，初始化为空列表");
            EquipIdList = new List<TableBase>();
        }
        
        Debug.Log($"暂停游戏，当前EquipIdList中有 {EquipIdList.Count} 件装备");
        
        // 暂停游戏
        Time.timeScale = 0;
        bag.gameObject.SetActive(true);
        
        try
        {
            Debug.Log("调用ShowEquip方法显示装备");
            ShowEquip();
        }
        catch (System.Exception e)
        {
            Debug.LogError($"ShowBag出错: 调用ShowEquip方法时发生异常: {e.Message}\n{e.StackTrace}");
        }
        
        Debug.Log("ShowBag方法执行完成");
    }

    /// <summary>
    /// 隐藏背包面板
    /// </summary>
    public void HideBag()
    {
        //暂停游戏
        Time.timeScale = 1;
        bag.gameObject.SetActive(false);
    }


    /// <summary>
    /// 装装备
    /// </summary>
    /// <param name="equipId"></param>
    public void InstallCloth(int equipId)
    {
        IsInstallCloth = true;
        playerCloth.transform.Find("Image").gameObject.SetActive(true);
        playerCloth.transform.Find("ImageBG").gameObject.SetActive(true);
        playerCloth.transform.Find("Image").GetComponent<Button>().onClick.RemoveAllListeners();
        playerCloth.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidSprite[equipId];
        switch (EquipidTable[equipId].Quality)
        {
            case 1:
                playerCloth.transform.Find("ImageBG").GetComponent<Image>().sprite= whiteBg;
                break;
            case 2:
                playerCloth.transform.Find("ImageBG").GetComponent<Image>().sprite = greenBg;
                break;
            case 3:
                playerCloth.transform.Find("ImageBG").GetComponent<Image>().sprite=blueBg;
                break;
            case 4:
                playerCloth.transform.Find("ImageBG").GetComponent<Image>().sprite = purpleBg;
                break;
            case 5:
                playerCloth.transform.Find("ImageBG").GetComponent<Image>().sprite = orangeBg;
                break;
        }
        playerCloth.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() => { CreateMaskLayer();ShowEquipAttributePanel(equipId,EquipType.Equip); });
    }

    public void InstallCloak(int equipId)
    {
        IsInstallCloak = true;
        playerCloak.transform.Find("Image").gameObject.SetActive(true);
        playerCloak.transform.Find("ImageBG").gameObject.SetActive(true);
        playerCloak.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidSprite[equipId];
        playerCloak.transform.Find("Image").GetComponent<Button>().onClick.RemoveAllListeners();
        playerCloak.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() => { CreateMaskLayer();ShowEquipAttributePanel(equipId,EquipType.Equip); });
        switch (EquipidTable[equipId].Quality)
        {
            case 1:
                playerCloak.transform.Find("ImageBG").GetComponent<Image>().sprite= whiteBg;
                break;
            case 2:
                playerCloak.transform.Find("ImageBG").GetComponent<Image>().sprite = greenBg;
                break;
            case 3:
                playerCloak.transform.Find("ImageBG").GetComponent<Image>().sprite=blueBg;
                break;
            case 4:
                playerCloak.transform.Find("ImageBG").GetComponent<Image>().sprite = purpleBg;
                break;
            case 5:
                playerCloak.transform.Find("ImageBG").GetComponent<Image>().sprite = orangeBg;
                break;
        }
    }

    public void InstallRing(int equipId)
    {
        IsInstallRing = true;
        playerRing.transform.Find("Image").gameObject.SetActive(true);
        playerRing.transform.Find("ImageBG").gameObject.SetActive(true);
        playerRing.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidSprite[equipId];
        playerRing.transform.Find("Image").GetComponent<Button>().onClick.RemoveAllListeners();
        playerRing.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() => { CreateMaskLayer();ShowEquipAttributePanel(equipId,EquipType.Equip); });
        switch (EquipidTable[equipId].Quality)
        {
            case 1:
                playerRing.transform.Find("ImageBG").GetComponent<Image>().sprite= whiteBg;
                break;
            case 2:
                playerRing.transform.Find("ImageBG").GetComponent<Image>().sprite = greenBg;
                break;
            case 3:
                playerRing.transform.Find("ImageBG").GetComponent<Image>().sprite=blueBg;
                break;
            case 4:
                playerRing.transform.Find("ImageBG").GetComponent<Image>().sprite = purpleBg;
                break;
            case 5:
                playerRing.transform.Find("ImageBG").GetComponent<Image>().sprite = orangeBg;
                break;
        }
    }

    public void InstallNecklace(int equipId)
    {
        IsInstallNecklace = true;
        playerNecklace.transform.Find("Image").gameObject.SetActive(true);
        playerNecklace.transform.Find("ImageBG").gameObject.SetActive(true);
        playerNecklace.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidSprite[equipId];
        playerNecklace.transform.Find("Image").GetComponent<Button>().onClick.RemoveAllListeners();
        playerNecklace.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() => { CreateMaskLayer();ShowEquipAttributePanel(equipId,EquipType.Equip); });
        switch (EquipidTable[equipId].Quality)
        {
            case 1:
                playerNecklace.transform.Find("ImageBG").GetComponent<Image>().sprite= whiteBg;
                break;
            case 2:
                playerNecklace.transform.Find("ImageBG").GetComponent<Image>().sprite = greenBg;
                break;
            case 3:
                playerNecklace.transform.Find("ImageBG").GetComponent<Image>().sprite=blueBg;
                break;
            case 4:
                playerNecklace.transform.Find("ImageBG").GetComponent<Image>().sprite = purpleBg;
                break;
            case 5:
                playerNecklace.transform.Find("ImageBG").GetComponent<Image>().sprite = orangeBg;
                break;
        }
    }

    public void InstallShoe(int equipId)
    {
        IsInstallShoe = true;
        playerShoe.transform.Find("Image").gameObject.SetActive(true);
        playerShoe.transform.Find("ImageBG").gameObject.SetActive(true);
        playerShoe.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidSprite[equipId];
        playerShoe.transform.Find("Image").GetComponent<Button>().onClick.RemoveAllListeners();
        playerShoe.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() => { CreateMaskLayer();ShowEquipAttributePanel(equipId,EquipType.Equip); });
        switch (EquipidTable[equipId].Quality)
        {
            case 1:
                playerShoe.transform.Find("ImageBG").GetComponent<Image>().sprite= whiteBg;
                break;
            case 2:
                playerShoe.transform.Find("ImageBG").GetComponent<Image>().sprite = greenBg;
                break;
            case 3:
                playerShoe.transform.Find("ImageBG").GetComponent<Image>().sprite=blueBg;
                break;
            case 4:
                playerShoe.transform.Find("ImageBG").GetComponent<Image>().sprite = purpleBg;
                break;
            case 5:
                playerShoe.transform.Find("ImageBG").GetComponent<Image>().sprite = orangeBg;
                break;
        }
    }

    public void InstallHelmet(int equipId)
    {
        IsInstallHelmet = true;
        playerHelmet.transform.Find("Image").gameObject.SetActive(true);
        playerHelmet.transform.Find("ImageBG").gameObject.SetActive(true);
        playerHelmet.transform.Find("Image").GetComponent<Button>().image.sprite = EquipidSprite[equipId];
        playerHelmet.transform.Find("Image").GetComponent<Button>().onClick.RemoveAllListeners();
        playerHelmet.transform.Find("Image").GetComponent<Button>().onClick.AddListener(() => { CreateMaskLayer();ShowEquipAttributePanel(equipId,EquipType.Equip);});
        switch (EquipidTable[equipId].Quality)
        {
            case 1:
                playerHelmet.transform.Find("ImageBG").GetComponent<Image>().sprite= whiteBg;
                break;
            case 2:
                playerHelmet.transform.Find("ImageBG").GetComponent<Image>().sprite = greenBg;
                break;
            case 3:
                playerHelmet.transform.Find("ImageBG").GetComponent<Image>().sprite=blueBg;
                break;
            case 4:
                playerHelmet.transform.Find("ImageBG").GetComponent<Image>().sprite = purpleBg;
                break;
            case 5:
                playerHelmet.transform.Find("ImageBG").GetComponent<Image>().sprite = orangeBg;
                break;
        }
    }

    /// <summary>
    /// 卸装备
    /// </summary>
    public void UnInstallCloth()
    {
        IsInstallCloth = false;
        playerCloth.transform.Find("Image").gameObject.SetActive(false);
        playerCloth.transform.Find("Image").GetComponent<Button>().image.sprite = null;
    }

    public void UnInstallCloak()
    {
        IsInstallCloak = false;
        playerCloak.transform.Find("Image").gameObject.SetActive(false);
        playerCloak.transform.Find("Image").GetComponent<Button>().image.sprite = null;
    }

    public void UnInstallRing()
    {
        IsInstallRing = false;
        playerRing.transform.Find("Image").gameObject.SetActive(false);
        playerRing.transform.Find("Image").GetComponent<Button>().image.sprite = null;
    }

    public void UnInstallNecklace()
    {
        IsInstallNecklace = false;
        playerNecklace.transform.Find("Image").gameObject.SetActive(false);
        playerNecklace.transform.Find("Image").GetComponent<Button>().image.sprite = null;
    }

    public void UnInstallShoe()
    {
        IsInstallShoe = false;
        playerShoe.transform.Find("Image").gameObject.SetActive(false);
        playerShoe.transform.Find("Image").GetComponent<Button>().image.sprite = null;
    }

    public void UnInstallHelmet()
    {
        IsInstallHelmet = false;
        playerHelmet.transform.Find("Image").gameObject.SetActive(false);
        playerHelmet.transform.Find("Image").GetComponent<Button>().image.sprite = null;
    }

    public void ShowEquipAttributePanel(int EquipId, EquipType EquipType)
    {
        Debug.Log($"开始显示装备属性面板，装备ID: {EquipId}, 类型: {EquipType}");
        
        if (EquipType == EquipType.Equip)
        {
            // 检查装备ID是否存在
            if (!EquipidTable.ContainsKey(EquipId))
            {
                Debug.LogError($"ShowEquipAttributePanel出错: 装备ID不存在: {EquipId}");
                DestroyMaskLayer();  // 确保销毁蒙层
                return;
            }

            Debug.Log($"找到装备ID: {EquipId}, 准备显示属性面板");
            EquipTable equipTable = EquipidTable[EquipId];
            
            // 加载预制体
            GameObject attributePrefab = Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute");
            if (attributePrefab == null)
            {
                Debug.LogError("ShowEquipAttributePanel出错: 找不到EquipAttribute预制体");
                DestroyMaskLayer();
                return;
            }
            
            // 实例化预制体
            GameObject equipAttribute = null;
            try
            {
                equipAttribute = Instantiate(attributePrefab, BagController.S.transform);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"ShowEquipAttributePanel出错: 实例化预制体异常: {e.Message}\n{e.StackTrace}");
                DestroyMaskLayer();
                return;
            }
            
            // 设置装备ID
            EquipAttributePanel panel = equipAttribute.GetComponent<EquipAttributePanel>();
            if (panel == null)
            {
                Debug.LogError("ShowEquipAttributePanel出错: 找不到EquipAttributePanel组件");
                Destroy(equipAttribute);
                DestroyMaskLayer();
                return;
            }
            
            panel.CurrentequipId = EquipId; //当前装备ID传给属性面板
            
            // 设置装备图标
            try
            {
                GameObject equipAttributeEquip = equipAttribute.transform.Find("EquipAttributeEquip").gameObject;
                GameObject equipAttributeEquipImage = equipAttributeEquip.transform.Find("EquipAttributeEquipImage").gameObject;
                equipAttributeEquipImage.GetComponent<Image>().sprite = EquipidSprite[EquipId];
                
                // 设置装备名称
                GameObject equipAttributeName = equipAttribute.transform.Find("EquipAttributeName").gameObject;
                equipAttributeName.GetComponent<Text>().text = EquipName.EquipNameDic[equipTable.EquipName];
                
                // 显示装备属性
                GameObject equipAttributeContent = equipAttribute.transform.Find("ScrollView").Find("Viewport").Find("Content").gameObject;
                
                // 清空旧的内容
                foreach (Transform child in equipAttributeContent.transform)
                {
                    Destroy(child.gameObject);
                }
                
                // 添加装备属性
                DisplayEquipAttribute(equipTable, equipAttributeContent);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"ShowEquipAttributePanel出错: 设置装备属性面板异常: {e.Message}\n{e.StackTrace}");
                Destroy(equipAttribute);
                DestroyMaskLayer();
                return;
            }
            
            Debug.Log("装备属性面板显示成功");
        }
        else if (EquipType == EquipType.SourceStone) // 源石
        {
            // 检查源石ID是否存在
            if (!SourceStoneTable.ContainsKey(EquipId))
            {
                Debug.LogError($"ShowEquipAttributePanel出错: 源石ID不存在: {EquipId}");
                DestroyMaskLayer();
                return;
            }
            
            Debug.Log($"找到源石ID: {EquipId}, 准备显示属性面板");
            SourceStoneTable sourceStoneTable = SourceStoneTable[EquipId];
            
            // 加载预制体
            GameObject attributePrefab = Resources.Load<GameObject>("Prefabs/Equip/EquipAttribute");
            if (attributePrefab == null)
            {
                Debug.LogError("ShowEquipAttributePanel出错: 找不到EquipAttribute预制体");
                DestroyMaskLayer();
                return;
            }
            
            // 实例化预制体
            GameObject equipAttribute = null;
            try
            {
                equipAttribute = Instantiate(attributePrefab, BagController.S.transform);
                
                // 隐藏装备和出售按钮
                equipAttribute.transform.Find("InstallButton").gameObject.SetActive(false);
                equipAttribute.transform.Find("SellButton").gameObject.SetActive(false);
                
                // 设置装备ID
                equipAttribute.GetComponent<EquipAttributePanel>().CurrentequipId = EquipId;
                
                // 设置源石图标
                GameObject equipAttributeEquip = equipAttribute.transform.Find("EquipAttributeEquip").gameObject;
                GameObject equipAttributeEquipImage = equipAttributeEquip.transform.Find("EquipAttributeEquipImage").gameObject;
                equipAttributeEquipImage.GetComponent<Image>().sprite = SourceStoneSpriteConfig[sourceStoneTable.SourceStoneType];
                
                // 设置源石名称
                GameObject equipAttributeName = equipAttribute.transform.Find("EquipAttributeName").gameObject;
                equipAttributeName.GetComponent<Text>().text = sourceStoneTable.EquipName;
                
                // 显示源石介绍
                GameObject equipAttributeContent = equipAttribute.transform.Find("ScrollView").Find("Viewport").Find("Content").gameObject;
                
                // 清空旧的内容
                foreach (Transform child in equipAttributeContent.transform)
                {
                    Destroy(child.gameObject);
                }
                
                // 添加源石介绍
                GameObject EquipAttributeItem = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem"),
                    equipAttributeContent.transform);
                    
                switch (sourceStoneTable.SourceStoneType)
                {
                    case 1:
                        EquipAttributeItem.GetComponent<Text>().text = SourceStoneText.WhitePenetrate;
                        break;
                    case 2:
                        EquipAttributeItem.GetComponent<Text>().text = SourceStoneText.WhiteDivision;
                        break;
                    case 3:
                        EquipAttributeItem.GetComponent<Text>().text = SourceStoneText.WhiteExtremeSpeed;
                        break;
                    case 4:
                        EquipAttributeItem.GetComponent<Text>().text = SourceStoneText.WhiteExplosion;
                        break;
                    case 5:
                        EquipAttributeItem.GetComponent<Text>().text = SourceStoneText.WhiteScale;
                        break;
                    case 6:
                        EquipAttributeItem.GetComponent<Text>().text = SourceStoneText.WhiteDuration;
                        break;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError($"ShowEquipAttributePanel出错: 设置源石属性面板异常: {e.Message}\n{e.StackTrace}");
                if (equipAttribute != null)
                {
                    Destroy(equipAttribute);
                }
                DestroyMaskLayer();
                return;
            }
            
            Debug.Log("源石属性面板显示成功");
        }
    }
    
    // 辅助方法：显示装备属性
    private void DisplayEquipAttribute(EquipTable equipTable, GameObject contentPanel)
    {
        if (equipTable.Damage != 0)
        {
            CreateAttributeItem(contentPanel, "攻击力：" + equipTable.Damage);
        }

        if (equipTable.HP != 0)
        {
            CreateAttributeItem(contentPanel, "生命值：" + equipTable.HP);
        }

        if (equipTable.Denfense != 0)
        {
            CreateAttributeItem(contentPanel, "防御力：" + equipTable.Denfense);
        }

        if (equipTable.CRIT != 0)
        {
            CreateAttributeItem(contentPanel, "暴击率：" + equipTable.CRIT);
        }

        if (equipTable.CRITDamage != 0)
        {
            CreateAttributeItem(contentPanel, "暴击伤害：" + equipTable.CRITDamage);
        }

        if (equipTable.BloodSuck != 0)
        {
            CreateAttributeItem(contentPanel, "吸血：" + equipTable.BloodSuck);
        }

        if (equipTable.GoodFortune != 0)
        {
            CreateAttributeItem(contentPanel, "幸运：" + equipTable.GoodFortune);
        }

        if (equipTable.MoveSpeed != 0)
        {
            CreateAttributeItem(contentPanel, "移动速度：" + equipTable.MoveSpeed);
        }

        if (equipTable.DamageSpeed != 0)
        {
            CreateAttributeItem(contentPanel, "攻击速度：" + equipTable.DamageSpeed);
        }
    }
    
    // 辅助方法：创建属性项
    private GameObject CreateAttributeItem(GameObject parent, string text)
    {
        GameObject itemPrefab = Resources.Load<GameObject>("Prefabs/Equip/EquipAttributeItem");
        if (itemPrefab == null)
        {
            Debug.LogError("CreateAttributeItem出错: 找不到EquipAttributeItem预制体");
            return null;
        }
        
        GameObject item = Instantiate(itemPrefab, parent.transform);
        item.GetComponent<Text>().text = text;
        return item;
    }

    public Sprite GetEquipSprite(string equipName)
    {
        if (equipName == "PrimaryCloth")
        { GameObject equipPrefab = Resources.Load<GameObject>("Prefabs/Equip/PrimaryClothFight"); // 加载 Prefab
            if (equipPrefab != null) // 判断是否成功加载资源
            {
                Transform spriteTransform = equipPrefab.transform.Find("PrimaryClothSprite"); // 查找指定子对象
                if (spriteTransform != null) // 确保子对象存在
                {
                    SpriteRenderer spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>(); // 获取 SpriteRenderer 组件
                    if (spriteRenderer != null) // 判断组件是否存在
                    {
                        return spriteRenderer.sprite; // 返回 Sprite
                    }
                }
            }
        }
        if (equipName == "PrimaryCloak")
        { GameObject equipPrefab = Resources.Load<GameObject>("Prefabs/Equip/PrimaryCloakhFight"); // 加载 Prefab
            if (equipPrefab != null) // 判断是否成功加载资源
            {
                Transform spriteTransform = equipPrefab.transform.Find("PrimaryCloakSprite"); // 查找指定子对象
                if (spriteTransform != null) // 确保子对象存在
                {
                    SpriteRenderer spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>(); // 获取 SpriteRenderer 组件
                    if (spriteRenderer != null) // 判断组件是否存在
                    {
                        return spriteRenderer.sprite; // 返回 Sprite
                    }
                }
            }
        }
        if (equipName == "PrimaryRing")
        { GameObject equipPrefab = Resources.Load<GameObject>("Prefabs/Equip/PrimaryRingFight"); // 加载 Prefab
            if (equipPrefab != null) // 判断是否成功加载资源
            {
                Transform spriteTransform = equipPrefab.transform.Find("PrimaryRingSprite"); // 查找指定子对象
                if (spriteTransform != null) // 确保子对象存在
                {
                    SpriteRenderer spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>(); // 获取 SpriteRenderer 组件
                    if (spriteRenderer != null) // 判断组件是否存在
                    {
                        return spriteRenderer.sprite; // 返回 Sprite
                    }
                }
            }
        }
        if (equipName == "PrimaryNecklace")
        { GameObject equipPrefab = Resources.Load<GameObject>("Prefabs/Equip/PrimaryNecklaceFight"); // 加载 Prefab
            if (equipPrefab != null) // 判断是否成功加载资源
            {
                Transform spriteTransform = equipPrefab.transform.Find("PrimaryNecklaceSprite"); // 查找指定子对象
                if (spriteTransform != null) // 确保子对象存在
                {
                    SpriteRenderer spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>(); // 获取 SpriteRenderer 组件
                    if (spriteRenderer != null) // 判断组件是否存在
                    {
                        return spriteRenderer.sprite; // 返回 Sprite
                    }
                }
            }
        }
        if (equipName == "PrimaryShoe")
        { GameObject equipPrefab = Resources.Load<GameObject>("Prefabs/Equip/PrimaryShoeFight"); // 加载 Prefab
            if (equipPrefab != null) // 判断是否成功加载资源
            {
                Transform spriteTransform = equipPrefab.transform.Find("PrimaryShoeSprite"); // 查找指定子对象
                if (spriteTransform != null) // 确保子对象存在
                {
                    SpriteRenderer spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>(); // 获取 SpriteRenderer 组件
                    if (spriteRenderer != null) // 判断组件是否存在
                    {
                        return spriteRenderer.sprite; // 返回 Sprite
                    }
                }
            }
        }
        if (equipName == "PrimaryHelmet")
        { 
            GameObject equipPrefab = Resources.Load<GameObject>("Prefabs/Equip/PrimaryHelmetFight"); // 加载 Prefab
            if (equipPrefab != null) // 判断是否成功加载资源
            {
                Transform spriteTransform = equipPrefab.transform.Find("PrimaryHelmetSprite"); // 查找指定子对象
                if (spriteTransform != null) // 确保子对象存在
                {
                    SpriteRenderer spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>(); // 获取 SpriteRenderer 组件
                    if (spriteRenderer != null) // 判断组件是否存在
                    {
                        return spriteRenderer.sprite; // 返回 Sprite
                    }
                }
            }
        }
        // 如果未找到匹配项或出现问题，返回 null
        return null;
    }

    public void ComputeEquipAttribute()
    {
        GlobalPlayerAttribute.EquipDamage=PlayerClothAttribute.Damage+PlayerCloakAttribute.Damage+
            PlayerRingAttribute.Damage+PlayerNecklaceAttribute.Damage+PlayerShoeAttribute.Damage+
            PlayerHelmetAttribute.Damage;
        GlobalPlayerAttribute.EquipMaxHp=PlayerClothAttribute.HP+PlayerCloakAttribute.HP+
            PlayerRingAttribute.HP+PlayerNecklaceAttribute.HP+PlayerShoeAttribute.HP+
            PlayerHelmetAttribute.HP;
        GlobalPlayerAttribute.EquipMoveSpeed=PlayerClothAttribute.MoveSpeed+PlayerCloakAttribute.MoveSpeed+
            PlayerRingAttribute.MoveSpeed+PlayerNecklaceAttribute.MoveSpeed+PlayerShoeAttribute.MoveSpeed+
            PlayerHelmetAttribute.MoveSpeed;
        GlobalPlayerAttribute.EquipAttackSpeed=PlayerClothAttribute.DamageSpeed+PlayerCloakAttribute.DamageSpeed+
            PlayerRingAttribute.DamageSpeed+PlayerNecklaceAttribute.DamageSpeed+PlayerShoeAttribute.DamageSpeed+
            PlayerHelmetAttribute.DamageSpeed;
        GlobalPlayerAttribute.EquipCRIT=PlayerClothAttribute.CRIT+PlayerCloakAttribute.CRIT+
            PlayerRingAttribute.CRIT+PlayerNecklaceAttribute.CRIT+PlayerShoeAttribute.CRIT+
            PlayerHelmetAttribute.CRIT;
        GlobalPlayerAttribute.EquipCRITDamage=PlayerClothAttribute.CRITDamage+PlayerCloakAttribute.CRITDamage+
            PlayerRingAttribute.CRITDamage+PlayerNecklaceAttribute.CRITDamage+PlayerShoeAttribute.CRITDamage+
            PlayerHelmetAttribute.CRITDamage; 
        GlobalPlayerAttribute.EquipBloodSuck=PlayerClothAttribute.BloodSuck+PlayerCloakAttribute.BloodSuck+
            PlayerRingAttribute.BloodSuck+PlayerNecklaceAttribute.BloodSuck+PlayerShoeAttribute.BloodSuck+
            PlayerHelmetAttribute.BloodSuck;
        GlobalPlayerAttribute.EquipDenfense=PlayerClothAttribute.Denfense+PlayerCloakAttribute.Denfense+
            PlayerRingAttribute.Denfense+PlayerNecklaceAttribute.Denfense+PlayerShoeAttribute.Denfense+
            PlayerHelmetAttribute.Denfense;
        GlobalPlayerAttribute.EquipGoodFortune=PlayerClothAttribute.GoodFortune+PlayerCloakAttribute.GoodFortune+
            PlayerRingAttribute.GoodFortune+PlayerNecklaceAttribute.GoodFortune+PlayerShoeAttribute.GoodFortune+
            PlayerHelmetAttribute.GoodFortune;
    }

    // public void ComputeTotalAttribute()
    // {
    //     ComputeEquipAttribute();
    //     GlobalPlayerAttribute.TotalDamage = GlobalPlayerAttribute.PlayerDamage + GlobalPlayerAttribute.EquipDamage;
    //     GlobalPlayerAttribute.TotalMaxHp = GlobalPlayerAttribute.PlayerMaxHp + GlobalPlayerAttribute.EquipMaxHp;
    //     GlobalPlayerAttribute.TotalMoveSpeed = GlobalPlayerAttribute.PlayerMoveSpeed + GlobalPlayerAttribute.EquipMoveSpeed;
    //     GlobalPlayerAttribute.TotalAttackSpeed = GlobalPlayerAttribute.PlayerAttackSpeed + GlobalPlayerAttribute.EquipAttackSpeed;
    //     GlobalPlayerAttribute.TotalCRIT = GlobalPlayerAttribute.PlayerCRIT + GlobalPlayerAttribute.EquipCRIT;
    //     GlobalPlayerAttribute.TotalCRITDamage = GlobalPlayerAttribute.PlayerCRITDamage + GlobalPlayerAttribute.EquipCRITDamage;
    //     GlobalPlayerAttribute.TotalBloodSuck = GlobalPlayerAttribute.PlayerBloodSuck + GlobalPlayerAttribute.EquipBloodSuck;
    //     GlobalPlayerAttribute.TotalDenfense = GlobalPlayerAttribute.PlayerDenfense + GlobalPlayerAttribute.EquipDenfense;
    //     GlobalPlayerAttribute.TotalGoodFortune = GlobalPlayerAttribute.PlayerGoodFortune + GlobalPlayerAttribute.EquipGoodFortune;
    // }

    /// <summary>
    /// 出售所有选中类型的装备
    /// </summary>
    public void SellAllSelectedEquips(List<int> equipIdsToRemove, bool isWhite, bool isGreen, bool isBlue)
    {
        // 从内存中同步移除装备数据
        if(isWhite)
        {
            // 从内存中移除白色装备
            foreach (var equipId in equipIdsToRemove.FindAll(id => WhiteEquipidTable.ContainsKey(id)))
            {
                var equipData = WhiteEquipidTable[equipId];
                EquipidTable.Remove(equipId);
                EquipIdList.Remove(equipData);
                EquipidSprite.Remove(equipId);
                WhiteEquipidTable.Remove(equipId);
            }
            Debug.Log("已从内存中移除白色装备。");
        }
        
        if(isGreen)
        {
            // 从内存中移除绿色装备
            foreach (var equipId in equipIdsToRemove.FindAll(id => GreenEquipidTable.ContainsKey(id)))
            {
                var equipData = GreenEquipidTable[equipId];
                EquipidTable.Remove(equipId);
                EquipIdList.Remove(equipData);
                EquipidSprite.Remove(equipId);
                GreenEquipidTable.Remove(equipId);
            }
            Debug.Log("已从内存中移除绿色装备。");
        }
        
        if(isBlue)
        {
            // 从内存中移除蓝色装备
            foreach (var equipId in equipIdsToRemove.FindAll(id => BlueEquipidTable.ContainsKey(id)))
            {
                var equipData = BlueEquipidTable[equipId];
                EquipidTable.Remove(equipId);
                EquipIdList.Remove(equipData);
                EquipidSprite.Remove(equipId);
                BlueEquipidTable.Remove(equipId);
            }
            Debug.Log("已从内存中移除蓝色装备。");
        }
        
        // 如果没有装备需要删除，直接返回
        if(equipIdsToRemove.Count == 0)
        {
            Debug.LogWarning("没有装备需要删除");
            return;
        }
        
        // 启动异步任务处理MySQL操作，一次性删除所有选中装备
        System.Threading.Tasks.Task.Run(() => DeleteAllSelectedEquipsFromDatabase(equipIdsToRemove));
    }

    // 异步处理MySQL部分，一次性删除所有选中的装备
    private void DeleteAllSelectedEquipsFromDatabase(List<int> equipIds)
    {
        if(equipIds.Count == 0) return;
        
        MySqlTransaction transaction = null;
        try
        {
            // 后台线程执行MySQL操作
            transaction = ConnectMysql.Connection.BeginTransaction();
            
            string sql = "DELETE FROM equip WHERE equipid IN (" + string.Join(", ", equipIds) + ")";
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection, transaction);
            
            int rowsAffected = command.ExecuteNonQuery();
            transaction.Commit();
            
            // 使用主线程安全的方式记录日志
            Tool.UnityMainThreadDispatcher.Instance().Enqueue(() => {
                Debug.Log($"{rowsAffected} 件装备已从数据库中移除");
                Debug.Log("事务提交成功");
            });
        }
        catch(MySqlConnector.MySqlException ex)
        {
            if(transaction != null)
                transaction.Rollback();
                
            // 使用主线程安全的方式记录错误
            Tool.UnityMainThreadDispatcher.Instance().Enqueue(() => {
                Debug.LogError($"删除装备时出错: {ex.Message}. 事务已回滚");
            });
        }
    }
    
}
