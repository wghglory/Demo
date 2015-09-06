Ext.define('BDream.controller.Index', {
    extend: 'Ext.app.Controller',
    //stores: ['NavigationMenuStore'],
    //model: ['NavigationMenuModel'],
    //将Viewport.js添加到控制器
    views: ['Viewport', 'NavigationMenu']
})