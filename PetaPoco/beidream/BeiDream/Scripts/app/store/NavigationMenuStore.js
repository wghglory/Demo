Ext.define('BDream.store.NavigationMenuStore', {
    extend: 'Ext.data.Store',
    model: 'BDream.model.NavigationMenuModel',
    data: [{ title: "Tom", layout: "fit"},
        { title: "Jerry", layout: "fit"}]
});