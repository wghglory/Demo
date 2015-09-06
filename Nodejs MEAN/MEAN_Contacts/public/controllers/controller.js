var myApp = angular.module('myApp', []);

myApp.controller('AppCtrl', ['$scope', '$http', function($scope, $http) {
    console.log("Hello World from controller");


    var refresh = function () {
        $http.get('/contactlist').success(function (response) {
            console.log("I got the data I requested");
            $scope.contactlist = response;
            $scope.contact = "";
        });
    };

    refresh();

    $scope.addContact = function () {
        console.log($scope.contact);
        $http.post('/contactlist', $scope.contact).success(function (response) {
            console.log(response);
            refresh();
        });
    };

    $scope.remove = function (id) {
        console.log(id);
        $http.delete('/contactlist/' + id).success(function (response) {
            refresh();
        });
    };

    $scope.edit = function (id) {
        console.log(id);
        // $http.get('/contactlist/' + id).success(function(response) {
        //   $scope.contact = response;
        // });

        var contact = $scope.contactlist.filter(function (item) {
            return item._id === id;
        })[0];
        $scope.contact = JSON.parse(JSON.stringify(contact)); // this makes a copy of the contact, otherwise you see two-way binding at work with the existing contact

    };

    $scope.update = function () {
        console.log($scope.contact._id);
        $http.put('/contactlist/' + $scope.contact._id, $scope.contact).success(function (response) {
            refresh();
        })
    };

    $scope.deselect = function () {
        $scope.contact = "";
    }

}]);