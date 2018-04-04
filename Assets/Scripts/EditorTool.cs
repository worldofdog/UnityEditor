using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;

namespace Common
{
    public class EditorTool : Singleton<EditorTool>
    {
        /// <summary>
        /// 获取当前用户计算机名字
        /// </summary>
        /// <returns></returns>
        public static string GetUserName()
        {
            string persistentDataPath = Application.persistentDataPath;
            List<int> signList = new List<int>();
            for (int i = 0; i < persistentDataPath.Length; i++)
            {
                if (persistentDataPath[i] == '/')
                    signList.Add(i);
            }
            string userName = persistentDataPath.Substring(signList[1] + 1, signList[2] - signList[1] - 1);
            return userName;
        }

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

        /// <summary>
        /// 将屏幕坐标转换为世界坐标
        /// </summary>
        /// <param name="pos">屏幕坐标</param>
        /// <returns></returns>
        public static Vector3 ScreenPosToWorld(Vector3 pos)
        {
            if (Camera.current)
            {
                pos = new Vector2(Event.current.mousePosition.x,
                    Camera.current.pixelHeight - Event.current.mousePosition.y);
                Ray ray = Camera.current.ScreenPointToRay(pos);
                RaycastHit hit;
                Physics.Raycast(ray, out hit);

                return hit.point;
            }
            else
            {
                DisplayDialog("缺少对应Camera！");
                return Vector3.zero;
            }
        }

        /// <summary>
        /// 弹窗提示信息
        /// </summary>
        /// <param name="dialog">内容</param>
        /// <param name="title">标题</param>
        /// <param name="button">按钮</param>
        public static void DisplayDialog(string dialog, string title = "提示", string button = "好的")
        {
            EditorUtility.DisplayDialog(title, dialog, button);
        }

        /// <summary>
        /// 获取场景物体贴地坐标
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static Vector3 GetLevelObjectPosition(Vector3 pos, float radius = 0f, int layerMask = 1 << 8)
        {
            RaycastHit hit_info;
            float max_distance = 150f;
            pos.y += 100f;
            bool ret = (radius == 0) ? Physics.Raycast(pos, Vector3.down, out hit_info, max_distance, layerMask) :
                Physics.SphereCast(pos, radius, Vector3.down, out hit_info, max_distance, layerMask);
            pos.y = ret ? hit_info.point.y : 0;

            return pos;
        }

        /// <summary>
        /// 创建一个空的物体
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static GameObject CreateEmptyGameObject(string name)
        {
            GameObject go = new GameObject();
            go.name = name;
            go.transform.localPosition = Vector3.zero;

            return go;
        }

        /// <summary>
        /// 创建一个空的物体
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static GameObject CreateEmptyGameObject(string name, Transform parent)
        {
            GameObject go = new GameObject();
            go.name = name;
            go.transform.parent = parent;
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;

            return go;
        }

    }
}