Ext.onReady(function () {
    //    ExtJS组件自适应浏览器大小改变,看还有没有其他实现方式
    Ext.EventManager.onWindowResize(function () {
        Ext.ComponentManager.each(function (cmpId, cmp, length) {
            if (cmp.hasOwnProperty("renderTo")) {
                cmp.doLayout();
            }
        });
    });
//    this.RoleTabPanel = Ext.create('Ext.panel.Panel', {
//        layout: 'fit',
//        tabWidth: 120,
//        collapisble: false,
//        //        renderTo: Ext.getBody(),     //当没有父窗口渲染时，需要加此
//        tbar: toolbar
//        //items: [{ items: grid}]
//    });

    var toolbar = Ext.create('Ext.toolbar.Toolbar', {
        renderTo: document.body,
        items: [
        // 使用右对齐容器
        '->', // 等同 { xtype: 'tbfill' }
        {
        xtype: 'textfield',
        name: 'roleName',
        id: 'roleName',
        emptyText: '输入角色名关键字',
        listeners: {
            specialkey: function (field, e) {
                if (e.getKey() == Ext.EventObject.ENTER) {
                    store.load({                //传递查询条件参数
                        params: {
                            roleName: Ext.getCmp('roleName').getValue()
                        }
                    });
                }
            }
        }
    },
    {
        // xtype: 'button', // 默认的工具栏类型
        text: '查询',
        tooltip: '根据数据条件查询数据',
        iconCls: "Zoom",
        listeners: {
            click: function () {
                store.load({                //传递查询条件参数
                    params: {
                        roleName: Ext.getCmp('roleName').getValue()
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
        Ext.getCmp('roleName').setValue("");
    }
},
    ]
});
//1.定义Model
Ext.define("BeiDream.model.BeiDream_Role", {
    extend: "Ext.data.Model",
    fields: [
        { name: 'ID', type: 'int' },
        { name: 'Name', type: 'string' },
        { name: 'Description', type: 'string' },
        { name: 'IsUsed', type: 'boolean', defaultValue: true }
    ]
});
//2.创建store
var store = Ext.create("Ext.data.Store", {
    model: "BeiDream.model.BeiDream_Role",
    autoLoad: true,
    pageSize: 10,
    proxy: {
        type: 'ajax',
        api: {
            read: RoleListUrl, //查询
            create: AddUrl, //创建
            update: UpdateUrl, //更新，必须真正修改了才会触发
            destroy: RemoveUrl //删除
        },
        reader: {
            type: 'json',
            root: 'data'
        },
        writer: {
            type: 'json',  //默认格式          //MVC下后台使用模型自动进行转换，如果是普通webform,则配置root：'data',encode:'true',这样之后就可以使用request【data】获取
            writeAllFields: true,   //false只提交修改过的字段
            allowSingle: false      //默认为true,为true时，一条数据不以数组形式提交，为false时，都以数组形式提交，这样避免了提交了一条数据时，后台是list模型无法接收到数据问题
        },
        listeners: {
            exception: function (proxy, response, operation) {
                grid.store.load();    //删除失败，数据重新加载
                var resText = Ext.decode(response.responseText);
                Ext.MessageBox.show({
                    title: '服务器端异常',
                    msg: resText.msg,
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
    var params = { roleName: Ext.getCmp('roleName').getValue() };
    Ext.apply(store.proxy.extraParams, params);
});
var Gridtoolbar = Ext.create('Ext.toolbar.Toolbar', {
    renderTo: document.body,
    items: [{
        text: '新增',
        tooltip: '新增一条数据',
        iconCls: 'Add',
        handler: function () {
            RowEditing.cancelEdit();
            // Create a model instance
            var r = new BeiDream.model.BeiDream_Role();
            Ext.getCmp('RoleGrid').getStore().insert(0, r);
            RowEditing.startEdit(0, 0);
        }
    }, '-', {
        text: '编辑',
        tooltip: '编辑当前选择行数据',
        iconCls: 'Pencil',
        handler: function () {
            RowEditing.cancelEdit();
            var data = Ext.getCmp("RoleGrid").getSelectionModel().getSelection();
            RowEditing.startEdit(data[0].index, 0);
        },
        disabled: true
    }, '-', {
        itemId: 'removeUser',
        text: '删除',
        tooltip: '可以多选删除多条数据',
        iconCls: 'Delete',
        handler: function () {
            Ext.MessageBox.confirm('提示', '确定删除该记录?', function (btn) {
                if (btn != 'yes') {
                    return;
                }
                var sm = Ext.getCmp('RoleGrid').getSelectionModel();
                RowEditing.cancelEdit();

                var store = Ext.getCmp('RoleGrid').getStore();
                store.remove(sm.getSelection());
                store.sync(); //根据状态执行对应的服务器方法,delete,放在remove后才能成功执行服务器方法
                if (store.getCount() > 0) {
                    sm.select(0);
                }
            });
        },
        disabled: true
    }, '-', {
        itemId: 'gridSync',
        text: '保存',
        tooltip: '保存到服务器',
        iconCls: 'Disk',
        handler: function () {
            grid.store.sync();
            grid.store.commitChanges();   //执行commitChanges()提交数据修改。
        }
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
                grid.store.rejectChanges();   //执行rejectChanges()撤销所有修改，将修改过的record恢复到原来的状态
            });
        }
    }, '-', {
        itemId: 'gridrefresh',
        text: '刷新',
        tooltip: '重新加载数据',
        iconCls: 'Arrowrefresh',
        handler: function () {
            grid.store.load();
        }
    }, '->', {
        itemId: 'ImportExcel',
        text: '导入Excel',
        tooltip: '导入角色数据',
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
        tooltip: '角色数据导出Excel',
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
var RowEditing = Ext.create('Ext.grid.plugin.RowEditing', { // 行编辑模式
    clicksToEdit: 2,   //双击进行修改  1-单击   2-双击   
    autoCancel: false,
    saveBtnText: '确定',
    cancelBtnText: '取消',
    errorsText: '错误',
    dirtyText: '你要确认或取消更改',
    listeners: {
        cancelEdit: function (rowEditing, context) {
            // Canceling editing of a locally added, unsaved record: remove it
            if (context.record.phantom) {    //服务器上是否有此条记录的标志,true为没有
                store.remove(context.record);
            }
        },
        Edit: function (rowEditing, context) {
            //store.sync();     //根据状态执行对应的服务器方法,Add/Edit
            var IsValidate = ValidateInput(context.record.data, context.record.phantom);
            if (!IsValidate) {
                grid.store.rejectChanges();
            }
        },
        validateedit: function (rowEditing, context) {

        }
    }
});
function ValidateInput(data, IsAdd) {
    var IsValidate;
    Ext.Ajax.request({
        url: ValidateInputUrl,
        method: 'POST',
        jsonData: data,
        params: { IsAdd: IsAdd },
        async: false,
        success: function (response) {
            var resText = Ext.decode(response.responseText);
            if (resText.success) {
                Ext.MessageBox.alert('警告', resText.msg);
                IsValidate = false;
            } else {
                IsValidate = true;
            }
        },
        failure: function (response, options) {
            Ext.MessageBox.alert('服务器异常', response.status);
        }
    });
    return IsValidate;
}
//多选框变化
function selectchange() {
    var count = this.getCount();
    //删除
    if (count == 0) {
        Gridtoolbar.items.items[2].disable();
        Gridtoolbar.items.items[4].disable();
    }
    else {
        Gridtoolbar.items.items[2].enable();
        Gridtoolbar.items.items[4].enable();
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
        mode: "MULTI",     //"SINGLE"/"SIMPLE"/"MULTI"
        checkOnly: false     //只能通过checkbox选择
    },
    selType: "checkboxmodel",
    columns: [
        { xtype: "rownumberer", text: "序号", width: 40, align: 'center' },
        { id: "id", text: "ID", width: 40, dataIndex: 'ID', sortable: true, hidden: true },
        { text: '角色名称', dataIndex: 'Name', flex: 1, editor: "textfield" },
        { text: '角色描述', dataIndex: 'Description', flex: 1, editor: "textfield" },
        { text: '是否启用', dataIndex: 'IsUsed', flex: 1, xtype: 'checkcolumn', editor: { xtype: 'checkbox', cls: 'x-grid-checkheader-editor'} }
    ],
    plugins: [RowEditing],
    listeners: {
        itemdblclick: function (me, record, item, index, e, eOpts) {
            //双击事件的操作
        }
    },
    tbar: Gridtoolbar,
    bbar: { xtype: "pagingtoolbar", store: store, displayInfo: true, emptyMsg: "没有记录" }
});
});