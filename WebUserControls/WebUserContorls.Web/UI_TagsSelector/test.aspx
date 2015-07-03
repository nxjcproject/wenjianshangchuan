<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WebUserContorls.Web.UI_TagsSelector.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="/lib/ealib/themes/gray/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/lib/ealib/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="/lib/extlib/themes/syExtIcon.css" />
    <link rel="stylesheet" type="text/css" href="/lib/extlib/themes/syExtCss.css" />

    <script type="text/javascript" src="/lib/ealib/jquery.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="/lib/ealib/jquery.easyui.min.js" charset="utf-8"></script>
<%--    <script type="text/javascript" charset="utf-8" src="/js/common/ajaxfileupload.js"> </script>--%>

    <script type="text/javascript" src="/lib/ealib/easyui-lang-zh_CN.js" charset="utf-8"></script>

    <script type="text/javascript" src="js/page/test.js" charset="utf-8"></script>
</head>
<body>
    <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save',plain:false" onclick="return DownFileFun('aaa','bbb');">上传文件</a>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
