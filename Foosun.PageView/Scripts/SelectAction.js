$(function () {
    $('#dialog-message').bgiframe();
});
//obj:页面要赋值的对象id，title：弹出窗口的显示标题，type：弹出窗口的类型，多个id用，隔开，widths：弹出窗口的宽度，heights：弹出窗口的高度。不需要加px。
function selectFile(obj, title, type, widths, heights) {
    $("#dialog-message").html("<iframe src=\"/configuration/system/iframe.aspx?FileType=" + type + "&heights=" + (heights - 65) + "&controlName=" + obj + "\" width=\"100%\" height=\"" + (heights - 52) + "\" scrolling=\"no\" frameborder=\"0\"></iframe>");
    $("#dialog-message").dialog({
        title: title,
        modal: true,
        width: widths,
        height: heights 
    });
}