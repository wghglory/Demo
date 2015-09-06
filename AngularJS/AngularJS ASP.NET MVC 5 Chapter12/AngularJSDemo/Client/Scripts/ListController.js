//(function (app) {
//    var app = angular.module("atTheMovies");
//}());

//(function (app) {
//    var ListController = function ($scope) {
//        $scope.message = "Hello world!";
//    };

//    app.controller("ListController", ListController);
//}(angular.module("atTheMovies")));

(function (app) {

    var ListController = function ($scope, $http, movieService) {
        //$scope.message = "Hello world!";
        //$http.get("/api/movie")
        //    .success(function (data) {
        //        $scope.movies = data;
        //    });
        movieService.getAll().success(function (data) {
            $scope.movies = data;
        });  ////不好用

        $scope.create = function () {
            $scope.edit = {
                movie: {
                    Title: "",
                    Runtime: 0,
                    ReleaseYear: new Date().getFullYear()
                }
            };
        };

        $scope.delete = function (movie) {
            movieService.deleteIt(movie).success(function () {
                removeMovieById(movie.Id);
            });
        };  // 不好用

        var removeMovieById = function (id) {
            for (var i = 0; i < $scope.movies.length; i++) {
                if ($scope.movies[i].Id == id) {
                    $scope.movies.splice(i, 1);
                    break;
                }
            }
        };
    };

    ListController.$inject = ["$scope", "$http"]; //防止minify把这两只变量名字缩小
    app.controller("ListController", ListController);
}(angular.module("atTheMovies")));