using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendApplicationResponse 
{
    public int id;
    public int fromuserid;
    public int touserid;
    public string message;
    public string status; // pending, accepted, rejected
    public string created_at;
    public string updated_at;
    public string requester_username; // 请求者的用户名
}


//好友列表item
public class FriendListItemResponse
{
    public int id;
    public int fromuserid;
    public int touserid;
    public string status;
    public string created_at;
    public string updated_at;
    public string friend_username;
    public string friend_level;
}

public class FriendConfig
{
    public static List<FriendApplicationResponse> friendApplicationList= new List<FriendApplicationResponse>();
    public static List<FriendListItemResponse> friendList= new List<FriendListItemResponse>();
}
