using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Common
{
    public class EditorTool : Singleton<EditorTool>
    {

        /// <summary>
        /// 场景提示信息
        /// </summary>
        /// <param name="content"></param>
        public static void ShowNotification(string content)
        {
            if (SceneView.lastActiveSceneView != null)
            {
                SceneView.lastActiveSceneView.ShowNotification(new GUIContent(content));
            }
        }

    }
}