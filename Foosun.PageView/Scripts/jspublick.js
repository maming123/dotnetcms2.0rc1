function pubajax(url, actionstr, divID) {
    jQuery.get(url + '?no-cache=' + Math.random() + '&' + actionstr, function(returnvalue){
        if (returnvalue.indexOf("??") > -1)
            document.getElementById(divID).innerHTML = '';
        else
            document.getElementById(divID).innerHTML = returnvalue;
    });
}

function getTopNum(url, newsid, num, divID) {
    var Action = 'newsid=' + newsid + '&getNum=' + num + ''; 
    jQuery.get(url + '?no-cache=' + Math.random() + '&' + Action, function(returnvalue){
        if (returnvalue.indexOf("??") > -1)
            document.getElementById(divID).innerHTML = '';
        else
            document.getElementById(divID).innerHTML = returnvalue;
    });
}

function getPageInfoURLFileName(type) {
    if (type == "0") {
        var v1 = document.location.pathname;
        var temp_f = v1.lastIndexOf("/");
        var fien = v1.substring(temp_f + 1, v1.length)
        if (fien.indexOf("_") > -1) {
            for (var i = 0; i < document.getElementById('PageSelectOption').length; i++) {
                if (fien == document.getElementById('PageSelectOption').options[i].value) {
                    document.getElementById('PageSelectOption').options[i].selected = true;
                }
            }
        }
    }
    else {
        var v1 = document.location.href;
        var temp_f = v1.lastIndexOf("=");
        var fien = v1.substring(temp_f + 1, v1.length)
        if (v1.lastIndexOf("=") > -1) {
            for (var i = 0; i < document.getElementById('PageSelectOption').length; i++) {
                document.getElementById('PageSelectOption').options[fien - 1].selected = true;
            }
        }
        else {
            document.getElementById('PageSelectOption').options[0].selected = true;
        }
    }

}


function GetCommentListContent(urlsitedomain, newsid, page) {
    jQuery.get('' + urlsitedomain + '/comment.aspx?no-cache=' + Math.random() + '&NewsID=' + newsid + '&CommentType=getlist&showdiv=0&page=' + page,function(returnvalue){
        if (returnvalue.indexOf("??") > -1)
                document.getElementById("CommentlistPage").innerHTML = '加载评论列表失败';
            else
                document.getElementById("CommentlistPage").innerHTML = returnvalue;
    });
}


function CommandSubmitContent(obj, url, newsid) {
    if (obj.UserNum.value == "") {
        alert('帐号不能为空');
        return false;
    }
    if (obj.Content.value == "") {
        alert('评论内容不能为空');
        return false;
    }
    var r = obj.commtype;
    var commtypevalue = '2';
    for (var i = 0; i < r.length; i++) {
        if (r[i].checked)
            commtypevalue = r[i].value;
    }
    jQuery.get('' + url + '/comment.aspx?no-cache=' + Math.random() + '&CommentType=AddComment&showdiv=1&UserNum=' + escape(obj.UserNum.value) + '&UserPwd=' + escape(obj.UserPwd.value) + '&commtype=' + escape(commtypevalue) + '&Content=' + escape(obj.Content.value) + '&IsQID=' + escape(obj.IsQID.value) + '&NewsID=437727796213', function(returnvalue){
        var arrreturnvalue = returnvalue.split('$$$');
            if (arrreturnvalue[0] == "ERR") {
                alert(arrreturnvalue[1]);
                obj.Content.value = '';
            }
            else {
                alert('发表评论成功!');
                GetCommentListContent('' + url + '', '' + newsid + '', '1');
                obj.Content.value = '';
            }
    })
}
function CommentLoginOut(obj, url) {
    jQuery.get('' + url + '/comment.aspx?no-cache=' + Math.random() + '&CommentType=LoginOut',function(returnvalue){
        var arrreturnvalue = returnvalue.split('$$$');
            if (arrreturnvalue[0] == "ERR")
                alert('未知错误!');
            else
                document.getElementById('UserNum').value = 'Guest';
            document.getElementById('UserPwd').value = '';
            document.getElementById('loginOutB').innerHTML = '(匿名用户请直接使用Guest用户名) ';
    });
    }

    function GetTids(tid) {
        var str = "";
        $("input[name='Items" + tid + "']").each(function () {
            if ($(this).attr("checked")) {
                str += $(this).val() + ","
            }
        })
        return str;
    }