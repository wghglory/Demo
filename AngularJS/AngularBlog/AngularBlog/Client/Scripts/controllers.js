/* chapter5/controllers.js */
'use strict';
/* Controllers */
var blogControllers = angular.module('blogControllers', []);

//blogControllers.controller('BlogController', ['$scope',
//    function BlogController($scope) {
//        $scope.blogArticle =
//            "This is a blog post about AngularJS. We will cover how to build a blog and how to add comments to the blog post.";
//        $scope.blogList = [
//            {
//                "_id": 1,
//                "date": 1400623623107,
//                "introText": "This is a blog post about AngularJS. We will cover how to build",
//                "blogText": "This is a blog post about AngularJS. We will cover how to build a blog and how to add comments to the blog post."
//            },
//            {
//                "_id": 2,
//                "date": 1400267723107,
//                "introText": "In this blog post we will learn how to build applications based on REST",
//                "blogText": "In this blog post we will learn how to build applications based on REST web services that contain most of the business logic needed for the application."
//            }
//        ];
//    }
//]);

blogControllers.controller('BlogController', ['$scope', 'BlogList',
    function BlogController($scope, BlogList) {
        //$scope.blogList = [];  //for unit test: Learning AngularJS page 156
        BlogList.get({},
             function success(response) {
                 console.log("Success:" + JSON.stringify(response));
                 $scope.blogList = response;
             },
             function error(errorResponse) {
                 console.log("Error:" + JSON.stringify(errorResponse));
             }
        );
    }
]);


////==============================mock data======================================
//blogControllers.controller('BlogViewController', ['$scope', '$routeParams',
//    function BlogViewController($scope, $routeParams) {
//        var blogId = $routeParams.id;
//        var blog1 = {
//            "_id": 1,
//            "date": 1400623623107,
//            "introText": "This is a blog post about AngularJS. We will cover how to build",
//            "blogText": "This is a blog post about AngularJS. We will cover how to build a blog and how to add comments to the blog post.",
//            "comments": [{ "commentText": "Very good post. I love it." }, { "commentText": "When can we learn services." }]
//        };
//        var blog2 = {
//            "_id": 2,
//            "date": 1400267723107,
//            "introText": "In this blog post we will learn how to build applications based on REST",
//            "blogText": "In this blog post we will learn how to build applications based on REST web services that contain most of the business logic needed for the application.",
//            "comments": [{ "commentText": "REST is great. I want to know more." }, { "commentText": "Will we use Node.js for REST services?." }]
//        };
//        if (blogId === '1') {
//            $scope.blogEntry = blog1;
//        } else if (blogId === '2') {
//            $scope.blogEntry = blog2;
//        }
//    }
//]);


blogControllers.controller('BlogViewController', ['$scope', '$routeParams', 'BlogPost',
    function BlogViewController($scope, $routeParams, BlogPost) {
        var blogId = $routeParams.id;
        //$scope.blg = 1;
        BlogPost.get({ id: blogId },
            function success(response) {
                console.log("Success:" + JSON.stringify(response));
                $scope.blogEntry = response;
            },
            function error(errorResponse) {
                console.log("Error:" + JSON.stringify(errorResponse));
            }
        );
    }
]);



