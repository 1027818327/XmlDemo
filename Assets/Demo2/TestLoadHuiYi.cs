
#region 版权信息
/*
 * -----------------------------------------------------------
 *  Copyright (c) KeJun All rights reserved.
 * -----------------------------------------------------------
 *		描述: 
 *      创建者：DESKTOP-1050N1H\luoyikun
 *      创建时间: 2018/12/19 10:49:19
 *  
 */
#endregion


using System.IO;
using UnityEngine;
using Framework.Xml;

namespace Assets.Demo2
{
    public class TestLoadHuiYi : MonoBehaviour
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
            string tempXml = File.ReadAllText(Path.Combine(Application.dataPath, "Demo2/huiyi.xml"));
            var tempObj = XmlUtil.Deserialize(typeof(HuiYiList), tempXml) as HuiYiList;
            foreach (HuiYiXml tempHyx in tempObj.Ins)
            {
                Debuger.Log(tempHyx.m_Name + ", " + tempHyx.m_Times + ", " + tempHyx.m_Address
                     + ", " + tempHyx.m_Player + ", " + tempHyx.m_Event + ", " + tempHyx.m_Meaning
                      + ", " + tempHyx.m_Info);
            }
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

        #endregion

        #region Protected & Public Methods

        #endregion
    }
}