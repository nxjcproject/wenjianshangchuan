using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUserContorls.Web.UI_TagsSelector
{
    public partial class FileUploadTest : WebStyleBaseForEnergy.webStyleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.InitComponts();           //调用时必须的初始化
            ////////////////////调试用,自定义的数据授权////////////////////////
            List<string> m_DataValidIdItems = new List<string>() { "zc_nxjc_qtx" };
            AddDataValidIdGroup("ProductionOrganization", m_DataValidIdItems);
            HiddenField_UserId.Value = mUserId;
            HiddenField_FolderPath.Value = mFileRootPath + "UploadFile\\EnergyProcessRecord";
            //this.FileUploader.UserId = "admin";
            //this.FileUploader.FolderPath = mFileRootPath + "\\UploadFile\\EnergyProcessRecord";
            //this.FileUploader.FileGroup = "EnergyProcessRecord"; 

        }
    }
}