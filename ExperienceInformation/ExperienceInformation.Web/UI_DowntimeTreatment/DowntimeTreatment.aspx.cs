using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using WebStyleBaseForEnergy;
using EasyUIJsonParser;

namespace ExperienceInformation.Web.UI_DowntimeTreatment
{
    public partial class DowntimeTreatment : WebStyleBaseForEnergy.webStyleBase
    {
        private const string RecordTypeGroup = "DowntimeTreatment";
        protected void Page_Load(object sender, EventArgs e)
        {

            base.InitComponts();
            if (!IsPostBack)
            {
#if DEBUG
                List<string> m_DataValidIdItems = new List<string>() { "zc_nxjc_qtx_efc", "zc_nxjc_byc_byf" };
                AddDataValidIdGroup("ProductionOrganization", m_DataValidIdItems);
                mPageOpPermission = "0000";
#endif
            }
        }
        /// <summary>
        /// 增删改查权限控制
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static char[] AuthorityControl()
        {
            return mPageOpPermission.ToArray();
        }
        [WebMethod]
        public static string GetDowntimeReasonInfo()
        {
            DataTable m_DowntimeTreatmentInfo = ExperienceInformation.Service.DowntimeTreatment.DowntimeTreatment.GetDowntimeReasonInfo();
            string m_DowntimeTreatmentJson = EasyUIJsonParser.TreeJsonParser.DataTableToJsonByLevelCodeWithIdColumn(m_DowntimeTreatmentInfo, "MachineHaltReasonId", "ReasonItemId", "ReasonText");
            return m_DowntimeTreatmentJson;
        }
        [WebMethod]
        public static string GetDowntimeTreatmentInfo(string myReasonItemId)
        {
            DataTable m_DowntimeTreatmentInfo = ExperienceInformation.Service.DowntimeTreatment.DowntimeTreatment.GetDowntimeTreatmentInfo(myReasonItemId);
            string m_DowntimeTreatmentJson = EasyUIJsonParser.DataGridJsonParser.DataTableToJson(m_DowntimeTreatmentInfo);
            return m_DowntimeTreatmentJson;
        }
        [WebMethod]
        public static string GetDowntimeTreatmentInfoById(string myDowntimeTreatmentItemId)
        {
            DataTable m_DowntimeTreatmentInfo = ExperienceInformation.Service.DowntimeTreatment.DowntimeTreatment.GetDowntimeTreatmentInfoById(myDowntimeTreatmentItemId);
            string m_DowntimeTreatmentJson = EasyUIJsonParser.DataGridJsonParser.DataTableToJson(m_DowntimeTreatmentInfo);
            return m_DowntimeTreatmentJson;
        }
        [WebMethod]
        public static string GetDowntimeTreatmentTextById(string myDowntimeTreatmentItemId)
        {
            string m_DowntimeTreatmentText = ExperienceInformation.Service.DowntimeTreatment.DowntimeTreatment.GetDowntimeTreatmentTextById(myDowntimeTreatmentItemId);
            return m_DowntimeTreatmentText;
        }
        [WebMethod]
        public static string GetDowntimePhenomenonTextById(string myDowntimeTreatmentItemId)
        {
            string m_DowntimeTreatmentText = ExperienceInformation.Service.DowntimeTreatment.DowntimeTreatment.GetDowntimePhenomenonTextById(myDowntimeTreatmentItemId);
            return m_DowntimeTreatmentText;
        }
        [WebMethod]
        public static string GetDowntimePhenomenonTreatmentTextById(string myDowntimeTreatmentItemId)
        {
            string m_DowntimeTreatmentText = ExperienceInformation.Service.DowntimeTreatment.DowntimeTreatment.GetDowntimePhenomenonTreatmentTextById(myDowntimeTreatmentItemId);
            return m_DowntimeTreatmentText;
        }
        [WebMethod]

        public static string AddDowntimeTreatment(string myDowntimeTreatmentName, string myReasonItemId, string myPhenomenon, string myTreatment, string myRemarks)
        {
            if (mPageOpPermission.ToArray()[1] == '1')
            {
                if (mUserId != "")
                {
                    int m_DowntimeTreatmentText = ExperienceInformation.Service.DowntimeTreatment.DowntimeTreatment.AddDowntimeTreatment(myDowntimeTreatmentName, myReasonItemId, myPhenomenon, myTreatment, mUserId, myRemarks);
                    int m_Result = m_DowntimeTreatmentText > 0 ? 1 : m_DowntimeTreatmentText;
                    return m_Result.ToString();
                }
                else
                {
                    return "非法的用户操作!";
                }
            }
            else
            {
                return "该用户没有添加权限！";
            }
        }
        [WebMethod]
        public static string ModifyDowntimeTreatment(string myDowntimeTreatmentItemId, string myDowntimeTreatmentName, string myReasonItemId, string myPhenomenon, string myTreatment, string myRemarks)
        {
            if (mPageOpPermission.ToArray()[2] == '1')
            {
                if (mUserId != "")
                {
                    int m_DowntimeTreatmentText = ExperienceInformation.Service.DowntimeTreatment.DowntimeTreatment.ModifyDowntimeTreatmentById(myDowntimeTreatmentItemId, myDowntimeTreatmentName, myReasonItemId, myPhenomenon, myTreatment, mUserId, myRemarks);
                    int m_Result = m_DowntimeTreatmentText > 0 ? 1 : m_DowntimeTreatmentText;
                    return m_Result.ToString();
                }
                else
                {
                    return "非法的用户操作!";
                }
            }
            else
            {
                return "该用户没有修改权限！";
            }
        }
        [WebMethod]
        public static string DeleteDowntimeTreatmentById(string myDowntimeTreatmentItemId)
        {
            if (mPageOpPermission.ToArray()[3] == '1')
            {
                if (mUserId != "")
                {
                    int m_DowntimeTreatmentText = ExperienceInformation.Service.DowntimeTreatment.DowntimeTreatment.DeleteDowntimeTreatmentById(myDowntimeTreatmentItemId);
                    int m_Result = m_DowntimeTreatmentText > 0 ? 1 : m_DowntimeTreatmentText;
                    return m_Result.ToString();
                }
                else
                {
                    return "非法的用户操作!";
                }
            }
            else
            {
                return "该用户没有删除权限！";
            }
        }
    }
}