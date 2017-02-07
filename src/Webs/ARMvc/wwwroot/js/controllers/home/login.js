/*global window */
define(['controllers/controllers'], function (controllers) {
    // home controller
    controllers.controller('LoginCtrl', ['$scope', '$location', 'authService',
        function ($scope, $location, authService) {
            $scope.loginData = {
                userName: "",
                password: "",
                useRefreshTokens: false
            };

            function submitForm() {
                authService.login($scope.loginData).then(function (response) {
                    window.location = '/home/index';
                }).catch(function (response) {
                    $scope.message = "Failed to login : " + response.error_description;
                    $('.alert-danger', $('.login-form')).show();
                });
            }
            $('.login-form input').keypress(function (e) {
                if (e.which === 13) {
                  console.log(e.which);
                    submitForm();
                    return false;
                }
            });
            $('.login-form button').click(function () {
                submitForm();
                return false;
            });
        }
    ]);
});
