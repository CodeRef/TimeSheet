/*global window */
define(['controllers/controllers'], function (controllers) {
    // home controller
    controllers.controller('HomeCtrl', ['$scope', '$location', 'BOOK', 'authService',
        function ($scope, $location, BOOK, authService) {
            //$scope.loginData = {
            //    userName: "",
            //    password: "",
            //    useRefreshTokens: false
            //};
            // check

            authService.fillAuthData();

            // login
            //   authService.login();
            // $scope.authStatus = '';
            //function isAuth() {
            if (!authService.authentication.isAuth) {
                //i$location.absUrl() == '/account/login'; //$location.path('/login');
                window.location = "/account/index";
            }
            // else $location.path('/login');
            //else
            //    $scope.authStatus = 'Anonymous User!!!'
            //}
            //isAuth();

            ////console.log('HomeCtrl execute.');

            $scope.books = BOOK.get({}, function (books) {
                console.log(books);
                return books;
            });
            ////$scope.login = function () {
            ////    authService.login().then(function () {
            ////        isAuth();
            ////    });

            ////}
            //$scope.login = function () {
            //    authService.login($scope.loginData).then(function (response) {
            //        $location.path('/books');
            //    },
            //     function (err) {
            //         $scope.message = err.error_description;
            //     });
            //};
            $scope.authen = authService.authentication;
        }
    ]);
});