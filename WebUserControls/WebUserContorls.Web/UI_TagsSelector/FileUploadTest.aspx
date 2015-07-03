<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUploadTest.aspx.cs" Inherits="WebUserContorls.Web.UI_TagsSelector.FileUploadTest" %>

<%@ Register Src="../UI_WebUserControls/FileUpload/FileUploader.ascx" TagName="FileUploader" TagPrefix="uc1" %>

<%@ Register Src="../UI_WebUserControls/FileUpload/FileViewList.ascx" TagName="FileViewList" TagPrefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="MainHead" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>测试上传文件</title>
    <link rel="stylesheet" type="text/css" href="/lib/ealib/themes/gray/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/lib/ealib/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="/lib/extlib/themes/syExtIcon.css" />
    <link rel="stylesheet" type="text/css" href="/lib/extlib/themes/syExtCss.css" />

    <script type="text/javascript" src="/lib/ealib/jquery.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="/lib/ealib/jquery.easyui.min.js" charset="utf-8"></script>

    <script type="text/javascript" src="/lib/ealib/easyui-lang-zh_CN.js" charset="utf-8"></script>

    <script type="text/javascript" src="js/page/FileUploadTest.js" charset="utf-8"></script>
</head>
<body style="width: 100%; height: 100%;">


    <div class="easyui-layout" data-options="fit:true,border:false">

        <div data-options="region:'north',border:false,collapsible:false" style="height: 360px; padding: 10px; background-color: red;">
            <table style="background-color: yellow;">
                <tr>
                    <td>
                        <uc1:FileUploader ID="FileUploader" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div data-options="region:'center',border:false,collapsible:false" style="padding: 10px; background-color: blue;">
            <div data-options="region:'north',border:false,collapsible:false" style="height: 360px; padding: 10px; background-color: red;">
                <table style="background-color: yellow;">
                    <tr>
                        <td>
                            <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save',plain:false" onclick="ReadyData();">准备数据</a>
                            <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save',plain:false" onclick="ajaxFileUpload();">确认提交</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <uc2:FileViewList ID="FileViewList" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>

    </div>
    <form id="form1" runat="server">
        <asp:HiddenField ID="HiddenField_UserId" runat="server" />
        <asp:HiddenField ID="HiddenField_FolderPath" runat="server" />
    </form>
</body>
</html>
