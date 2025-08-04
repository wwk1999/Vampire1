using System.Reflection;
using Com.Tal.Unity.Core;
using UnityEngine;

// ReSharper disable once CheckNamespace
/// <summary>
/// Unity singleton
/// </summary>
/// <typeparam name="T"></typeparam>
public class XSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    private static T Singleton
    {
        get
        {
            if (_instance) return _instance;

            var type = typeof(T);
            if (!_instance) _instance = FindObjectOfType(type) as T;
            var singletonAtt = type.GetCustomAttribute<SingletonNameAttribute>();
            var nameSingleton = singletonAtt?.SingletonName ?? type.ToString();
            _instance = new GameObject(nameSingleton).AddComponent<T>();
            if (singletonAtt?.IsStatic == true)
            {
                _instance.hideFlags = HideFlags.NotEditable;
            }

            return _instance;
        }
    }


    public void Reset()
    {
        if (!_instance) return;
        Destroy(_instance.gameObject);
        _instance = null;
    }

    /// <summary>
    /// See as Singleton
    /// </summary>
    /// <value>The s.</value>
    public static T S => Singleton;

    protected virtual void Awake()
    {
        if (_instance)
        {
            Debug.LogError($"Had create {_instance}");
        }

        _instance = this as T;
        var att = typeof(T).GetCustomAttribute<NeedDestroyAttribute>();
        //if (att == null) DontDestroyOnLoad(this.gameObject);
    }

    public static (bool, T) TryGet()
    {
        return _instance ? (true, _instance) : (false, null);
    }

    /// <summary>
    /// get don't auto create
    /// </summary>
    /// <returns></returns>
    public static T G()
    {
        return _instance ? _instance : null;
    }
#if UNITY_EDITOR
    private void OnApplicationQuit()
    {
        DestroyImmediate(gameObject);
    }
#endif
}
    