//图标
var winController, currentComboBox;
function f_openSelectControllerWin() {

    //1.定义Model
    Ext.define("BeiDream.model.BeiDream_Controller", {
        extend: "Ext.data.Model",
        fields: [
        { name: 'ControllerName', type: 'string' },
        { name: 'LinkUrl', type: 'string' },
        { name: 'Description', type: 'string' }
    ]
    });
    //2.创建store
    var store = Ext.create("Ext.data.Store", {
        model: "BeiDream.model.BeiDream_Controller",
        autoLoad: true,
        pageSize: 10,
        proxy: {
            type: 'ajax',
            api: {
                read: ControllerUrl
            },
            reader: {
                type: 'json',
                root: 'data'
            }
        }
    });
    var Controllergrid = Ext.create("Ext.grid.Panel", {
        xtype: "grid",
        store: store,
        columnLines: true,
        selModel: {
            injectCheckbox: 0,
            mode: "SINGLE",     //"SINGLE"/"SIMPLE"/"MULTI"
            checkOnly: false     //只能通过checkbox选择
        },
        selType: "checkboxmodel",
        columns: [
        { xtype: "rownumberer", text: "序号", width: 40, align: 'center' },
        {text: '菜单', dataIndex: 'ControllerName', flex: 1 },
        { text: '路径', dataIndex: 'LinkUrl', flex: 1},
        { text: '描述', dataIndex: 'Description', flex: 1 }
    ],
        listeners: {
            itemdblclick: function (me, record, item, index, e, eOpts) {
                if (currentComboBox) {
                    currentComboBox.setValue(record.data.LinkUrl);
                }
                this.up("window").close(); //双击事件的操作
            }
        },
        bbar: { xtype: "pagingtoolbar", store: store, displayInfo: true, emptyMsg: "没有记录" }
    });

    if (winController) {
        winController.show();
        return;
    } else {
        winController = new Ext.Window({
        title: '控制器选择',
        layout: 'fit',
        items: [Controllergrid],
        overflowY: 'auto',
        closeAction: "hide",
        autoShow: true,
        width: 470, height: 330, modal: true,
        buttons: [
                    { xtype: "button", text: "确定", handler: function () {
                            var record = Controllergrid.getSelectionModel().getLastSelected();
                            if (record == null) {
                                Ext.MessageBox.alert('警告', '未选择任何行数据！');
                            } else {
                                if (currentComboBox) {
                                    currentComboBox.setValue(record.data.LinkUrl);
                                }
                                this.up("window").close();
                            }
                        }
                    },
                    { xtype: "button", text: "取消", handler: function () { this.up("window").close(); } }
                ]
            });
    }
}
