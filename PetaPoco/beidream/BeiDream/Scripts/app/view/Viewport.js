/// <reference path="../../ext-4.21/ext.js" />
Ext.define('BDream.view.Viewport', {
    extend: 'Ext.container.Viewport',
    layout: 'border',
    initComponent: function () {
        var me = this;
        me.items = [{
            title: 'ExtJS案例',
            collapisble: true,
            region: 'north',
            height: 100,
            html: '<br><center><font size=5>MVC模式实现的ExtJS案例</font><br><font size=2>源码来源:ITLee博客</font></center>'
        }, {
            xtype: 'NavigationMenu'
        }, {
            id: 'mainContent',
            title: '主题内容显示',
            layout: 'fit',
            region: 'center',
            collapisble: true,
            contentEl: 'contentIframe'
        }, {
            id: 'footer',
            layout: 'fit',
            region: 'south',
            collapisble: true,
            html: '<center><font size=2>版权所有：BeiDream</font></center>'
        }];
        me.callParent(arguments);
    }
});