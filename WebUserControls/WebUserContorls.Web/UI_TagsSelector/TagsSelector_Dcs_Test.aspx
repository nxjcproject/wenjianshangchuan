<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TagsSelector_Dcs_Test.aspx.cs" Inherits="WebUserContorls.Web.UI_TagsSelector.TagsSelector_Dcs_Test" %>

<%@ Register Src="../UI_WebUserControls/TagsSelector/TagsSelector_Dcs.ascx" TagName="TagsSelector_Dcs" TagPrefix="uc1" %>

<%@ Register src="../UI_WebUserControls/OrganizationSelector/OrganisationTree.ascx" tagname="OrganisationTree" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Dcs标签选择器</title>
    <link rel="stylesheet" type="text/css" href="/lib/ealib/themes/gray/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/lib/ealib/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="/lib/extlib/themes/syExtIcon.css" />
    <link rel="stylesheet" type="text/css" href="/lib/extlib/themes/syExtCss.css" />

    <script type="text/javascript" src="/lib/ealib/jquery.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="/lib/ealib/jquery.easyui.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="/lib/ealib/easyui-lang-zh_CN.js" charset="utf-8"></script>


    <script type="text/javascript" src="js/page/TagsSelector_Dcs_Test.js" charset="utf-8"></script>

</head>
<body style="width: 100%; height: 100%;">

    <div class="easyui-layout" data-options="fit:true,border:false">

        <div data-options="region:'west',border:false,collapsible:false" style="width: 350px;">
            <uc1:TagsSelector_Dcs ID="TagsSelector_DcsTags" runat="server" />
        </div>
        <div data-options="region:'center',border:false,collapsible:false" style="padding-left: 10px;">
            <uc2:OrganisationTree ID="OrganisationTree1" runat="server" />
        </div>

    </div>
    <form id="form1" runat="server">
    </form>
</body>
</html>
