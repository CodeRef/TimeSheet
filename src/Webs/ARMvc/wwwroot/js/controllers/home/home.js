/*global window */
define(['controllers/controllers'], function (controllers) {
    // home controller
    controllers.controller('HomeCtrl', ['$scope', '$location', 'BOOK', 'authService', 'MAP',
        function ($scope, $location, BOOK, authService, MAP) {
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
                window.location = "/home/login";
            } else {

                // else $location.path('/login');
                //else
                //    $scope.authStatus = 'Anonymous User!!!'
                //}
                //isAuth();

                ////console.log('HomeCtrl execute.');

                //$scope.books = BOOK.get({}, function (books) {
                //    console.log(books);
                //    return books;
                //});

                //--------------- HOW TO CALL API ---------------------
                $scope.maps = MAP.get({ id: 1 }, function (maps) {
                  //  console.log(maps);
                    return maps;
                });

                $scope.maps2 = MAP.query({}, function (maps) {
                 //   console.log(maps);
                    return maps;
                });


                //TODO : First way to post data to api.
                MAP.save({ 'Id':1,'Name':'test'}, function () {
                   console.log('post finished.')
                })
                // ------------------- END EXAMPLE ---------------




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

        }
    ]);
});