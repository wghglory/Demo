/**
* 程序主入口
*/
Ext.onReady(function () {
    /**
    * 上,panel.Panel
    */
    this.topPanel = Ext.create('Ext.panel.Panel', {
        region: 'north',
        height: 55
    });
    /**
    * 左,panel.Panel
    */
    this.leftPanel = Ext.create('Ext.panel.Panel', {
        region: 'west',
        title: '主菜单',
        iconCls: 'House',
        width: 200,
        layout: 'accordion',
        collapsible: true
    });
    /**
    * 右,tab.Panel
    */
    this.rightPanel = Ext.create('Ext.tab.Panel', {
        region: 'center',
        layout: 'fit',
        id: 'mainContent',
        collapisble: true,
        tabWidth: 120,   
        items: [{ title: '首页', html: ' <iframe scrolling="auto" frameborder="0" width="100%" height="100%" src="' + DefaultUrl + '"> </iframe>'}]
    });
    /**
    * 下,panel.Panel
    */
    this.bottomPanel = Ext.create('Ext.panel.Panel', {
        region: 'south',
        layout: 'fit',
        id: 'foot',
        collapisble: true,
        height: 30,
        html:'<div>欢迎您光临！</div>'
    });
    /**
    * 组建树
    */
    Ext.define('TreeModelExtension', {
        extend: 'Ext.data.Model',
        //当Model实体类模型被用在某个TreeStore上,并且第一次实例化的时候 ,这些个属性会添加到Model实体类的的原型(prototype )上 (至于上述代码,则是通过把他设置为根节点的时候触发实例化处理的)
        fields: [
            {name: 'text',  type: 'string'},
            {name: 'url',  type: 'string'}
        ],
    });
    var buildTree = function (json) {
        return Ext.create('Ext.tree.Panel', {
            rootVisible: false,
            border: false,
            store: Ext.create('Ext.data.TreeStore', {
                model:'TreeModelExtension',
                root: {
                    expanded: true,
                    children: json.children
                }
            }),
            listeners: {
                'itemdblclick': function (view, record, item,
										index, e) {
                    var id = record.get('id');
                    var text = record.get('text');
                    var iconCls = record.get('iconCls');
                    var leaf = record.get('leaf');
                    var url = record.get('url');
                    if (leaf) {      //没有子节点时才创建新的tab显示
                        var tabs = Ext.getCmp('mainContent');  //获取布局页的Tab组件
                        var Loadtab = Ext.getCmp(id);          //判断Tab是否已经加载
                        if(Loadtab==undefined){                  //未加载则加载                          
                            tabs.add({
                                id:id,
                                closable: true,
                                //这种方式采取了加载多个iframe的方式,优化看如何采取一个iframe的方式
                                html: ' <iframe scrolling="auto" frameborder="0" width="100%" height="100%" src="' + url + '"> </iframe>',
                                iconCls: iconCls,
                                title: text
                            }).show()
                        }else{                                           //已加载则设置为活动页
                            //tabs.setActiveTab(id);           //适合于数据量较大，但是不需要实时改变得情况下,直接将已打开的tab设置为活动tab

                            //适合于需要实时展示最新数据的情况，先移除已打开的此tab，然后再重新加载
                            tabs.remove(id);
                            tabs.add({
                                id: id,
                                closable: true,
                                //这种方式采取了加载多个iframe的方式,优化看如何采取一个iframe的方式
                                html: ' <iframe scrolling="auto" frameborder="0" width="100%" height="100%" src="' + url + '"> </iframe>',
                                iconCls: iconCls,
                                title: text
                            }).show()
                        }
                    }
                },
                scope: this
            }
        });
    };
    /**
    * 加载菜单树
    */
    Ext.Ajax.request({
        url: AjaxPath,

        success: function (response) {
            var json = Ext.JSON.decode(response.responseText)
            Ext.each(json.data, function (el) {
                var panel = Ext.create(
												'Ext.panel.Panel', {
												    id: el.id,
												    title: el.text,
                                                    iconCls:el.iconCls,
												    layout: 'fit'
												});
                panel.add(buildTree(el));
                leftPanel.add(panel);
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
    /**
    * Viewport
    */
    Ext.create('Ext.container.Viewport', {
        layout: 'border',
        renderTo: Ext.getBody(),
        items: [this.topPanel, this.leftPanel, this.rightPanel, this.bottomPanel]
    });
});
