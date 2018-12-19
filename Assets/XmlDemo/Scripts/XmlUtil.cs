
#region 版权信息
/*
 * -----------------------------------------------------------
 *  Copyright (c) KeJun All rights reserved.
 * -----------------------------------------------------------
 *		描述: 
 *      创建者：陈伟超
 *      创建时间: 2018/12/19 12:03:44
 *  
 */
#endregion


using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Framework.Xml
{
    /// <summary>  
    /// <remarks>Xml常用功能</remarks>  
    /// </summary>  
    public class XmlUtil
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Private Methods

        #endregion

        #region Protected & Public Methods
 
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
        /// 获取xml文档根节点
        /// </summary>
        /// <param name="path">xml文档路径</param>
        /// <returns></returns>
        public static XmlNode GetDocumentElement(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            return xmlDoc.DocumentElement;
        }
        #endregion
    }
}