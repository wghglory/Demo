'use strict';

var helloWorldControllers = angular.module('helloWorldControllers', []);

helloWorldControllers.controller('MainController', ['$scope', '$location', '$http',
    function MainController($scope, $location, $http) {
        $scope.message = "Hello World";
    }
]);

helloWorldControllers.controller('ShowController', ['$scope', '$location', '$http',
    function ShowController($scope, $location, $http) {
        $scope.message = "This is from show controller";
    }
]);


helloWorldControllers.controller('CustomerController', ['$scope',
    function CustomerController($scope) {
        $scope.customerName = "Bob's Burgers";
        $scope.customerNumber = "44522";

        // add method to scope
        $scope.changeCustomer = function () {
            $scope.customerName = $scope.cName;
            $scope.customerNumber = $scope.cNumber;
        };
    }
]);

helloWorldControllers.controller('AddCustomerController', ['$scope', '$location',
    function AddCustomerController($scope, $location) {
        $scope.submit = function () {
            $location.path('/addedCustomer/' + $scope.cName + "/" + $scope.cCity); //change path after submitting the form
        };
    }
]);

helloWorldControllers.controller('AddedCustomerController', ['$scope', '$routeParams',
    function AddedCustomerController($scope, $routeParams) {
        $scope.customerName = $routeParams.customer;
        $scope.customerCity = $routeParams.city;
    }
]);