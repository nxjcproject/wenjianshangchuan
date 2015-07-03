//当web用户控件的DataGrid双击时调用的方法，调用的页面可以获得数据
function GetTagInfo(myRowData, DcsDataBaseNameQuery, DcsOrganizationIdQuery) {
    alert(myRowData.VariableName + "," + myRowData.VariableDescription + "," + myRowData.TableName + "," + myRowData.FieldName + "," + DcsOrganizationIdQuery);
}
function onOrganisationTreeClick(node) {
    alert(node.id);
}