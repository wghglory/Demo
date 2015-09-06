/* 导航菜单的视图 */
Ext.define('BDream.view.NavigationMenu', {
    extend: 'Ext.panel.Panel',
    alias: 'widget.NavigationMenu',
    title: '功能菜单',
    region: 'west',
    width: 180,
    split: true,
    collapisble: true,
    layout: 'accordion',
    initComponent: function () {
        var me = this;
        me.store = {                       //代替store
            fields: ['title', 'layout'],    //代替Model 
            data: [
                { title: 'Ed', layout: 'fit' },
                { title: 'Tommy', layout: 'fit' }
            ]
        };
        me.items = [{ title: 'Ed', layout: 'fit',items:[]}];
        this.callParent(arguments);
    }
});