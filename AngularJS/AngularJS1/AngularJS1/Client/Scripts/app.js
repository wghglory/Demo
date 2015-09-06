'user strict';

var helloWorldApp = angular.module('helloWorldApp', [
    'ngRoute',
    'helloWorldControllers'
]);

helloWorldApp.config(['$routeProvider', '$locationProvider',
    function ($routeProvider, $locationProvider) {
        $routeProvider
        .when('/', { templateUrl: '/client/views/main.html', controller: 'MainController' })
        .when('/show', { templateUrl: '/client/views/show.html', controller: 'ShowController' })
        .when('/customer', { templateUrl: '/client/views/customer.html', controller: 'CustomerController' })
        .when('/newCustomer', { templateUrl: '/client/views/newCustomer.html', controller: 'AddCustomerController' })
        .when('/addedCustomer/:customer/:city', { templateUrl: '/client/views/addedCustomer.html', controller: 'AddedCustomerController' });

        $locationProvider.html5Mode(false).hashPrefix('!');
    }
]);