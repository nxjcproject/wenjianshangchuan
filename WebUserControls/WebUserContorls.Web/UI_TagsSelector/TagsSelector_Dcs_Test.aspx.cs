using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

namespace WebUserContorls.Web.UI_TagsSelector
{
    public partial class TagsSelector_Dcs_Test : WebStyleBaseForEnergy.webStyleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.InitComponts();           //调用时必须的初始化
            ////////////////////调试用,自定义的数据授权////////////////////////
            List<string> m_DataValidIdItems = new List<string>() { "zc_nxjc_byc"};
            AddDataValidIdGroup("ProductionOrganization", m_DataValidIdItems);
            ///////////////////////////////////////////////////////////////////
            this.OrganisationTree1.Organizations = GetDataValidIdGroup("ProductionOrganization");                 //向web用户控件传递数据授权参数
            this.OrganisationTree1.PageName = "TagsSelector_Dcs_Test.aspx";                                     //向web用户控件传递当前调用的页面名称

            this.OrganisationTree1.Organizations = GetDataValidIdGroup("ProductionOrganization");                 //向web用户控件传递数据授权参数
            this.OrganisationTree1.PageName = "TagsSelector_Dcs_Test.aspx";                                     //向web用户控件传递当前调用的页面名称
            
            //this.OrganisationTree1.OrganizationTypeItems.Add("水泥磨");               //设定排除的产线类型
            //this.OrganisationTree1.OrganizationTypeItems.Add("熟料");   
            //this.OrganisationTree1.LeveDepth = 5;                                         //设定levelcode层次深度（层次码的位数）
        }

    }
}