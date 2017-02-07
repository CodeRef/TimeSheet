/*global window */
define(['controllers/controllers'], function (controllers) {
    // home controller
    controllers.controller('CreateShelfCtrl', ['$scope', '$location', 'BOOK', 'authService',
        function ($scope, $location, BOOK, authService) {
           // debugger;
            authService.fillAuthData();
            //if (!authService.authentication.isAuth) {
            //    window.location = "/account/index";
            //}
            //$scope.books = BOOK.get({}, function (books) {
            //    console.log(books);
            //    return books;
            //});
            $scope.authen = authService.authentication;

            $scope.data = {
                //firstname: "default",
                name: "default",
                description: "default",
               // member: false,
               // file_profile: "default",
               // file_avatar: "default"
            };
            $scope.submitForm = function () {
                debugger;
                console.log($scope.data.name);
                console.log($scope.data.description);
                console.log("posting data....");
                //$http.post('http://posttestserver.com/post.php?dir=jsfiddle', JSON.stringify(data)).success(function () {/*success callback*/ });
            };
        }
    ]);
});