
#region 版权信息
/*
 * -----------------------------------------------------------
 *  Copyright (c) KeJun All rights reserved.
 * -----------------------------------------------------------
 *		描述: 
 *      创建者：DESKTOP-1050N1H\luoyikun
 *      创建时间: 2018/12/17 15:35:57
 *  
 */
#endregion


using System;
using System.IO;
using System.Xml;
using UnityEngine;
using Framework.Unity.Tools;
using System.Xml.Serialization;

namespace Assets.Scripts
{
    public class CreateXml : MonoBehaviour
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Unity Messages
        //    void Awake()
        //    {
        //
        //    }
        //    void OnEnable()
        //    {
        //
        //    }
        //
        void Start()
        {

        }
        //    
        //    void Update() 
        //    {
        //    
        //    }
        //
        //    void OnDisable()
        //    {
        //
        //    }
        //
        //    void OnDestroy()
        //    {
        //
        //    }

        #endregion

        #region Private Methods
        [ContextMenu("TestWrite")]
        private void TestWrite()
        {
            string tempPath = System.IO.Path.Combine(Application.dataPath, "Demo1/Books.xml");

            if (!File.Exists(tempPath))
            {
                File.Create(tempPath);
            }
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "Books", null);
                xmlDoc.AppendChild(root);
                XmlNode xmlElement = xmlDoc.CreateNode(XmlNodeType.Element, "book", null);
                XmlAttribute xmlAttribute = xmlDoc.CreateAttribute("id");
                xmlAttribute.InnerText = "1001";
                xmlElement.Attributes.Append(xmlAttribute);
                XmlNode xmlItemAge = xmlDoc.CreateNode(XmlNodeType.Element, "name", null);
                xmlItemAge.InnerText = "c#开发详解";
                XmlNode xmlItemAuthor = xmlDoc.CreateNode(XmlNodeType.Element, "author", null);
                xmlItemAuthor.InnerText = "不清楚";
                XmlNode xmlItemPrice = xmlDoc.CreateNode(XmlNodeType.Element, "price", null);
                xmlItemPrice.InnerText = "120";

                root.AppendChild(xmlElement);
                xmlElement.AppendChild(xmlItemAge);
                xmlElement.AppendChild(xmlItemAuthor);
                xmlElement.AppendChild(xmlItemPrice);

                XmlDeclaration declaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                xmlDoc.InsertBefore(declaration, xmlDoc.DocumentElement);
                xmlDoc.Save(tempPath);
            }
            catch (Exception ex)
            {
                Debuger.Log(ex.Message);
            }
        }

        [ContextMenu("TestRead")]
        private void TestRead()
        {
            try
            {
                Profile.StartProfile("Read File");

                XmlDocument xmlDoc = new XmlDocument();
                string tempPath = System.IO.Path.Combine(Application.dataPath, "Demo1/Books.xml");
                xmlDoc.Load(tempPath);
                Profile.EndProfile("Read File");

                XmlNode root = xmlDoc.DocumentElement;
                Debuger.Log(root.Name);

                /*
                XmlNode tempRoot = xmlDoc.SelectSingleNode("Books");
                Debuger.Log(tempRoot.Name);
                */
                Profile.StartProfile("Read Node");
                foreach (XmlNode xmlNode in root.ChildNodes)
                {
                    foreach (XmlNode xmlElement in xmlNode.ChildNodes)
                    {
                        string tempText = xmlElement.InnerText;
                        Debuger.Log(tempText);
                    }
                }
                Profile.EndProfile("Read Node");
                Profile.PrintResults();
            }
            catch (Exception ex)
            {
                Debuger.Log(ex.Message);
            }
        }

        [ContextMenu("TestReadToT")]
        private void TestReadToT()
        {
            string tempPath = System.IO.Path.Combine(Application.dataPath, "Demo1/Books.xml");
            Books tempBooks = LoadXml<Books>(tempPath);
            foreach(Book tempBook in tempBooks.books)
            {
                Debug.Log(tempBook.id + ", " + tempBook.name + ", " + tempBook.author + ", " + tempBook.price);
            }
        }

        /// <summary>
        /// 用于解析xml的方法
        /// </typeparam>
        /// <param name="path">xml文件的路径</param>
        /// <param name="ms">用于接受xml文件解析的结果</param>
        public T LoadXml<T>(string path) where T : class
        {
            try
            {
                //通过流根据路径去读取文件
                using (TextReader reader = new StreamReader(path))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    var item = (T)serializer.Deserialize(reader);
                    return item;
                }
            }
            catch (Exception ex)
            {
                //用于捕捉异常避免解析过程中出现错误导致程序死掉
                //将错误打印出来
                Debug.LogError(ex.Message);
                return null;
            }
        }
        #endregion

        #region Protected & Public Methods

        #endregion
    }
}