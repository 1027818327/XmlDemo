using System;
using System.IO;
using System.Xml.Serialization;

namespace XStream
{
    /// <summary>  
    /// <remarks>Xml序列化与反序列化</remarks>  
    /// <creator>zhangdapeng</creator>  
    /// </summary>  
    public class XmlSerializeUtil
    {
        #region 反序列化  
        /// <summary>  
        /// 反序列化  
        /// </summary>  
        /// <param name="type">类型</param>  
        /// <param name="xml">XML字符串</param>  
        /// <returns></returns>  
        public static object Deserialize(Type type, string xml)
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer xmldes = new XmlSerializer(type);
                return xmldes.Deserialize(sr);
            }
        }
        /// <summary>  
        /// 反序列化  
        /// </summary>  
        /// <param name="type"></param>  
        /// <param name="xml"></param>  
        /// <returns></returns>  
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }
        #endregion

        #region 序列化  
        /// <summary>  
        /// 序列化  
        /// </summary>  
        /// <param name="type">类型</param>  
        /// <param name="obj">对象</param>  
        /// <returns></returns>  
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            //序列化对象  
            xml.Serialize(Stream, obj);
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }

        /// <summary>
        /// 用于解析xml的方法
        /// </typeparam>
        /// <param name="path">xml文件的路径</param>
        /// <param name="ms">用于接受xml文件解析的结果</param>
        public static void LoadXml<T>(string path, ref T ms) where T : class
        {
            try
            {
                //通过流根据路径去读取文件
                using (TextReader reader = new StreamReader(path))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    var item = (T)serializer.Deserialize(reader);
                    if (item != null)
                    {
                        ms = item;
                    }
                }
            }
            catch (Exception ex)
            {
                //用于捕捉异常避免解析过程中出现错误导致程序死掉
                //将错误打印出来
                Debuger.LogError(ex.Message);
            }
        }

        #endregion
    }
}