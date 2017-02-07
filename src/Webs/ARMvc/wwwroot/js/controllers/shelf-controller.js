/*global window */
define(['controllers/controllers'], function (controllers) {
    // home controller
    controllers.controller('ShelfCtrl', ['$scope', '$location', 'BOOK', 'authService',
        function ($scope, $location, BOOK, authService) {

            authService.fillAuthData();
            if (!authService.authentication.isAuth) {
                window.location = "/account/index";
            }
            $scope.books = BOOK.get({}, function (books) {
                console.log(books);
                return books;
            });
            $scope.authen = authService.authentication;
        }
    ]);
});