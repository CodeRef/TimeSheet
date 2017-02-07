define(['controllers/controllers'], function (controllers) {
    controllers.controller('RegisterCtrl', ['$scope', '$location', '$timeout', 'authService',
        function ($scope, $location, $timeout, authService) {
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
            $scope.register = {
                FirstName: '',
                LastName: '',
                Email: '',
                UserName: '',
                Password: '',
                ConfirmPassword: '',
                tnc: false
            };
            $scope.back = function () {
                $location.path('/login');
            };
            $scope.savedSuccessfully = false;
            $scope.message = '';
            var handleRegister = function () {

                $('.register-form').validate({
                    errorElement: 'span', //default input error message container
                    errorClass: 'help-block', // default input error message class
                    focusInvalid: false, // do not focus the last invalid input
                    ignore: "",
                    rules: {

                        firstname: {
                            required: true
                        },
                        lastname: {
                            required: true
                        },
                        email: {
                            required: true,
                            email: true
                        },
                        username: {
                            required: true
                        },
                        password: {
                            required: true
                        },
                        rpassword: {
                            equalTo: "#register_password"
                        },

                        tnc: {
                            required: true
                        }
                    },

                    messages: { // custom messages for radio buttons and checkboxes
                        tnc: {
                            required: "Please accept TNC first."
                        }
                    },

                    invalidHandler: function (event, validator) { //display error alert on form submit   

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
                        if (element.attr("name") === "tnc") { // insert checkbox errors after the container                  
                            error.insertAfter($('#register_tnc_error'));
                        } else if (element.closest('.input-icon').size() === 1) {
                            error.insertAfter(element.closest('.input-icon'));
                        } else {
                            error.insertAfter(element);
                        }
                    },

                    submitHandler: function (form) {
                        authService.saveRegistration($scope.register).then(function (response) {
                            $scope.savedSuccessfully = true;
                           // $('.content').animate({width:'500px'});
                        }).catch( function (response) {
                            
                            var errors = [];
                            for (var key in response.data.modelState) {
                                for (var i = 0; i < response.data.modelState[key].length; i++) {
                                    errors.push(response.data.modelState[key][i]);
                                }
                            }
                            $scope.message = "Failed to register user due to:" + errors.join(' ');
                            $('.alert-danger', $('.register-form')).show();
                        });
                    }
                });

                $('.register-form input').keypress(function (e) {
                    if (e.which === 13) {
                        if ($('.register-form').validate().form()) {
                            $('.register-form').submit();
                        }
                        return false;
                    }
                });

            };
            handleRegister();
        }
    ]);
});