/*
    文件说明：
        icon选取

    接口方法：
        1，打开窗口方法：f_openIconsWin
        2，保存下拉框ligerui对象：currentComboBox

    例子：
        可以这样使用(选择ICON完了以后，会把icon src保存到下拉框的inputText和valueField)：
        onBeforeOpen: function ()
        {
            currentComboBox = this;
            f_openIconsWin();
            return false;
        }

*/

//图标
var jiconlist, winicons, currentComboBox;
$(function ()
{
    jiconlist = $("body > .iconlist:first");
    if (!jiconlist.length) jiconlist = $('<ul class="iconlist"></ul>').appendTo('body');
});

$(".iconlist li").live('mouseover', function () {
    $(this).addClass("over");
    }).live('mouseout', function () {
        $(this).removeClass("over");
}).live('click', function ()
{
    if (!winicons) return;
    var src = $("div", this).attr("class");
    //src = src.replace(/^([\.\/]+)/, '');
    if (currentComboBox)
    {
        currentComboBox.setValue(src);
    }
    winicons.hide();
});

function f_openIconsWin()
{
    if (winicons) {
        winicons.show();
        return;
    } else {
        winicons = new Ext.Window({
            title: '单击选取图标',
            contentEl: 'iconShow',
            overflowY: 'auto',
            closeAction: "hide",          //在关闭Extjs Window的时候，通过配置项closeAction可以控制按钮是销毁（destroy）还是隐藏（hide），默认情况下为销毁
            width: 470, height: 330, modal: true
        });
//        winicons.on("beforeclose", function (win) {     上面的closeAction: "hide"实现此功能
//            winicons.hide();
//            return false;
//        })
        winicons.show();
    }

    if (!jiconlist.attr("loaded")) {
        Ext.Ajax.request({
            url: IconsUrl,
            method: 'POST',
            async: false,
            success: function (response) {
                var resText = Ext.decode(response.responseText);
                if (resText.success) {
                    for (var i = 0, l = resText.data.length; i < l; i++) {
                        var src = resText.data[i];
                        jiconlist.append("<li><div style='height:16px;width:16px' class=" + src + "></div></li>");
                    }
                    jiconlist.attr("loaded", true);
                } else {
                    Ext.MessageBox.alert('警告', response.msg);
                }
            },
            failure: function (response, options) {
                Ext.MessageBox.alert('服务器异常', response.status);
            }
        });
    }
}