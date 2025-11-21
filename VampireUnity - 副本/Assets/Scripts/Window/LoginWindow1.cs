using System;
using System.Collections;
using System.Collections.Generic;
using Mysql;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class LoginWindow1 : MonoBehaviour
{
    public InputField usernameInputField; 
    public InputField passwordInputField;
    public Button loginBtn;
    public Button registerBtn;
    public Button closeBtn;
    public string username;
    public string password;
    void Start()
    {
        ObserverModuleManager.S.UnRegisterEvent("LoginSuccess", OnLoginSuccess);
        ObserverModuleManager.S.RegisterEvent("LoginSuccess",OnLoginSuccess);
        closeBtn.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        loginBtn.onClick.AddListener(() =>
        {
            Debug.Log("点击登陆按钮");
             username = usernameInputField.text;
            password = passwordInputField.text;
            ServerConnect.S.SendLoginRequest(username, password);
        });
        registerBtn.onClick.AddListener(() =>
        {
            UserController.S.GetMaxUserId(); // 获取当前最大userid
            int newUserId = UserController.S.maxUserid + 1;
            UserController.S.InsertUser(newUserId,usernameInputField.text,passwordInputField.text);
            PlayerInfoController.S.RegisterInit(newUserId);
            Debug.Log("注册成功");
            gameObject.SetActive(false);
        });
    }
    
    //收到登录成功的消息
    public void OnLoginSuccess(object[] args)
    {
        var userData = JsonConvert.DeserializeObject<UserData>(JsonConvert.SerializeObject(args[0]));
        Debug.Log($"用户ID: {userData.userid}, 用户名: {userData.username}");
        GlobalUserInfo.UserName = username;
        GlobalUserInfo.PassWord =password;
        GlobalUserInfo.Userid = userData.userid;
        GlobalUserInfo.UserName = userData.username;
        MainWindow1.IsLogin= true;
        gameObject.SetActive(false);
    }

   
}
