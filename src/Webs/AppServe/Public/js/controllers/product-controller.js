define(['controllers/controllers'], function (controllers) {
    // product controller
    controllers.controller('ProjectIndexCtrl', ['$scope', 'books',
        function ($scope, books) {
            console.log('ProjectIndexCtrl execute.');

            $scope.books = books;
        }
    ]);
});