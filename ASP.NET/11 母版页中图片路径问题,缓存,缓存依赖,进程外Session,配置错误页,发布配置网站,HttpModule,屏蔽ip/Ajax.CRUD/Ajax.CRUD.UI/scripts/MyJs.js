//=======页面加载==========================================================
$(function () {
    //异步加载数据
    initStudents(1);
    //为编辑的“取消按钮”注册单击事件
    $('#btnCancel').click(function () {
        $('#dvDetails').hide();
    });
    //为“编辑”中的“保存”注册单击事件
    $('#btnSave').click(function () {
        //1.获取用户输入的内容
        var user_data = $('#fromEdit').serialize();

        //2.请求对应的一般处理程序实现更新
        $.post('UpdateStudent.ashx', user_data, function (_resText) {
            //    alert(_resText);
            if (_resText == "1") {
                //1.隐藏当前的编辑层
                $('#dvDetails').hide();

                //2.重新加载当前数据
                initStudents(1);
            }
        });
        //3.获取服务器的返回值。

        //4.更行表中的行

        //5.隐藏层
    });
});
//=========注册删除按钮的单击事件==============================================

//为页面上的所有的“删除”超链接绑定事件
function initDeleteEvents() {

    //1.先选择到所有的“删除”超链接
    $('a.deleteCls').click(function () {
        //alert();
        var stuid = $(this).attr('sid');
        var currentAlink = this;

        //向DeleteStudentById.ashx?sid=10发起一个异步请求
        $.get('DeleteStudentById.ashx', { sid: stuid }, function (_resText) {
            //alert(_resText);
            //_resText返回1的时候表示删除成功！
            if (_resText == "1") {
                //把当前行从表格中移除
                //特别提示：这里不能直接写$(this),因为这儿不是直接在超链接的单击事件里面，而是在$.get()方法中的一个回调函数中，所以这里不能直接使用$(this),需要现在超链接的单击事件中获取this,设置到currentALink变量中，然后再这使用这个变量，就是当前点击的超链接。s
                $(currentAlink).parent().parent().remove();
            }
        });
    });
}








//==========注册编辑按钮的单击事件============================

//为“编辑”超链接注册点击事件
function initEditEvents() {
    //1.获取所有的“编辑”超链接
    $('a.editCls').click(function () {
        //获取用户当前点击的行的sid
        var stuId = $(this).attr('sid');

        //发起异步请求，获取当前点击行的所有数据（从数据库中重新查询）
        $.getJSON('GetStudentInfoBySid.ashx', { sid: stuId }, function (_jsonData) {
            //_jsonData就表示当前行的记录的json对象
            //设置层显示
            var dvObj$ = $('#dvDetails');
            //将查询到的数据写在层的元素中。
            $('#spNumber').text(_jsonData.StuId);
            $('#hiddenStuId').val(_jsonData.StuId);
            $('#txtUserName').val(_jsonData.StuName);
            $('#txtAge').val(_jsonData.StuAge);
            $('#selectGender').val([_jsonData.StuGender]);
            $('#txtEmail').val(_jsonData.StuEmail);
            $('#txtBirthday').val((eval(_jsonData.StuBirthday.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("yyyy-MM-dd"));

            dvObj$.css('display', 'block');
        });

    });
    //2.为超链接注册点击事件
}









//======================发起异步请求加载数据===============================

//根据用户要查看第几页，异步发起请求
function initStudents(pageindex) {
    //加载数据之前清空tbody中的内容
   
    $.getJSON('GetStudentsByPage.ashx', { 'pageindex': pageindex }, function (_jsondata) {
        //测试回调能否正常获取数据
        //alert(JSON.stringify(_jsondata));
        $('#tblStudent tbody').empty();
        //1.把对应的数据添加到表格中
        //遍历查询到的每条学生记录，
        for (var i = 0; i < _jsondata.StudentList.length; i++) {
            //创建一行，并添加到tbody中
            $('<tr><td>' + _jsondata.StudentList[i].StuId + '</td><td>' + _jsondata.StudentList[i].StuName + '</td><td>' + _jsondata.StudentList[i].StuAge + '</td><td>' + _jsondata.StudentList[i].StuGender + '</td><td>' + _jsondata.StudentList[i].StuEmail + '</td><td>' + (eval(_jsondata.StudentList[i].StuBirthday.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("yyyy-M-d") + '</td><td><a sid=\"' + _jsondata.StudentList[i].StuId + '\" href="javascript:void(0);" class="editCls">编辑</a></td><td><a sid=\"' + _jsondata.StudentList[i].StuId + '\" class="deleteCls"  href="javascript:void(0);">删除</a></td></tr>').appendTo('#tblStudent tbody');
        }
        //2.把导航字符串添加到pnav中
        document.getElementById('pnav').innerHTML = _jsondata.NavigatorString;


        //3.//为导航实现异步操作:原理：为每个导航的超链接标签注册一个onclick事件，在该事件中调用异步函数进行请求。 
        initNavigatorEvents();

        //4.为删除超链接绑定事件
        initDeleteEvents();

        //5.为“编辑”注册点击事件
        initEditEvents();
    });
}




//======================初始化导航超链接单击事件=================

function initNavigatorEvents() {
    //1.获取所有导航，超链接，并为每个超链接注册单击事件
    $('#pnav a').click(function () {
        //initStudents(??);
        var url = this.href;
        var pindex = url.substring(url.lastIndexOf('=') + 1);
        initStudents(pindex);
        return false;
    });
}