using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WebUserControls.Infrastructure.Configuration;
using WebUserControls.Service.BasicService;
using SqlServerDataAdapter;

namespace WebUserControls.Service.TagsSelector
{
    public class TagsSelector_Dcs
    {
        private static readonly string _connStr = ConnectionStringFactory.NXJCConnectionString;
        private static readonly ISqlServerDataFactory _dataFactory = new SqlServerDataFactory(_connStr);
        private static readonly BasicDataHelper _dataHelper = new BasicDataHelper(_connStr);

        public static DataTable GetDCSTagsDataBase(List<string> myOrganizationsId, bool myEnabled)
        {
            List<string> m_Organizations = _dataHelper.GetOrganisationLevelCodeById(myOrganizationsId);
            string m_Enabled = myEnabled == true ? "1" : "0";
            string m_Sql = @"Select 
                    A.OrganizationID as OrganizationId, 
                    A.Name as Name,
                    A.LevelCode as LevelCode,
					B.DCSProcessDatabase as DcsProcessDatabase  
                    from system_Organization A 
					left join system_Database B on A.DatabaseID = B.DatabaseID 
					where A.Enabled = {1} 
                    and len(A.LevelCode) <= 7 
                    and {0} ";
            string m_SqlConditionTemp = @" (A.LevelCode like '{0}%' 
                                       or CHARINDEX(A.LevelCode, '{0}') > 0) ";
            string m_SqlCondition = "";
            if (m_Organizations != null)           //是否有数据授权
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
            if (m_SqlCondition != "")
            {
                m_Sql = string.Format(m_Sql, "(" + m_SqlCondition + ")", m_Enabled);
            }
            else
            {
                m_Sql = string.Format(m_Sql, "A.OrganizationID <> A.OrganizationID", m_Enabled);
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

        public static DataTable GetDCSTagsByDataBase(int myBatchNumber, int myBatchSize, string myDataBaseName, string myDcsTagsName, string myDcsTagsType, bool myIsCumulant)
        {
            string m_IsCumulant = myIsCumulant == true ? "1" : "0";
            string m_Sql = @"Select 
                    Z.VariableName as VariableName, 
                    Z.VariableDescription as VariableDescription, 
                    Z.TableName as TableName, 
                    Z.FieldName as FieldName
                    from 
                    (Select 
                    top ({0} * {1}) row_number() over(order by A.VariableName desc) as ROW_INDEX, 
                    A.VariableName as VariableName, 
                    A.VariableDescription as VariableDescription,
                    A.TableName as TableName,
					A.FieldName as FieldName 
                    from {2}.dbo.DCSContrast A 
					where A.IsCumulant = {3} 
                    and A.DataTypeStandard = '{4}' 
                    {5}) Z 
                    where Z.ROW_INDEX > ({0}-1) * {1} and Z.ROW_INDEX <= {0} * {1} 
                    order by Z.VariableDescription";
            string m_SqlCondition = "";
            if (myDcsTagsName != "")
            {
                m_SqlCondition = string.Format(" and A.VariableDescription like '%{0}%'", myDcsTagsName);
            }

            m_Sql = string.Format(m_Sql, myBatchNumber, myBatchSize, myDataBaseName, m_IsCumulant, myDcsTagsType, m_SqlCondition);                 //"{\"rows\":[{\"ColumnName\":\"WarmingTime\", \"Value\":\"\"}]}"
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
        public static int GetDCSTagsCountByDataBase(string myDataBaseName, string myDcsTagsName, string myDcsTagsType, bool myIsCumulant)
        {
            string m_IsCumulant = myIsCumulant == true ? "1" : "0";
            string m_Sql = @"Select 
                    count(A.VariableName) as DcsTagsCount 
                    from {0}.dbo.DCSContrast A 
					where A.IsCumulant = {1} 
                    and A.DataTypeStandard = '{2}' 
                    {3}";
            string m_SqlCondition = "";
            if (myDcsTagsName != "")
            {
                m_SqlCondition = string.Format(" and A.VariableDescription like '%{0}%'", myDcsTagsName);
            }

            m_Sql = string.Format(m_Sql, myDataBaseName, m_IsCumulant, myDcsTagsType, m_SqlCondition);                 //"{\"rows\":[{\"ColumnName\":\"WarmingTime\", \"Value\":\"\"}]}"
            try
            {
                DataTable m_Result = _dataFactory.Query(m_Sql);
                if (m_Result != null)
                {
                    return (int)m_Result.Rows[0]["DcsTagsCount"];
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
