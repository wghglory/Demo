<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MVC_ASPX.Models.Student>>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
    <link href="../../Content/pageHelperNav.css" rel="stylesheet" />
    <link href="../../Content/jquery-easyui-1.3.1/themes/icon.css" rel="stylesheet" />
    <link href="../../Content/jquery-easyui-1.3.1/themes/default/easyui.css" rel="stylesheet" />
    <script src="../../Content/jquery-easyui-1.3.1/jquery-1.8.0.min.js"></script>
    <script src="../../Content/jquery-easyui-1.3.1/jquery.easyui.min.js"></script>
    <script src="../../Content/jquery-easyui-1.3.1/locale/easyui-lang-zh_CN.js"></script>

    <script src="../../Scripts/jquery.unobtrusive-ajax.js"></script>

    <script type="text/javascript">
        $(function () {
            $('#loading').hide();
            initTable();
            $('#EditStudent').hide();

        });

        function initTable(queryData) {
            if (queryData == null) {//第一次加载
                $('#loading').show();
            }

            $.getJSON('AjaxStudent/LoadStudentJson', queryData, function (data) {

                var tb = $('#tableStudents');
                $('#tableStudents tr[type=data]').remove();
                for (var i = 0; i < data.Data.length; i++) {
                    var strTr = '<tr type="data">';
                    strTr += '<td>' + data.Data[i].Id + '</td>';
                    strTr += '<td>' + data.Data[i].Name + '</td>';
                    strTr += '<td>' + data.Data[i].Age + '</td>';
                    strTr += '<td>' + data.Data[i].Gender + '</td>';
                    strTr += '<td><a Id=' + data.Data[i].Id + ' href="javascript:void(0)">修改</a> ' +
                        '<a Id=' + data.Data[i].Id + ' href="javascript:void(0)">删除</a></td>';
                    strTr += '</tr>';
                    tb.append(strTr);
                }

                initDeleteAndEditEvent();//初始化删除和修改的事件

                //处理分页的标签
                $('.paginator').html(data.NavStr);
                //绑定分页标签的点击事件
                $('.pageLink').click(function () {
                    //把页码弹出来
                    var strHref = $(this).attr('href');
                    var queryStr = strHref.substr(strHref.indexOf('?') + 1);
                    //alert(queryStr);
                    initTable(queryStr);
                    return false;
                });


                $('#loading').hide();
            });


        }

        function initDeleteAndEditEvent() {

            $('#tableStudents a:contains("修改")').click(function () {
                //弹出对话框之前给标签赋值。
                var id = $(this).attr('Id');
                $.getJSON('/AjaxStudent/GetStudentById/' + id, {}, function (data) {
                    $('#SId').text(data.Id);
                    $('#Name').val(data.Name);
                    $('#Age').val(data.Age);

                    $('#Gender').siblings().remove();
                    $('#Gender').val(data.Gender);
                    $('#Gender').text(data.Gender);
                    if (data.Gender == false) {
                        $('#Gender').parent().append('<option value="true">true</option');
                    } else {
                        $('#Gender').parent().append('<option value="false">false</option');
                    }

                    $('#hiddenId').val(data.Id);
                });

                //使用easy ui 弹出一个层出来。
                $('#EditStudent').css('display', 'block');
                $('#EditStudent').dialog({//弹出对话框
                    title: '对话框标题:修改用户',
                    width: 500,
                    height: 500,
                    collapsible: true,
                    minimizable: true,
                    maximizable: true,
                    resizable: true,
                    buttons: [{
                        text: '修改',
                        iconCls: 'icon-ok',
                        handler: function () {
                            //alert('修改');
                            //提交修改的表单。
                            $('#EditStudent form').submit();//触发表单提交
                        }

                    }]
                });
            });

            $('#tableStudents a:contains("删除")').click(function () {
                var link = $(this);

                if (confirm('您会删除？')) {
                    $.get('/AjaxStudent/Delete/' + $(this).attr('Id'), {}, function (deletData) {
                        if (deletData == 'ok') {//如果后台删除成功，给我们返回一个ok否则删除失败。
                            //方法1：写hiddenfield把当前pageindex存起来。initTable(index)
                            //方法2：把此行隐藏掉
                            link.parent().parent().hide('slow');
                        } else {
                            alert(data);
                        }
                    });
                }
                return false;
            });
        }

        //修改成之后，自动调用此方法
        function afterEdit(data) {
            if (data == 'ok') {
                $('#EditStudent').dialog('close');     //关闭对话框刷新表格
                reflashTb();//刷新表格
            } else {
                alert(data);
            }
        }

        function reflashTb() {
            var href = $('a.cpb').attr('href');
            initTable(href.substr(href.indexOf('?') + 1));
        }
    </script>
</head>

<body>
    <div id="loading">
        <img src="../../Content/ico_loading2.gif" />
    </div>
    <table id="tableStudents">
        <tr>
            <th>ID
            </th>
            <th>Name
            </th>
            <th>Age
            </th>
            <th>Gender
            </th>
            <th>operation
            </th>
        </tr>
    </table>
    <div class="paginator"></div>

    <div id="EditStudent">
        <h3>change student info</h3>

        <% using (Ajax.BeginForm("Edit", new AjaxOptions() { OnSuccess = "afterEdit", LoadingElementId = "loading" }))
           { %>
        <input type="hidden" name="Id" id="hiddenId" />
        <table>
            <tr>
                <td>ID
                </td>
                <td id="SId"></td>
            </tr>
            <tr>
                <td>Name
                </td>
                <td>
                    <input type="text" id="Name" name="Name" />
                </td>
            </tr>
            <tr>
                <td>Age
                </td>
                <td>
                    <input type="text" id="Age" name="Age" />
                </td>
            </tr>
            <tr>
                <td>Gender
                </td>
                <td>
                    <select name="Gender">
                        <option id="Gender"></option>

                    </select>
                </td>
            </tr>

        </table>
        <% } %>
    </div>
</body>
</html>
