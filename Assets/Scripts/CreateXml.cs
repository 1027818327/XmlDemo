
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
            if (!File.Exists("E:\\Books.xml"))
            {
                File.Create("E:\\Books.xml");
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
                xmlDoc.Save("E:\\Books.xml");
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
                xmlDoc.Load("E:\\Books.xml");
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
        #endregion

        #region Protected & Public Methods

        #endregion
    }
}