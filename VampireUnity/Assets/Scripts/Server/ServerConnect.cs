using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Spine;
using UnityEngine;
using Newtonsoft.Json;
using Tool;


// 请求消息结构
public class GameRequest
{
    public string type { get; set; }
    public string action { get; set; }
    public object data { get; set; }
    public long timestamp { get; set; }
}

// 响应消息结构
public class GameResponse
{
    public bool success;
    public int code;
    public string message;
    public object data;
    public string requestId;
    public long timestamp;
}

public class AddFriendData
{
    public int touserid { get; set; }
    public string message { get; set; }
}

// 用户数据响应结构
public class UserData
{
    public int userid;
    public string username;
}

// 用户注册/登录数据
public class AuthData
{
    public string username { get; set; }
    public string password { get; set; }
}
//玩家信息数据
public class PlayerInfoData
{
    public int level { get; set; }
    public int experience { get; set; }
    public int gamelevel { get; set; }
    public int bloodenergy { get; set; }
}
// 装备数据
public class EquipmentData
{ 
    public int type { get; set; }
    public int quality { get; set; }
    public int damage { get; set; }
    public int crit { get; set; }
    public int critdamage { get; set; }
    public int damagespeed { get; set; }
    public int bloodsuck { get; set; }
    public int hp { get; set; }
    public int movespeed { get; set; }
    public int suitid { get; set; }
    public string suitname { get; set; }
    public int equip_type_id { get; set; }
    public string equip_type_name { get; set; }
    public int defense { get; set; }
    public int goodfortune { get; set; }
    public string equipname { get; set; }
}

public class ResponseFriendApplication
{
    public int fromuserid { get; set; }
    public bool accept { get; set; }
}

public class RemoveFrienddAData
{
    public int friend_userid { get; set; }
}

// 添加事件委托
public delegate void OnLoginResponseHandler(GameResponse response);//登陆委托
public delegate void GetPlayerInfoResponseHandler(GameResponse response);//获取玩家信息委托
public delegate void GetAllEquipResponseHandler(GameResponse response);//获取所有装备委托
public delegate void GetExPlayerTableResponseHandler(GameResponse response);//获取人物经验表委托

public delegate void GetFriendApplicationResponseHandler(GameResponse response);//获取好友申请委托

public delegate void GetFriendListResponseHandler(GameResponse response);//获取好友列表委托
public delegate void GetTuiJianFriendHandler(GameResponse response);//获取推荐好友列表委托
public delegate void GetSourceStoneConfigHandler(GameResponse response);//获取源石配置委托
public delegate void SaveEquipHandler(GameResponse response);//保存装备委托
public delegate void GetLevelRankHandler(GameResponse response);//获取等级排行榜委托
public delegate void GetUserLevelRankHandler(GameResponse response);//获取个人等级排行榜委托
public delegate void GetUserMonsterCountRankHandler(GameResponse response);//获取个人等级排行榜委托
public delegate void GetMonsterCountRankHandler(GameResponse response);//获取个人等级排行榜委托
public delegate void GetUserSourceStoneHandler(GameResponse response);//获取用户源石委托
public delegate void AddUserSourceStoneHandler(GameResponse response);//添加用户源石委托
public delegate void GetPlayerEquipHandler(GameResponse response);//获取玩家穿戴装备委托











public class ServerConnect : XSingleton<ServerConnect>
{
    private ClientWebSocket webSocket;
    private CancellationTokenSource cancellationToken;
    private string serverUrl = "ws://101.201.51.135:8080/ws";
    private OnLoginResponseHandler OnLoginResponse;
    private GetPlayerInfoResponseHandler OnGetPlayerInfoResponse;
    private GetAllEquipResponseHandler OnGetAllEquipResponse;
    private GetExPlayerTableResponseHandler OnGetExPlayerTableResponse;
    private GetFriendApplicationResponseHandler OnGetFriendApplicationResponse;
    private GetFriendListResponseHandler OnGetFriendListResponse;
    private GetTuiJianFriendHandler OnGetTuiJianFriendResponse;
    private GetSourceStoneConfigHandler OnGetSourceStoneConfigResponse;
    private SaveEquipHandler OnSaveEquipResponse;
    private GetLevelRankHandler OnGetLevelRankResponse;
    private GetUserLevelRankHandler OnGetUserLevelRankResponse;
    private GetUserMonsterCountRankHandler OnGetUserMonsterCountRankResponse;
    private GetMonsterCountRankHandler OnGetMonsterCountRankResponse;
    private GetUserSourceStoneHandler OnGetUserSourceStoneResponse;
    private AddUserSourceStoneHandler OnAddUserSourceStoneResponse;
    private GetPlayerEquipHandler OnGetPlayerEquipResponse;

    

