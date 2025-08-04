using System.Collections;
using System.Collections.Generic;
using Mysql;
using UnityEngine;
using UnityEngine.UI;

public class LoginWindow1 : MonoBehaviour
{
    public InputField usernameInputField; 
    public InputField passwordInputField;
    public Button loginBtn;
    public Button registerBtn;
    public Button closeBtn;
    void Start()
    {
        closeBtn.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        loginBtn.onClick.AddListener(() =>
        {
            Debug.Log("点击登陆按钮");
            string username = usernameInputField.text;
            string password = passwordInputField.text;
            //到ConnectMysql中的Users列表验证用户名和密码
            bool isLogin = false;
            foreach (var user in UserController.S.Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    UserController.S.selfuserId = user.UserId;
                    Debug.Log(UserController.S.selfuserId);
                    isLogin = true;
                    Debug.Log("登陆成功");
                    // 设置全局UserInfo
                    GlobalUserInfo.Userid = user.UserId;
                    GlobalUserInfo.UserName = user.Username;
                    GlobalUserInfo.PassWard = user.Password;
                    MainWindow1.IsLogin= true;
                    break;
                }
            }
            if (isLogin)
            {
                // 登陆成功，进入游戏
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("登陆失败");
                // 提示用户登陆失败
            }
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
