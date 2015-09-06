Ext.onReady(function () {
    //    ExtJS组件自适应浏览器大小改变,看还有没有其他实现方式
    Ext.EventManager.onWindowResize(function () {
        Ext.ComponentManager.each(function (cmpId, cmp, length) {
            if (cmp.hasOwnProperty("renderTo")) {
                cmp.doLayout();
            }
        });
    });
    var Rolestore = Ext.create('Ext.data.Store', {
        fields: [
            { type: 'int', name: 'ID' },
            { type: 'string', name: 'Name' },
        ],
        proxy: {
            type: 'ajax',
            api: {
                read: RoleListUrl
            },
            reader: {
                type: 'json',
                root: 'data'
            },
            listeners: {
                exception: function (proxy, response, operation) {
                    Ext.MessageBox.show({
                        title: '服务器端异常',
                        msg: operation.getError(),
                        icon: Ext.MessageBox.ERROR,
                        buttons: Ext.Msg.OK
                    });
                }
            }
        }
    });
    var Rolecombo = Ext.create('Ext.form.field.ComboBox', {
        id: "Rolecombo",
        fieldLabel: '角色名称',
        labelWidth: 60,
        store: Rolestore,
        displayField: 'Name',
        valueField: 'ID',
        typeAhead: true,
        queryMode: 'remote', //设置为远程获取数据模式，才能从加载服务器数据
        triggerAction: 'all',
        emptyText: '请选择......',
        editable: false,
        selectOnFocus: true,
        listeners: {
            specialkey: function (field, e) {
                if (e.getKey() == Ext.EventObject.ENTER) {
                    store.load({                //传递查询条件参数
                        params: {
                            start: 0,
                            page:1,
                            UserKeyName: Ext.getCmp('UserKeyName').getValue(),
                            RoleID: Ext.getCmp('Rolecombo').getValue()
                        }
                    });
                }
            }
        }
    });
    var toolbar = Ext.create('Ext.toolbar.Toolbar', {
        items: [
        {
            fieldLabel: '用户名称',
            labelWidth: 60,
            xtype: 'textfield',
            name: 'UserKeyName',
            id: 'UserKeyName',
            emptyText: '输入用户名关键字',
            listeners: {
                specialkey: function (field, e) {
                    if (e.getKey() == Ext.EventObject.ENTER) {
                        store.load({                //传递查询条件参数
                            params: {
                                start: 0,
                                page: 1,
                                UserKeyName: Ext.getCmp('UserKeyName').getValue(),
                                RoleID: Ext.getCmp('Rolecombo').getValue()
                            }
                        });
                    }
                }
            }
        },
        //添加空格
    '  ',
         Rolecombo
        ,
    {
        // xtype: 'button', // 默认的工具栏类型
        text: '查询',
        tooltip: '根据数据条件查询数据',
        iconCls: "Zoom",
        listeners: {
            click: function () {
                store.load({                //传递查询条件参数
                    params: {
                        start: 0,
                        page: 1,
                        UserKeyName: Ext.getCmp('UserKeyName').getValue(),
                        RoleID: Ext.getCmp('Rolecombo').getValue()
                    }
                });
            }
        }
    },
        // 添加工具栏项之间的垂直分隔条
        '-', // 等同 {xtype: 'tbseparator'} 创建 Ext.toolbar.Separator
    {
    // xtype: 'button', // 默认的工具栏类型
    text: '重置',
    tooltip: '清空当前查询条件',
    iconCls: "Arrowrotateanticlockwise",
    handler: function () {                   //此事件可以代替click事件
        Ext.getCmp('UserKeyName').setValue("");
        Ext.getCmp('Rolecombo').setValue("")
    }
},
     '->', {
         itemId: 'ImportExcel',
         text: '导入Excel',
         tooltip: '导入用户数据',
         iconCls: 'Pageexcel',
         handler: function () {
             Ext.MessageBox.show({
                 title: '暂未开放',
                 msg: '即将开放',
                 icon: Ext.MessageBox.ERROR,
                 buttons: Ext.Msg.OK
             });
         }
     }, '-', {
         itemId: 'ExportExcel',
         text: '导出Ecxel',
         tooltip: '用户数据导出Excel',
         iconCls: 'Pageexcel',
         handler: function () {
             Ext.MessageBox.show({
                 title: '暂未开放',
                 msg: '即将开放',
                 icon: Ext.MessageBox.ERROR,
                 buttons: Ext.Msg.OK
             });
         }
     }
        ]
    });
    //1.定义Model
    Ext.define("BeiDream.model.BeiDream_User", {
        extend: "Ext.data.Model",
        fields: [
            { name: 'ID', type: 'int' },
            { name: 'UserName', type: 'string' },
            { name: 'CreateDate', type: 'date' },
            { name: 'IsDeleted', type: 'boolean', defaultValue: true }
        ]
    });
    //2.创建store
    var store = Ext.create("Ext.data.Store", {
        model: "BeiDream.model.BeiDream_User",
        autoLoad: true,
        pageSize: 10,
        proxy: {
            type: 'ajax',
            api: {
                read: UserListUrl
            },
            reader: {
                type: 'json',
                root: 'data'
            },
            listeners: {
                exception: function (proxy, response, operation) {
                    grid.store.load();    //删除失败，数据重新加载
                    Ext.MessageBox.show({
                        title: '服务器端异常',
                        msg: operation.getError(),
                        icon: Ext.MessageBox.ERROR,
                        buttons: Ext.Msg.OK
                    });
                }
            }
        }
        //    sorters: [{
        //        //排序字段。  
        //        property: 'id'
        //    }] 
    });
    store.on('beforeload', function (store, options) {
        var params = { UserKeyName: Ext.getCmp('UserKeyName').getValue(), RoleID: Ext.getCmp('Rolecombo').getValue() };
        Ext.apply(store.proxy.extraParams, params);
    });

    //多选框变化
    function selectchange() {
        var SelectID = getSelectedGridID();
        var count = this.getCount();
        if (count == 0) {
            RemoveSelectId();
        }
        else {
            SaveSelectId(SelectID);
        }

    }
    function getSelectedGridID() {
        var grid = Ext.getCmp('RoleGrid');
        var rowSelectionModel = grid.getSelectionModel();
        if (rowSelectionModel.hasSelection()) {
            var record = rowSelectionModel.getLastSelected();
            var tableName = record.get('ID');
            return tableName;
        } else {
            return '';
        }
    }
    //3.创建grid
    var grid = Ext.create("Ext.grid.Panel", {
        id: "RoleGrid",
        xtype: "grid",
        store: store,
        columnLines: true,
        renderTo: Ext.getBody(),
        selModel: {
            injectCheckbox: 0,
            listeners: {
                'selectionchange': selectchange
            },
            mode: "SINGLE",     //"SINGLE"/"SIMPLE"/"MULTI"
            checkOnly: false     //只能通过checkbox选择
        },
        selType: "checkboxmodel",
        columns: [
            { xtype: "rownumberer", text: "序号", width: 40, align: 'center' },
            { id: "id", text: "ID", width: 40, dataIndex: 'ID', sortable: true, hidden: true },
            { text: '用户名称', dataIndex: 'UserName', flex: 1 },
            { xtype: 'datecolumn', header: '创建时间', dataIndex: 'CreateDate', flex: 1, format: 'Y-m-d' },
            { text: '是否删除', dataIndex: 'IsDeleted', flex: 1, xtype: 'checkcolumn' }
        ],
        listeners: {
            itemdblclick: function (me, record, item, index, e, eOpts) {
                //双击事件的操作
                SaveSelectId(record.data.ID);    //将当前选择的记录ID保存到session中,以便详细信息使用
                //很实用的方法，调用父页面的控件，能获取一个框架的父窗口或父框架
                //window.parent.UserTabPanel.setActiveTab('UserDetail');   //通过子Tab的id进行切换.
                window.parent.UserTabPanel.remove('UserDetail');
                window.parent.UserTabPanel.add({
                    id: 'UserDetail', title: "详细列表", html: ' <iframe id="iframeUserDetail" scrolling="auto" frameborder="0" width="100%" height="100%" src="' + UserDetail + '"> </iframe>'
                }).show();
            }
        },
        tbar: toolbar,
        bbar: { xtype: "pagingtoolbar", store: store, displayInfo: true, emptyMsg: "没有记录" }
    });
});
function SaveSelectId(ID) {
    Ext.Ajax.request({
        url: SaveSelectIdUrl,
        method: 'POST',
        params: { ID: ID },
        async: false,
        success: function (response) {
            var resText = Ext.decode(response.responseText);
            if (resText.success) {
            } else {
                Ext.MessageBox.alert('服务器异常', resText.msg);
            }
        },
        failure: function (response, options) {
            Ext.MessageBox.alert('服务器异常', response.status);
        }
    });
}
function RemoveSelectId() {
    Ext.Ajax.request({
        url: RemoveSelectIdUrl,
        method: 'POST',
        async: false,
        success: function (response) {
            var resText = Ext.decode(response.responseText);
            if (resText.success) {
            } else {
                Ext.MessageBox.alert('服务器异常', resText.msg);
            }
        },
        failure: function (response, options) {
            Ext.MessageBox.alert('服务器异常', response.status);
        }
    });
}