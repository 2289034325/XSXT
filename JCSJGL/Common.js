///<reference path="jquery-2.1.3.js">

//编辑对话框
function ShowEditDialog(flg)
{
    if (flg)
    {
        $("#div_edit").css("display", "");
    }
    else
    {
        $("#div_edit").css("display", "none");
    }
}