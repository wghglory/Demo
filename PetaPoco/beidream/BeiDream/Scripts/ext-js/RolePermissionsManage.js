Ext.onReady(function () {
    //    ExtJS组件自适应浏览器大小改变,看还有没有其他实现方式
    Ext.EventManager.onWindowResize(function () {
        Ext.ComponentManager.each(function (cmpId, cmp, length) {
            if (cmp.hasOwnProperty("renderTo")) {
                cmp.doLayout();
            }
        });
    });
Ext.create('Ext.container.Viewport', {
    layout: 'border',
    renderTo: Ext.getBody(),
    items: [{
        title: '角色列表',
        region: 'west',
        xtype: 'panel',
        margins: '5 0 0 5',
        width: 200,
        collapsible: false,   // 可折叠/展开
        id: 'RoleListTreecontainer',
        layout: 'fit'
    }, {
        region: 'center',     // 必须指定中间区域
        xtype: 'panel',
        layout: 'fit',
        id: 'Gridcontainer',
        margins: '5 5 0 0'
    }]
});

    var RoleListTree=Ext.getCmp('RoleListTreecontainer');
    /**
    * 加载菜单树
    */
    Ext.Ajax.request({
        url: RoleListTreeUrl,
        success: function (response) {
            var json = Ext.JSON.decode(response.responseText)
            Ext.each(json.data, function (el) {
                var panel = Ext.create(
												'Ext.panel.Panel', {
												    id: el.id,
												    layout: 'fit'
												});
                panel.add(buildTree(el));
                RoleListTree.add(panel);
            });
        },
        failure: function (request) {
            Ext.MessageBox.show({
                title: '操作提示',
                msg: "连接服务器失败",
                buttons: Ext.MessageBox.OK,
                icon: Ext.MessageBox.ERROR
            });
        },
        method: 'post'
    });
    var Gridcontainer=Ext.getCmp('Gridcontainer');
   /**
    * 组建树
    */
    Ext.define('TreeModelExtension', {
        extend: 'Ext.data.Model',
        //当Model实体类模型被用在某个TreeStore上,并且第一次实例化的时候 ,这些个属性会添加到Model实体类的的原型(prototype )上 (至于上述代码,则是通过把他设置为根节点的时候触发实例化处理的)
        fields: [
            {name: 'text',  type: 'string'}
        ],
    });
    var buildTree = function (json) {
        return Ext.create('Ext.tree.Panel', {
            id:'MenuTree',
            rootVisible: false,
            border: false,
            store: Ext.create('Ext.data.TreeStore', {
                model:'TreeModelExtension',
                root: {
                    text:json.text,
                    iconCls:'Zoomout',
                    children: json.children
                }
            }),
            listeners: {
                'itemclick': function (view, record, item,
										index, e) {
//                        var ParentID = record.get('id');
//                        var ShowGrid=CreateGrid(ParentID);
//                        Gridcontainer.add(ShowGrid);
                    },
                scope: this
            }
        });
    };

function CreateGrid(ParentID) {
var Gridtoolbar = Ext.create('Ext.toolbar.Toolbar', {
    renderTo: document.body,
    items: [{
        text: '新增',
        tooltip: '新增一条数据',
        iconCls: 'Add',
        handler: function () {
            RowEditing.cancelEdit();
            // Create a model instance
            var r = new BeiDream.model.BeiDream_NavigationMenu();
            Ext.getCmp('NavigationMenuGrid').getStore().insert(0, r);
            RowEditing.startEdit(0, 0);
        }
    }, '-', {
        text: '编辑',
        tooltip: '编辑当前选择行数据',
        iconCls: 'Pencil',
        handler: function () {
            RowEditing.cancelEdit();
            var data = Ext.getCmp("NavigationMenuGrid").getSelectionModel().getSelection();
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
                var sm = Ext.getCmp('NavigationMenuGrid').getSelectionModel();
                RowEditing.cancelEdit();

                var store = Ext.getCmp('NavigationMenuGrid').getStore();
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
            var grid=Ext.getCmp('NavigationMenuGrid');
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
                var grid=Ext.getCmp('NavigationMenuGrid');
                grid.store.rejectChanges();   //执行rejectChanges()撤销所有修改，将修改过的record恢复到原来的状态
            });
        }
    }, '-', {
        itemId: 'gridrefresh',
        text: '刷新',
        tooltip: '重新加载数据',
        iconCls: 'Arrowrefresh',
        handler: function () {
             var grid=Ext.getCmp('NavigationMenuGrid');
            grid.store.load();
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
//        beforeedit: function (rowEditing,e,context) {
//            if(e.colldx==2 && e.record.data.IsLeaf==false){
//                return false;
//            }else{
//               return true;
//            }
//        },
        cancelEdit: function (rowEditing, context) {
            // Canceling editing of a locally added, unsaved record: remove it
            if (context.record.phantom) {    //服务器上是否有此条记录的标志,true为没有
                store.remove(context.record);
            }
        },
        Edit: function (rowEditing, context) {
            //store.sync();     //根据状态执行对应的服务器方法,Add/Edit
            //var IsValidate = ValidateInput(context.record.data, context.record.phantom);
//            if (!IsValidate) {
//                grid.store.rejectChanges(); 
//            }
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
//1.定义Model
Ext.define("BeiDream.model.BeiDream_NavigationMenu", {
    extend: "Ext.data.Model",
    fields: [
        { name: 'ID', type: 'int' },
        { name: 'ParentID', type: 'int' },
        { name: 'ShowName', type: 'string', defaultValue: '名称......' },
        { name: 'IsLeaf', type: 'boolean', defaultValue: true },
        { name: 'url', type: 'string' },
        { name: 'OrderNo', type: 'int', defaultValue: 1 },
        { name: 'iconCls', type: 'string' },
        { name: 'Expanded', type: 'boolean', defaultValue: false }
    ]
});
//2.创建store
var store = Ext.create("Ext.data.Store", {
    model: "BeiDream.model.BeiDream_NavigationMenu",
    autoLoad: true,
    pageSize: 15,
    proxy: {
        type: 'ajax',
        api: {
            read: MenuListUrl, //查询
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
//                 var grid=Ext.getCmp('NavigationMenuGrid');
//                grid.store.load();    //删除失败，数据重新加载
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
});
store.on('beforeload', function (store, options) {
    var params = { ParentID: ParentID };
    Ext.apply(store.proxy.extraParams, params);
});
        return Ext.create("Ext.grid.Panel", {
        id: "NavigationMenuGrid",
        xtype: "grid",
        store: store,
        columnLines: true,
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
            { id: "id", text: "ParentID", width: 40, dataIndex: 'ParentID', sortable: true, hidden: true },
            { text: '名称', dataIndex: 'ShowName', flex: 1, editor: {
                xtype: 'textfield',
                allowBlank: false
            }  },
            { text: '是否为模块', dataIndex: 'IsLeaf', flex: 1, xtype: 'checkcolumn', editor: { xtype: 'checkbox', cls: 'x-grid-checkheader-editor'} },
            { text: '控制器路径', dataIndex: 'url', flex: 1, editor : {
                    xtype: 'combobox',
                    editable:false,    
                    listeners: {
                        //点击下拉列表事件
                        expand: function (me, event, eOpts) {
                            var grid=Ext.getCmp('NavigationMenuGrid');
                            var record = grid.getSelectionModel().getLastSelected();
                            if(record!=null){
                               if(record.data.IsLeaf==true){
                                      currentComboBox = me;
                                      f_openSelectControllerWin();
                               }else{
                                    Ext.MessageBox.alert('警告', '只有模块才拥有控制器！');
                               }
                            }                          

                        }
                    }
            }  },
            { text: '排序号', dataIndex: 'OrderNo',align:"center", width: 48, flex: 1,editor: {
                xtype: 'numberfield',
                allowBlank: false,
                minValue: 1,
                maxValue: 150000
            } },
            { text: '图标', dataIndex: 'iconCls',align:"center", width: 48,renderer : function(value) {
                    return "<div Align='center' style='height:16px;width:16px' class="+value+"></div>";
               } ,editor : {
                    xtype: 'combobox',
                    editable:false,    
                    listeners: {
                        //点击下拉列表事件
                        expand: function (me, event, eOpts) {
                            currentComboBox = me;
                            f_openIconsWin();
                        }
                    }
            } },
            { text: '是否展开', dataIndex: 'Expanded', flex: 1, xtype: 'checkcolumn', editor: { xtype: 'checkbox', cls: 'x-grid-checkheader-editor'} }
        ],
        plugins: [RowEditing],
        tbar: Gridtoolbar,
        bbar: { xtype: "pagingtoolbar", store: store, displayInfo: true, emptyMsg: "没有记录" }
    });
  };
});