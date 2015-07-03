$(document).ready(function () {
    //var m_Parmaters = { "FunctionName": "GetFileList", "FileGroup": "", "FileClassify": "" };
    //$.ajax({
    //    type: "POST",
    //    url: "test.aspx",
    //    data: m_Parmaters,
    //    //contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: function (msg) {
    //        alert("dfadsfadf");
    //        //var m_MsgData = jQuery.parseJSON(msg.d);
    //        //if (myLoadType == 'first') {
    //        //    InitializeFileListGrid("FilesList", m_MsgData);
    //        //}
    //        //else if (myLoadType == 'last') {
    //        //    $('#grid_FilesList').datagrid('loadData', m_MsgData);
    //        //}
    //    },
    //    error: function (XMLHttpRequest, textStatus, errorThrown) {
    //        var aa = XMLHttpRequest;
    //        var bb = textStatus;
    //        var cc = errorThrown;
    //        $.messager.alert('错误', '数据载入失败！');
    //    }
    //});

});
function DownFileFun(myFileName, myFilePath) {
    /*
    var m_Parmaters = { "FunctionName": "DownloadFile", "FileName": myFileName, "FilePath": myFilePath };
    $.ajax({
        type: "POST",
        url: "test.aspx",
        data: m_Parmaters,
        //contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
        }
    });*/
    var m_FunctionName = "DownloadFile";

    var form = $('<form id="ExportFile" name="ExportFile"></form>');   //定义一个form表单
    //var form = $('#formMain');
    //form.attr('style', 'display:none');   //在form表单中添加查询参数
    //form.attr('enctype', 'multipart/form-data');
    form.attr('target', '_self');
    form.attr('method', 'post');
    form.attr('action', "");

    var input_Method = $('<input></input>');
    input_Method.attr('type', 'hidden');
    input_Method.attr('name', 'FunctionName');
    input_Method.attr('value', m_FunctionName);
    var input_Data1 = $('<input></input>');
    input_Data1.attr('type', 'hidden');
    input_Data1.attr('name', 'FileName');
    input_Data1.attr('value', myFileName);
    var input_Data2 = $('<input></input>');
    input_Data2.attr('type', 'hidden');
    input_Data2.attr('name', 'FilePath');
    input_Data2.attr('value', myFilePath);

    form.append(input_Method);   //将查询参数控件提交到表单上
    form.append(input_Data1);   //将查询参数控件提交到表单上
    form.append(input_Data2);   //将查询参数控件提交到表单上
    $('body').append(form);  //将表单放置在web中 

    form.submit();
    //释放生成的资源
    //form.remove();
}
