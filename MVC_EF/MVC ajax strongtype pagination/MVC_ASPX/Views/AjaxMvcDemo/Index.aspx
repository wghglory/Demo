<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
    <script src="../../Scripts/jquery-1.8.2.min.js"></script>
    <script src="../../Scripts/jquery.unobtrusive-ajax.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#loading').css('display', 'none');

            $('#btnGetTime').click(function () {
                $.ajax({
                    url: '/AjaxMvcDemo/GetTime',
                    data: {},
                    type: 'POST',
                    success: function (data) {
                        alert(data);
                    }
                });


                //$.get('/AjaxMvcDemo/GetTime', {}, function (data) {
                //    alert(data);
                //});

            });

        });

        function afterAjax(data) {
            alert('after----' + data);
        }
    </script>
</head>
<body>
    <div>
        <h3>jquery的方式</h3>
        <input type="button" value="获取时间" id="btnGetTime" />

        <hr />
        <h3>mvc的方式</h3>
        <% using (Ajax.BeginForm("GetTime", "AjaxMvcDemo", new AjaxOptions()
               {
                   Confirm = "您确认要点击么？",
                   HttpMethod = "Post",
                   OnSuccess = "afterAjax",
                   UpdateTargetId = "result",   //返回data放到这个id所在位置
                   InsertionMode = InsertionMode.Replace, //和UpdateTargetId成对出现
                   LoadingElementId = "loading"  //加载中的id
               }))
           { %>
        Name: <input type="text" name="txtName" /><br/>
        Age: <input type="text" name="txtAge" />
        <input type="submit" value="获取时间" />
        <% } %>

        <div id="loading">
            <img src="../../Content/ico_loading2.gif" />
        </div>

        <div id="result">
        </div>
    </div>
</body>
</html>
