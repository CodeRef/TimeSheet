/*global window */
define(['controllers/controllers'], function (controllers) {
    // home controller
    controllers.controller('LoginCtrl', ['$scope', '$location', 'authService',
        function ($scope, $location, authService) {
            $.backstretch([
             "../../Content/templates/metronic/assets/admin/pages/media/bg/5.jpg",
             "../../Content/templates/metronic/assets/admin/pages/media/bg/6.jpg",
             "../../Content/templates/metronic/assets/admin/pages/media/bg/7.jpg",
             "../../Content/templates/metronic/assets/admin/pages/media/bg/8.jpg",
             "../../Content/templates/metronic/assets/admin/pages/media/bg/9.jpg",
             "../../Content/templates/metronic/assets/admin/pages/media/bg/10.jpg",
             "../../Content/templates/metronic/assets/admin/pages/media/bg/11.jpg"
            ], {
                fade: 1000,
                duration: 8000
            });

            $scope.loginData = {
                userName: "",
                password: "",
                useRefreshTokens: false
            };
            $scope.message = 'Enter any username and password.';
            var handleLogin = function () {
                $('.login-form').validate({
                    errorElement: 'span', //default input error message container
                    errorClass: 'help-block', // default input error message class
                    focusInvalid: false, // do not focus the last invalid input
                    rules: {
                        username: {
                            required: true
                        },
                        password: {
                            required: true
                        },
                        remember: {
                            required: false
                        }
                    },

                    messages: {
                        username: {
                            required: "Username is required."
                        },
                        password: {
                            required: "Password is required."
                        }
                    },

                    invalidHandler: function (event, validator) { //display error alert on form submit   
                        $('.alert-danger', $('.login-form')).show();
                    },

                    highlight: function (element) { // hightlight error inputs
                        $(element)
                            .closest('.form-group').addClass('has-error'); // set error class to the control group
                    },

                    success: function (label) {
                        label.closest('.form-group').removeClass('has-error');
                        label.remove();
                    },

                    errorPlacement: function (error, element) {
                        error.insertAfter(element.closest('.input-icon'));
                    },

                    submitHandler: function (form) {
                        authService.login($scope.loginData).then(function (response) {
                            window.location = '/';
                        }).catch( function (response) {
                            $scope.message = "Failed to login : " + response.error_description;
                            $('.alert-danger', $('.login-form')).show();
                        });
                    }
                });

                $('.login-form input').keypress(function (e) {
                    if (e.which === 13) {
                        if ($('.login-form').validate().form()) {
                            $('.login-form').submit();
                        }
                        return false;
                    }
                });
            };
            handleLogin();
        }
    ]);
});