    // 添加线程安全的连接状态标志
    private volatile bool _isConnected = false;
    private readonly object _lockObject = new object();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        OnLoginResponse+= LoginResponse;
        OnGetPlayerInfoResponse+= GetPlayerInfoResponse;
        OnGetAllEquipResponse+= GetAllEquipResponse;
        OnGetExPlayerTableResponse += GetExPlayerTableResponse;
        OnGetLevelRankResponse += GetLevelRankResponse;
        OnGetUserLevelRankResponse += GetUserLevelRankResponse;
        OnGetUserMonsterCountRankResponse += GetUserMonsterCountRankResponse;
        OnGetMonsterCountRankResponse += GetMonsterCountRankResponse;
        OnGetUserSourceStoneResponse += GetUserSourceStoneResponse;
        OnAddUserSourceStoneResponse += AddUserSourceStoneResponse;
        OnGetPlayerEquipResponse += GetPlayerEquipResponse;
        
       
        
        webSocket = new ClientWebSocket();
        cancellationToken = new CancellationTokenSource();
    }
    
    
    
    // 获取玩家穿戴装备处理方法
    void GetPlayerEquipResponse(GameResponse response)
    {
        if (response.success)
        {
            Debug.Log("获取玩家穿戴装备成功！");
            if (response.data != null)
            {
                ObserverModuleManager.S.SendEvent("GetPlayerEquipSuccess", response.data);
            }
        }
        else
        {
            Debug.LogError($"获取玩家穿戴装备失败: {response.message}");
        }
    }
    
    
    // 添加用户源石响应处理方法
    void AddUserSourceStoneResponse(GameResponse response)
    {
        if (response.success)
        {
            Debug.Log("添加用户源石成功！");
            if (response.data != null)
            {
                ObserverModuleManager.S.SendEvent("AddUserSourceStoneSuccess", response.data);
            }
        }
        else
        {
            Debug.LogError($"添加用户源石失败: {response.message}");
        }
    }
    
    
    
    
    
    
    // 添加获取用户源石响应处理方法
    void GetUserSourceStoneResponse(GameResponse response)
    {
        if (response.success)
        {
            Debug.Log("获取用户源石成功！");
            if (response.data != null)
            {
                ObserverModuleManager.S.SendEvent("GetUserSourceStoneSuccess", response.data);
            }
        }
        else
        {
            Debug.LogError($"获取用户源石失败: {response.message}");
        }
    }
    
    
    
    
    
    // 添加获取击杀排行榜响应处理方法
    void GetMonsterCountRankResponse(GameResponse response)
    {
        if (response.success)
        {
            Debug.Log("获取击杀排行榜成功！");
            if (response.data != null)
            {
                ObserverModuleManager.S.SendEvent("GetMonsterCountRankSuccess", response.data);
            }
        }
        else
        {
            Debug.LogError($"获取击杀排行榜失败: {response.message}");
        }
    }
    
    
    // 添加获取个人击杀排行榜响应处理方法
    void GetUserMonsterCountRankResponse(GameResponse response)
    {
        if (response.success)
        {
            Debug.Log("获取个人击杀排行榜成功！");
            if (response.data != null)
            {
                ObserverModuleManager.S.SendEvent("GetUserMonsterCountRankSuccess", response.data);
            }
        }
        else
        {
            Debug.LogError($"获取个人击杀排行榜失败: {response.message}");
        }
    }
    
    
    
    // 添加获取个人等级排行榜响应处理方法
    void GetUserLevelRankResponse(GameResponse response)
    {
        if (response.success)
        {
            Debug.Log("获取个人等级排行榜成功！");
            if (response.data != null)
            {
                ObserverModuleManager.S.SendEvent("GetUserLevelRankSuccess", response.data);
            }
        }
        else
        {
            Debug.LogError($"获取个人等级排行榜失败: {response.message}");
        }
    }
    
    
    
    
    // 添加获取等级排行榜响应处理方法
    void GetLevelRankResponse(GameResponse response)
    {
        if (response.success)
        {
            Debug.Log("获取等级排行榜成功！");
            if (response.data != null)
            {
                ObserverModuleManager.S.SendEvent("GetLevelRankSuccess", response.data);
            }
        }
        else
        {
            Debug.LogError($"获取等级排行榜失败: {response.message}");
        }
    }
    
    
    
    
    
    
    
    
    
    
    
    
    void GetExPlayerTableResponse(GameResponse response)
    {
        if (response.success)
        {
            Debug.Log("获取人物经验表信息成功！");
            if (response.data != null)
            {
                ObserverModuleManager.S.SendEvent("GetExPlayerTableSuccess", response.data);
            }
        }
        else
        {
            Debug.LogError($"获取人物经验表信息失败: {response.message}");
        }
    }
    void GetAllEquipResponse(GameResponse response)
    {
        if (response.success)
        {
            Debug.Log("获取所有装备信息成功！");
            if (response.data != null)
            {
                ObserverModuleManager.S.SendEvent("GetAllEquipSuccess", response.data);
            }
        }
        else
        {
            Debug.LogError($"获取所有装备信息失败: {response.message}");
        }
    }

    //处理登陆消息
    void LoginResponse(GameResponse response)
    {
        if (response.success)
        {
            Debug.Log("登录成功！");
            if (response.data != null)
            {
                ObserverModuleManager.S.SendEvent("LoginSuccess", response.data);
            }
        }
    }
    
    void GetPlayerInfoResponse(GameResponse response)
    {
        if (response.success)
        {
            Debug.Log("获取玩家信息成功！");
            if (response.data != null)
            {
                ObserverModuleManager.S.SendEvent("GelPlayerInfoSuccess", response.data);
            }
        }
    }

    
    // 添加线程安全的连接状态检查方
    
    public async Task<bool> ConnectAsync()
    {
        try
        {
            await webSocket.ConnectAsync(new Uri(serverUrl), cancellationToken.Token);
            Debug.Log("✓ WebSocket 连接成功");
            
            lock (_lockObject)
            {
                _isConnected = true;
            }
                
            // 启动接收消息的任务
            _ = Task.Run(ReceiveMessages);
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"✗ WebSocket 连接失败: {ex.Message}");
            lock (_lockObject)
            {
                _isConnected = false;
            }
            return false;
        }
    }
    
    // 发送消息方法
    public async Task SendMessageAsync(GameRequest request)
    {
        try
        {
            string jsonMessage = JsonConvert.SerializeObject(request);
            byte[] buffer = Encoding.UTF8.GetBytes(jsonMessage);
            await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, cancellationToken.Token);
            Debug.Log($"→ 发送消息: {jsonMessage}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"发送消息失败: {ex.Message}");
            lock (_lockObject)
            {
                _isConnected = false;
            }
        }
    }
    
    // 接收消息
    private async Task ReceiveMessages()
    {
        var buffer = new byte[4096];
            
        while (webSocket.State == WebSocketState.Open)
        {
            try
            {
                // 收集完整的消息
                var messageBuilder = new StringBuilder();
                WebSocketReceiveResult result;
                
                do
                {
                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken.Token);
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        messageBuilder.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));
                    }
                } while (!result.EndOfMessage);
                    
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var message = messageBuilder.ToString();
                    Debug.Log($"原始接收消息: {message}"); // 添加这行来查看原始消息
                    
                    var response = JsonConvert.DeserializeObject<GameResponse>(message);
                        
                    Debug.Log($"← 接收响应: {response.message} (Code: {response.code})");
                        
                    if (response.data != null)
                    {
                        Debug.Log($"   数据: {response.data}");
                    }

                    // 在主线程中处理响应
                    UnityMainThreadDispatcher.Instance().Enqueue(()=>ProcessResponse(response));
                   
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    Debug.Log("WebSocket连接已关闭");
                    break;
                }
            }
            catch (OperationCanceledException)
            {
                Debug.Log("WebSocket接收任务已取消");
                break;
            }
            catch (WebSocketException ex)
            {
                // 只有在连接真正关闭时才退出循环
                if (webSocket.State == WebSocketState.Aborted || webSocket.State == WebSocketState.Closed)
                {
                    Debug.Log("WebSocket连接已关闭");
                    break;
                }
                else
                {
                    Debug.LogError($"WebSocket接收错误: {ex.Message}");
                    // 临时错误，继续尝试接收
                    await Task.Delay(1000); // 等待1秒后重试
                    continue;
                }
            }
            catch (Exception ex)
            {
                // 只有在连接真正关闭时才退出循环
                if (webSocket.State == WebSocketState.Aborted || webSocket.State == WebSocketState.Closed)
                {
                    Debug.Log("WebSocket连接已关闭");
                    break;
                }
                else
                {
                    Debug.LogError($"接收消息错误: {ex.Message}");
                    // 临时错误，继续尝试接收
                    await Task.Delay(1000); // 等待1秒后重试
                    continue;
                }
            }
        }
        
        // 只有在循环真正退出时才更新连接状态
        lock (_lockObject)
        {
            _isConnected = false;
        }
        Debug.Log("WebSocket接收线程已退出");
    }

    // 处理响应的方法
    private void ProcessResponse(GameResponse response)
    {
        Debug.Log($"ProcessResponse开始处理响应，requestId: {response.requestId}");
        
        // 根据requestId判断是什么类型的响应
        if (response.requestId != null)
        {
            Debug.Log($"检查requestId: {response.requestId}");
            
            if (response.requestId.Contains("login"))
            {
                OnLoginResponse?.Invoke(response);
                Debug.Log("登录响应已处理");
            }
            else if (response.requestId.Contains("getPlayerInfo"))
            {
                OnGetPlayerInfoResponse?.Invoke(response);
                Debug.Log("获取玩家信息响应已处理");
            }
            else if (response.requestId.Contains("equip_getEquip_"))
            {
                OnGetAllEquipResponse?.Invoke(response);
                Debug.Log("获取所有装备响应已处理");
            }else if (response.requestId.Contains("experience_getAllLevels"))
            {
                OnGetExPlayerTableResponse?.Invoke(response);
                Debug.Log("获取人物经验表响应已处理");
            }else if (response.requestId.Contains("friend_friendRequest"))
            {
                OnGetFriendApplicationResponse?.Invoke(response);
                Debug.Log("获取好友申请响应已处理");
            }else if (response.requestId.Contains("friend_getFriends"))
            {
                OnGetFriendListResponse?.Invoke(response);
                Debug.Log("获取好友列表响应已处理");
            }else if (response.requestId.Contains("friend_getRecommendedFriends"))
            {
                OnGetTuiJianFriendResponse?.Invoke(response);
            }else if (response.requestId.Contains("sourcestone_getAllSourceStones"))
            {
                OnGetSourceStoneConfigResponse?.Invoke(response);
                Debug.Log("获取源石配置响应已处理");
            }else if (response.requestId.Contains("equip_saveEquip"))
            {
                OnSaveEquipResponse?.Invoke(response);
                Debug.Log("保存装备响应已处理");
            }else if (response.requestId.Contains("ranking_getPlayerRanking"))
            {
                OnGetLevelRankResponse?.Invoke(response);
                Debug.Log("获取等级排行榜响应已处理");
            }else if (response.requestId.Contains("ranking_getUserRank"))
            {
                OnGetUserLevelRankResponse?.Invoke(response);
                Debug.Log("获取个人等级排行榜响应已处理");
            }else if (response.requestId.Contains("killcount_getUserKillRank"))
            {
                OnGetUserMonsterCountRankResponse?.Invoke(response);
                Debug.Log("获取个人击杀排行榜响应已处理");
            }else if (response.requestId.Contains("killcount_getKillRanking"))
            {
                OnGetMonsterCountRankResponse?.Invoke(response);
                Debug.Log("获取击杀排行榜响应已处理");
            }else if (response.requestId.Contains("usersourcestone_getUserSourceStones"))
            {
                OnGetUserSourceStoneResponse?.Invoke(response);
                Debug.Log("获取用户源石响应已处理");
            }else if (response.requestId.Contains("usersourcestone_addUserSourceStone"))
            {
                OnAddUserSourceStoneResponse?.Invoke(response);
                Debug.Log("添加用户源石响应已处理");
            }else if (response.requestId.Contains("userequip_getEquippedItems"))
            {
                OnGetPlayerEquipResponse?.Invoke(response);
                Debug.Log("获取玩家穿戴装备已处理");
            }
           
            
            
           
           
        }
        else
        {
            Debug.LogWarning("响应中没有requestId字段");
        }
    }
    
    
    //发送登陆请求
    public async Task<bool> SendLoginRequest(string username, string password)
    {
        var loginRequest = new GameRequest
        {
            type = "auth",
            action = "login",
            data = new AuthData
            {
                username = username,
                password = password
            },
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        await SendMessageAsync(loginRequest);
        return true;
    }
    
    // //发送登出请求
    // public async Task<bool> SendOutLoginRequest()
    // {
    //     if (!IsWebSocketConnected())
    //     {
    //         Debug.LogError("WebSocket 未连接");
    //         return false;
    //     }
    //
    //     var outloginRequest = new GameRequest
    //     {
    //         type = "auth",
    //         action = "logout",
    //         data = new AuthData
    //         {},
    //         timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
    //     };
    //
    //     await SendMessageAsync(outloginRequest);
    //     return true;
    // }
    
    
    //发送获取玩家信息请求
    public async Task<bool> SendgetPlayerInfoRequest()
    {
        var getPlayerInfoRequest = new GameRequest
        {
            type = "player",
            action = "getPlayerInfo",
            data = new AuthData
                {},
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        await SendMessageAsync(getPlayerInfoRequest);
        return true;
    }
    
    
    //发送获取玩家信息请求
    public async Task<bool> SendGetAllEquipRequest()
    {

        var getAllEquipRequest = new GameRequest
        {
            type = "equip",
            action = "getEquip",
            data = new AuthData
                {},
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        await SendMessageAsync(getAllEquipRequest);
        return true;
    }
    
    //发送获取经验表请求
    public async Task<bool> SendGetExPlayerTableRequest()
    {
       
        var getExPlayerTableRequest = new GameRequest
        {
            type = "experience",
            action = "getAllLevels",
            data = new AuthData
                {},
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        await SendMessageAsync(getExPlayerTableRequest);
        return true;
    }
    
    //发送保存装备请求
    public async Task<bool> SendSaveEquipRequest(EquipTable equip)
    {

        var saveEquipRequest = new GameRequest
        {
            type = "equip",
            action = "saveEquip",
            data = new EquipmentData
                { 
                    type = 2,
                    quality = equip.Quality,
                    damage = equip.Damage,
                    crit = equip.CRIT,
                    critdamage = equip.CRITDamage,
                    damagespeed = equip.DamageSpeed,
                    bloodsuck = equip.BloodSuck,
                    hp = equip.HP,
                    movespeed = equip.MoveSpeed,
                    suitid = equip.suitid,
                    suitname = equip.suitname,
                    equip_type_id = equip.equip_type_id,
                    equip_type_name = equip.equip_type_name,
                    defense = equip.Defense,
                    goodfortune = equip.GoodFortune,
                    equipname = equip.EquipName
                },
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        await SendMessageAsync(saveEquipRequest);
        return true;
    }
    
    //发送更新人物信息请求
    public async Task<bool> SendUpdatePlayerInfoRequest(int level,int experience,int gamelevel,int bloodenergy)
    {

        var UpdatePlayerInfoRequest = new GameRequest
        {
            type = "player",
            action = "updatePlayer",
            data = new PlayerInfoData
            {
                level = level,
                experience = experience,
                gamelevel = gamelevel,
                bloodenergy = bloodenergy
            },
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        await SendMessageAsync(UpdatePlayerInfoRequest);
        return true;
    }

    private async void OnDestroy()
    {
        try
        {
            if (webSocket != null && webSocket.State == WebSocketState.Open)
            {
                // 发送关闭帧
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "正常关闭", CancellationToken.None);
                Debug.Log("WebSocket连接已正常关闭");
            }
        }
        catch (Exception ex)
        {
            Debug.Log($"关闭WebSocket时出现异常: {ex.Message}");
        }
        finally
        {
            cancellationToken?.Cancel();
            webSocket?.Dispose();
        }
    }
}

