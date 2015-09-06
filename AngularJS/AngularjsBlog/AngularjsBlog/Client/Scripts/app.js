'use strict';
/* App Module */
var blogApp = angular.module('blogApp', [
    'ngRoute',
    'blogControllers',
    'blogServices'
]);

blogApp.config(['$routeProvider', '$locationProvider',
    function ($routeProvider, $locationProvider) {
        $routeProvider.
            when('/', {
                templateUrl: '/client/views/main.html',
                controller: 'BlogController'
            })
            .when('/blogPost/:id', {
                templateUrl: '/client/views/blogPost.html',
                controller: 'BlogViewController'
            });
        $locationProvider.html5Mode(false).hashPrefix('!');
    }
]);