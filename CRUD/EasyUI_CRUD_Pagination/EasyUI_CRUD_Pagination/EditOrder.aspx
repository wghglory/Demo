<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditOrder.aspx.cs" Inherits="EasyUI_CRUD_Pagination.EditOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery-1.8.0.min.js"></script>
    <script type="text/javascript">
        $(function () {
        });

        function submitFrm() {
            //alert("我是子容器");
            //让下面的表单整体的异步的提交到后台。
            var postData = $("#form1").serializeArray();
            $.post("EditOrder.aspx", postData, function (data) {
                if (data == "ok") {
                    //修改成功
                    //关闭父容器的对话框，刷新父容器的表格。
                    window.parent.window.afterEditSuccess();
                } else {
                    alert("败了啊");
                }
            });
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="hidden" name="hidId" id="hidId" value="<%=model.Id %>" />

            <table>
                <tr>
                    <td>商品名称：</td>
                    <td>
                        <input type="text" name="txtProductName" id="txtProductName" value="<%= model.ProductName %>" />
                    </td>
                </tr>
                <tr>
                    <td>销售价格：</td>
                    <td>
                        <input type="text" name="txtPrice" id="txtPrice" value="<%= model.SellPrice %>" />
                    </td>
                </tr>
                <tr>
                    <td>销量：</td>
                    <td>
                        <input type="text" name="txtAmount" id="txtAmount" value="<%= model.SellAmount %>" />
                    </td>
                </tr>
                <tr>
                    <td>购买人：</td>
                    <td>
                        <input type="text" name="txtPurchaser" id="txtPurchaser" value="<%= model.Purchaser %>" />
                    </td>
                </tr>
                <tr>
                    <td>销售日期：</td>
                    <td>
                        <input type="text" name="txtSellDate" id="txtSellDate" value="<%= model.SellDate %>" />
                    </td>
                </tr>
                <tr>
                    <td>销售人员：</td>
                    <td>
                        <input type="text" name="txtSalesPerson" id="txtSalesPerson" value="<%= model.Salesperson %>" />
                    </td>
                </tr>
                <tr>
                    <td>商品序号：</td>
                    <td>
                        <input type="text" name="txtProductCode" id="txtProductCode" value="<%= model.ProductCode %>" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
