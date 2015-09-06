Ext.onReady(function () {
    //    ExtJS组件自适应浏览器大小改变,看还有没有其他实现方式
    Ext.EventManager.onWindowResize(function () {
        Ext.ComponentManager.each(function (cmpId, cmp, length) {
            if (cmp.hasOwnProperty("renderTo")) {
                cmp.doLayout();
            }
        });
    });

    var RoleStores = GetRolesGroup();
    var myRolesItems = [];
    for (var i = 0; i < RoleStores.length; i++) {
        var boxLabel = RoleStores[i].Name;
        var ID = RoleStores[i].ID;
        var checked = RoleStores[i].IsContainCurrentUser;
        myRolesItems.push({
            boxLabel: boxLabel,
            name: 'Roles',
            inputValue: ID,
            checked: checked
        });
    }
    var myRolesGroup = new Ext.form.CheckboxGroup({
        xtype: 'checkboxgroup',
        //itemCls: 'x-check-group-alt',
        fieldLabel: "所属角色",
        afterLabelTextTpl: required,
        name: 'RolesGroup',
        allowBlank: false,
        blankText:'必须选择一个角色',
        disabled: true,
        columns: 5,
        flex: 1,
        items: myRolesItems
    });

    var selectName = Ext.define('selectName', {
        extend: 'Ext.data.Model',
        fields: ['ID', 'UserName', 'PassWord', 'IsDeleted', 'CreateDate'],
        proxy: {
            type: 'ajax',
            url: UserModelUrl,
            reader: {
                type: 'json',
                root: 'data'
            }
        }
    });

    var required = '<span style="color:red;font-weight:bold" data-qtip="Required">*</span>';
    var UserDetailFrom = Ext.create('Ext.form.Panel', {
        renderTo: Ext.getBody(),
        bodyStyle: 'padding:5px 5px 0',
        layout: 'form',
        url: SaveUserUrl,
        fieldDefaults: {
            labelAlign: 'right',
            msgTarget: 'side'
        },
        items: [{
            layout: 'column',	//从左往右布局
            border: false,
            items: [{
                xtype: 'hidden',
                name: 'ID',
            }, {
                columnWidth: .5,
                xtype: 'textfield',
                fieldLabel: '用户名',
                afterLabelTextTpl: required,
                name: 'UserName',
                allowBlank: false,
                disabled: true,
                emptyText: '请输入用户名称',
                minLength: 2,
                maxLength: 64
            }, {
                columnWidth: .5,
                xtype: 'textfield',
                fieldLabel: '密码',
                afterLabelTextTpl: required,
                disabled: true,
                name: 'PassWord',
                allowBlank: false,
                emptyText: '请输入用户密码',
                minLength: 6,
                maxLength: 8,
                inputType: "password"
            }]
        }, {
            layout: 'column',	//从左往右布局
            border: false,
            items: [{
                columnWidth: .5,
                xtype: 'checkbox',
                fieldLabel: '是否删除',
                name: 'IsDeleted',
                disabled: true,
                inputValue: "true",         //选中的值
                uncheckedValue: "false",    //未选中的值
            }, {
                columnWidth: .5,
                xtype: 'datefield',
                fieldLabel: '创建时间',
                editable: false,
                afterLabelTextTpl: required,
                disabled: true,
                //format: 'Y-m-d H:i:s',
                format: 'Y-m-d',
                name: 'CreateDate',
                emptyText: '请选择创建时间'
            }]
        }, myRolesGroup],
        dockedItems: [{
            xtype: 'toolbar', dock: 'top', id: 'Usertoolbar',
            items: ['->', {
                text: '新增',
                tooltip: '新增一条数据',
                iconCls: 'Add',
                handler: function () {
                    Ext.getCmp("Usertoolbar").queryById('EditUser').disable();
                    Ext.getCmp("Usertoolbar").queryById('removeUser').disable();
                    AllowEdit();
                    onReset();
                }
            }, '-', {
                text: '编辑',
                itemId: 'EditUser',
                tooltip: '编辑当前选择行数据',
                iconCls: 'Pencil',
                handler: function () {
                    AllowEdit();
                },
                disabled: true
            }, '-', {
                itemId: 'removeUser',
                text: '删除',
                tooltip: '删除当前数据',
                iconCls: 'Delete',
                handler: function () {
                    Ext.MessageBox.confirm('提示', '确定删除该记录?', function (btn) {
                        if (btn != 'yes') {
                            return;
                        }
                        DeleteCurrentUser();
                        //todo:设置重新刷新UserList
                        window.parent.UserTabPanel.setActiveTab('UserList');   //通过子Tab的id进行切换.
                    });
                },
                disabled: true
            }, '-', {
                itemId: 'SaveUser',
                text: '保存',
                tooltip: '保存到服务器',
                iconCls: 'Disk',
                handler: function () {
                    f = UserDetailFrom.getForm();
                    if (f.isValid()) {
                        f.submit({
                            submitEmptyText:false,         //不将为空显示的值传到后台
                            //params: { RoleGroup: ID },
                            //waitMsg: "正在保存数据，请等待……",
                            //waitTitle: "正在保存数据",
                            success: function (form, action) {
                                Ext.Msg.alert("提示信息",action.result.msg);
                            },
                            failure: function () {
                                //Ext.Msg.alert("提示信息", "保存失败!");
                            }
                        });
                    }
                },
                disabled: true
            }, '-', {
                itemId: 'gridCancel',
                text: '取消',
                tooltip: '取消所有的已编辑数据',
                iconCls: 'Decline',
                handler: function () {
                    Ext.MessageBox.confirm('提示', '确定取消已编辑数据吗?', function (btn) {
                        if (btn != 'yes') {
                            return;
                        }
                        window.parent.UserTabPanel.setActiveTab('UserList');   //通过子Tab的id进行切换.
                    });
                }
            }, '-', {
                itemId: 'gridrefresh',
                text: '重置',
                tooltip: '清空所有已填数据',
                iconCls: 'Arrowrefresh',
                handler: function () {
                    onReset();
                }
            }
            ]
        }]
    });
    selectName.load(1, {
        success: function (record, operation) {
            UserDetailFrom.getForm().loadRecord(record);
            Ext.getCmp("Usertoolbar").queryById('EditUser').enable();
            Ext.getCmp("Usertoolbar").queryById('removeUser').enable();
        }
    });
    function AllowEdit() {
        Ext.getCmp("Usertoolbar").queryById('SaveUser').enable();
        //todo：递归所有的item
        UserDetailFrom.items.each(function (item, index, length) {
            if (item.items.length != 0) {
                item.items.each(function (childitem, childindex, childlength) {
                    childitem.enable();
                });
            }
            item.enable();
        });
    } 
    function onReset() {
        UserDetailFrom.getForm().reset();
        if (UserDetailFrom.items.items[0]) {
            UserDetailFrom.items.items[0].focus(true, 10);
        }
        //必须放在from重置之后，因为form的重置是恢复到form最初加载的状态
        myRolesGroup.items.each(function (item, index, length) {
            item.setValue(false);    //设置checkbox选中或未选中状态,并且要在界面上样子改变，必须使用setValue(),好像extjs里直接设置属性是不会改变界面样子，必须使用方法改变才会改变界面样子
        });
    }
});
function GetRolesGroup() {
    var RoleStores=[];
    Ext.Ajax.request({
        url: RoleListGroupUrl,
        method: 'POST',
        async: false,
        success: function (response) {
            var resText = Ext.decode(response.responseText);
            if (resText.success) {
                RoleStores = resText.data;
            } else {
                Ext.MessageBox.alert('服务器异常', resText.msg);
            }
        },
        failure: function (response, options) {
            Ext.MessageBox.alert('服务器异常', response.status);
        }
    });
    return RoleStores;
}
function DeleteCurrentUser() {
    Ext.Ajax.request({
        url: DeleteCurrentUserUrl,
        method: 'POST',
        async: false,
        success: function (response) {
            var resText = Ext.decode(response.responseText);
            Ext.MessageBox.alert('提示', resText.msg);
        },
        failure: function (response, options) {
            Ext.MessageBox.alert('服务器异常', response.status);
        }
    });
    return RoleStores;
}