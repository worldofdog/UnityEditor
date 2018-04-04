using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.IO;

namespace Common
{
    public class EditorFile : Singleton<EditorFile>
    {
        /// <summary>
        /// 获取文件名字
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static string GetFileName(FileInfo info)
        {
            int count = 0;
            for (int i = info.Name.Length - 1; i >= 0; i--)
            {
                if (info.Name[i] == '.')
                {
                    count = i;
                    break;
                }
            }

            return info.Name.Substring(0, count);
        }

        /// <summary>
        /// 获取文件格式
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static string GetFileFormat(FileInfo info)
        {
            int count = 0;
            for (int i = info.Name.Length - 1; i >= 0; i--)
            {
                if (info.Name[i] == '.')
                {
                    count = i;
                    break;
                }
            }

            return info.Name.Substring(count + 1, info.Name.Length - count - 1);
        }

        /// <summary>
        /// 将Assets路径转换为File路径
        /// </summary>
        /// <param name="path">Assets/Editor/...</param>
        /// <returns></returns>
        public static string AssetsPathToFilePath(string path)
        {
            string m_path = Application.dataPath;
            m_path = m_path.Substring(0, m_path.Length - 6);
            m_path += path;

            return m_path;
        }

        /// <summary>
        /// 将File路径转换为Assets路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string FilePathToAssetsPath(string path)
        {
            string m_path = Application.dataPath;

            m_path = path.Substring(m_path.Length - 6, path.Length - m_path.Length + 6);

            return m_path;
        }
    }
}
