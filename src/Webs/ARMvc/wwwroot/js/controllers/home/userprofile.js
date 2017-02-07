/*global window */
define(['controllers/controllers'], function (controllers) {
    controllers.controller('UserProfileCtrl', ['$scope', '$location',  'authService',
        function ($scope, $location, authService) {
            authService.fillAuthData();
            //if (!authService.authentication.isAuth) {
            //    window.location = "/home/login";
            //} else {
            //     window.location = "/home/index";
            //}
        }
    ]);
});
