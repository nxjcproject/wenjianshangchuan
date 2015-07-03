$(document).ready(function () {

});
function ReadyData() {
    if (typeof (SubScriptLoad) == "function") {
        var m_UserId = $('#HiddenField_UserId').val();
        var m_FolderPath = $('#HiddenField_FolderPath').val();
        var m_FileClassify = "EnergyProcessRecord";
        var m_FileGroup = "EnergyProcessRecord123456";
        //SubScriptLoad(m_FileGroup, m_FileClassify, m_UserId, m_FolderPath, "FileUploadTest.aspx");
        SubViewScriptLoad(m_FileGroup, m_FileClassify, "FileUploadTest.aspx");
    }
}