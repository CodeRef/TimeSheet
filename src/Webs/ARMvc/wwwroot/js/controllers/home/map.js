define(['controllers/controllers'], function (controllers) {
    // home controller
    controllers.controller('MapCtrl', ['$scope', '$location', 'BOOK', 'authService',
        function ($scope, $location, BOOK, authService) {
            authService.fillAuthData();
            if (!authService.authentication.isAuth) {
               // $location.path('/login');
            }
            //$scope.books = BOOK.get({}, function (books) {
            //    console.log(books);
            //    return books;
            //});
            //$scope.login = function () {
            //    authService.login().then(function () {
            //        isAuth();
            //    });

            //}
            //$scope.getProductPage = function () {
            //    require(["/Public/js/views/Product/index"]);
            //};
            //$scope.authen=authService.authentication;

        }
    ]);
});