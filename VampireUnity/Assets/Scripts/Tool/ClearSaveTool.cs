#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

public static class ClearSaveTool
{
    [MenuItem("Tool/清除存档", priority = 0)]
    public static void ClearSaveData()
    {
        var path = Path.Combine(Application.persistentDataPath, "store.json");
        if (File.Exists(path))
        {
            File.Delete(path);
            EditorUtility.DisplayDialog("清除存档", $"已删除存档：\n{path}", "确定");
            Debug.Log($"[Tool] 清除存档成功：{path}");
        }
        else
        {
            EditorUtility.DisplayDialog("清除存档", $"未找到存档文件：\n{path}", "确定");
            Debug.LogWarning($"[Tool] 清除存档失败，文件不存在：{path}");
        }
    }
}
#endif





