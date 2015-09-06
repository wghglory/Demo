Ext.onReady(function () {
    //    ExtJS组件自适应浏览器大小改变,看还有没有其他实现方式
    Ext.EventManager.onWindowResize(function () {
        Ext.ComponentManager.each(function (cmpId, cmp, length) {
            if (cmp.hasOwnProperty("renderTo")) {
                cmp.doLayout();
            }
        });
    });
    this.UserTabPanel = Ext.create('Ext.tab.Panel', {
        region: 'center',
        layout: 'fit',
        id: 'UserTab',
        tabWidth: 120,
        collapisble: true,
        listeners: {
            tabchange: function (tp, p) {
                if (p.title == '详细列表') {
                    document.getElementById("iframeUserDetail").src = UserDetail;    //使用此方法可以重新刷新
                }
            }
        },
        items: [{ id: 'UserList', title: "用户信息", html: ' <iframe id="iframeUserList" scrolling="auto" frameborder="0" width="100%" height="100%" src="' + UserList + '"> </iframe>' },
          { id: 'UserDetail', title: "详细列表", html: ' <iframe id="iframeUserDetail" scrolling="auto" frameborder="0" width="100%" height="100%" src="' + UserDetail + '"> </iframe>'}]
    });

    Ext.create('Ext.container.Viewport', {
        layout: 'border',
        renderTo: Ext.getBody(),
        items: [this.UserTabPanel]
    });
});