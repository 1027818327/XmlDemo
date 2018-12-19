
#region 版权信息
/*
 * -----------------------------------------------------------
 *  Copyright (c) KeJun All rights reserved.
 * -----------------------------------------------------------
 *		描述: 
 *      创建者：DESKTOP-1050N1H\luoyikun
 *      创建时间: 2018/12/19 10:00:32
 *  
 */
#endregion


using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Scripts
{
    public class Book
    {
        #region Fields
        public string name;
        public string author;
        public string price;

        #endregion

        #region Properties
        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }
        #endregion

        #region Private Methods

        #endregion

        #region Protected & Public Methods

        #endregion
    }

    [XmlRoot("Books")]
    public class Books
    {
        [XmlElement("book")]
        public Book[] books;
    }
}