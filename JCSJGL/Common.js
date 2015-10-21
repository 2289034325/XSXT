///<reference path="jquery-2.1.3.js">

//判断浏览器是PC还是移动设备
function IsPC()
{
    var userAgentInfo = navigator.userAgent;
    var Agents = ["Android", "iPhone",
                "SymbianOS", "Windows Phone",
                "iPad", "iPod"];
    var flag = true;
    for (var v = 0; v < Agents.length; v++)
    {
        if (userAgentInfo.indexOf(Agents[v]) > 0)
        {
            flag = false;
            break;
        }
    }
    return flag;
}

//编辑对话框
function ShowEditDialog(dlgid,flg)
{
    if (flg)
    {
        $("#" + dlgid + " .btnAdd").css("display", "");
        $("#" + dlgid + " .btnEdit").css("display", "none");
    }
    else
    {
        $("#" + dlgid + " .btnAdd").css("display", "none");
        $("#" + dlgid + " .btnEdit").css("display", "");
    }

    $(".div_sch_mobile").css("display", "none");
    $(".div_edit_mobile").css("display", "none");
    $("#" + dlgid).css("display", "");
}

function CloseEditDialog(dlgid)
{
    if (IsPC())
    {
        $("#" + dlgid).dialog("close");
    }
    else
    {
        $("#" + dlgid).css("display", "none");
    }
}