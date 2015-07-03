﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SqlServerDataAdapter;

namespace WebUserControls.Service.BasicService
{
    public class BasicDataHelper
    {
        private ISqlServerDataFactory _dataFactory;

        public BasicDataHelper(string connString)
        {
            _dataFactory = new SqlServerDataFactory(connString);
        }
        /// <summary>
        /// Clone表结构
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable CreateTableStructure(string tableName)
        {
            string queryString = @"SELECT TOP 1 * FROM " + tableName;
            DataTable sourceTable = _dataFactory.Query(queryString);
            DataTable result = sourceTable.Clone();

            return result;
        }
        /// <summary>
        /// 根据OrganizationId获得LevelCode
        /// </summary>
        /// <param name="myOrganisationIdList">OrganizationId列表</param>
        /// <returns>LevelCode列表</returns>
        public List<string> GetOrganisationLevelCodeById(List<string> myOrganisationIdList)
        {
            string m_Sql = @"Select 
                    A.LevelCode as LevelCode 
                    from system_Organization A 
					where A.OrganizationID in ({0})
                    and A.Enabled = 1 
                    order by A.LevelCode";
            try
            {
                if (myOrganisationIdList != null)
                {
                    string m_Conditions = "";
                    for (int i = 0; i < myOrganisationIdList.Count; i++)
                    {
                        if (i == 0)
                        {
                            m_Conditions = string.Format("'{0}'", myOrganisationIdList[i]);
                        }
                        else
                        {
                            m_Conditions = m_Conditions + string.Format(",'{0}'", myOrganisationIdList[i]);
                        }
                    }
                    if (m_Conditions != "")
                    {
                        m_Sql = string.Format(m_Sql, m_Conditions);
                    }
                    else
                    {
                        m_Sql = string.Format(m_Sql, "''");
                    }
                    DataTable m_Result = _dataFactory.Query(m_Sql);             //根据组织机构ID查找层次码
                    if (m_Result != null)
                    {
                        List<string> m_LevelCodeList = new List<string>();
                        for (int i = 0; i < m_Result.Rows.Count; i++)
                        {
                            m_LevelCodeList.Add(m_Result.Rows[i]["LevelCode"].ToString());    //将层次码转化为List
                        }
                        return m_LevelCodeList;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
