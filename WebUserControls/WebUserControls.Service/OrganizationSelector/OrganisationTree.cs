using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WebUserControls.Infrastructure.Configuration;
using WebUserControls.Service.BasicService;
using SqlServerDataAdapter;

namespace WebUserControls.Service.OrganizationSelector
{
    public class OrganisationTree
    {
        private static readonly string _connStr = ConnectionStringFactory.NXJCConnectionString;
        private static readonly ISqlServerDataFactory _dataFactory = new SqlServerDataFactory(_connStr);
        private static readonly BasicDataHelper _dataHelper = new BasicDataHelper(_connStr);

        public static DataTable GetOrganisationTree(List<string> myOrganizationsId, string myType, List<string> myOrganizationTypeItems, int myLeveDepth, bool myEnabled)
        {

            List<string> m_Organizations = _dataHelper.GetOrganisationLevelCodeById(myOrganizationsId);
            string m_Enabled = myEnabled == true ? "1" : "0";
            string m_Sql = @"Select 
                    A.OrganizationID as OrganizationId, 
                    A.Name as Name,
                    A.LevelCode as LevelCode, 
                    A.Type as OrganizationType  
                    from system_Organization A 
					where A.Enabled = {1} 
                    and  (len(A.LevelCode) < {3} or (len(A.LevelCode) = {3} {2} {4}))
                    and {0}";
            string m_SqlConditionTemp = @" (A.LevelCode like '{0}%' 
                                       or CHARINDEX(A.LevelCode, '{0}') > 0) ";
            string m_SqlType = "";                      //是否指定类型
            string m_SqlCondition = "";                 //数据数据授权
            string m_SqlTypeItemsCondition = "";
            if (m_Organizations != null)                //数据授权约束
            {
                for (int i = 0; i < m_Organizations.Count; i++)
                {
                    if (i == 0)
                    {
                        m_SqlCondition = string.Format(m_SqlConditionTemp, m_Organizations[i]);
                    }
                    else
                    {
                        m_SqlCondition = m_SqlCondition + string.Format("or " + m_SqlConditionTemp, m_Organizations[i]);
                    }
                }
            }
            if (myOrganizationTypeItems != null)                    //设置产线类型
            {
                string m_ConditionTemp = " and A.Type in ({0})";
                for (int i = 0; i < myOrganizationTypeItems.Count; i++)
                {
                    if (i == 0)
                    {
                        m_SqlTypeItemsCondition = m_SqlTypeItemsCondition + "'" + myOrganizationTypeItems[i] + "'";
                    }
                    else
                    {
                        m_SqlTypeItemsCondition = m_SqlTypeItemsCondition + ",'" + myOrganizationTypeItems[i] + "'";
                    }
                }
                if (m_SqlTypeItemsCondition != "")
                {
                    m_SqlTypeItemsCondition = string.Format(m_ConditionTemp, m_SqlTypeItemsCondition);
                }
            }
            if (myType != "")
            {
                m_SqlType = string.Format("and A.Type = '{0}'", myType);
            }

            if (m_SqlCondition != "")
            {
                m_Sql = string.Format(m_Sql, "(" + m_SqlCondition + ")", m_Enabled, m_SqlType, myLeveDepth, m_SqlTypeItemsCondition);
            }
            else
            {
                m_Sql = string.Format(m_Sql, "A.OrganizationID <> A.OrganizationID", m_Enabled, m_SqlType, myLeveDepth, m_SqlTypeItemsCondition);
            }

            try
            {
                DataTable m_Result = _dataFactory.Query(m_Sql);
                return m_Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static DataTable GetProductionLineType(List<string> myOrganizationTypeItmes)
        {
            string m_OrganizationTypeItems = "";
            if (myOrganizationTypeItmes != null)
            {
                for (int i = 0; i < myOrganizationTypeItmes.Count; i++)
                {
                    if (i == 0)
                    {
                        m_OrganizationTypeItems = "'" + myOrganizationTypeItmes[i] + "'";
                    }
                    else
                    {
                        m_OrganizationTypeItems = m_OrganizationTypeItems + ",'" + myOrganizationTypeItmes[i] + "'";
                    }
                }
            }
            string m_Sql = @"Select 
                    distinct A.Type as ProductionLineId, 
                    A.Type as ProductionLineText 
                    from system_Organization A 
					where A.Type is not null 
					and A.Type <> '' 
                    and A.Enabled = 1 
                    {0}
                    order by A.Type";
            string m_OrgnizationTypeCondition = "";
            if (m_OrganizationTypeItems != "")
            {
                m_OrgnizationTypeCondition = string.Format(" and A.Type in ({0}) ", m_OrganizationTypeItems);
            }
            try
            {
                m_Sql = string.Format(m_Sql, m_OrgnizationTypeCondition);
                DataTable m_Result = _dataFactory.Query(m_Sql);
                return m_Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<string> GetOrganisationLevelCodeById(List<string> myOrganisationIdList)
        {
            return _dataHelper.GetOrganisationLevelCodeById(myOrganisationIdList);
        }
    }
}
